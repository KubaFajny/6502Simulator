using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Threading;

namespace Simulator
{
    /// <summary>
    /// Connects the UI and the CPU in both ways and controls the simulation. 
    /// This class handles the creation of the simulated computer, program loading and sending commands between the CPU and the UI.
    /// </summary>
    class Simulator
    {
        public const int DEFAULT_START_ADDRESS = 0x200;
        public const int MEMORY_SIZE = 0x10000; // 64 kB
        public const int ZP_SIZE = 0x100;
        public const int ZP_ADDRESS = 0;
        public const int STACK_ADDRESS = 0x100;
        public const int STACK_SIZE = 0x100;

        SimulatorForm ui;
        CPU cpu;
        Bus bus;

        /// <summary>
        /// Constructs a new Simulator instance.
        /// </summary>
        /// <param name="ui">The UI Form that controls the simulation.</param>
        public Simulator(SimulatorForm ui)
        {
            this.ui = ui;

            // Initialize basic components of the simulated computer
            InitializeComponents();
        }

        /// <summary>
        /// Creates a new <see cref="CPU"/> instance along with an instance of the <see cref="Bus"/> class.
        /// Also creates instances of the appropriate devices used in the simulated computer and "wires" them together with the CPU via the Bus.
        /// </summary>
        /// <param name="withROM">Optional parameter to control whether the default ROM should be loaded into the memory. Implicitly true.</param>
        private void InitializeComponents(bool withROM = true)
        {
            // Create the basic components
            bus = new Bus();
            cpu = new CPU(bus);
            RAM ram = new RAM(MEMORY_SIZE);
            ACIA acia = new ACIA();

            // Set up the CPU event listeners
            cpu.UpdateEvent += new Action<Operation>(OnCpuUpdate);
            cpu.StartEvent += new Action(OnCpuStart);
            cpu.StopEvent += new Action(OnCpuStop);

            // Wire it all together
            bus.AddCPU(cpu);
            bus.AddDevice(ram, 0, 0xFFFF);
            bus.AddDevice(acia, 0x8800, 0x8803);

            // TODO: make this configurable
            if (withROM)
            {
                // Create a ReadOnly memory and load it with the EhBasic ROM image
                // It will overlap the RAM on the specified memory range
                ROM ehbasicROM = new ROM(0x4000, File.ReadAllBytes("ROM_images/ehbasic.rom"));
                bus.AddDevice(ehbasicROM, 0xC000, 0xFFFF);
            }

            // Reset the CPU so it will reinitialize its registers and set the program counter to the address stored in RESET vector
            cpu.InvokeReset();

            // Reinitialize the Memory dump tabs UI and fill it with dumped data from the memory
            ui.InitializeMemoryDump(bus.DumpDevicesMemory());
        }

        /// <summary>
        /// Starts the simulation that will run until the program finishes itself or the UI requests stop.
        /// It creates a new asynchronous task in which the simulation runs so it won't block the main thread with the UI.
        /// If the simulation is already running, the method stops it instead.
        /// </summary>
        /// <returns>A new asynchronous <see cref="Task"/> instance.</returns>
        public Task RunSimulation()
        {
            if (cpu.State.IsRunning)
                return StopSimulation();
            else
                return Task.Factory.StartNew(cpu.RunAll, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Moves the simulation one step ahead by commanding the CPU to fetch the next instruction and execute it.
        /// It creates a new asynchronous task in which the step is run so it won't block the main thread with the UI.
        /// </summary>
        /// <returns>A new asynchronous <see cref="Task"/> instance.</returns>
        public Task MoveToNextOperation()
        {
            return Task.Factory.StartNew(() => cpu.RunNext(true), TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Resets the simulation by invoking reset in the CPU to reinitialize its registers and set the program counter.
        /// </summary>
        public void ResetSimulation()
        {
            cpu.InvokeReset();
        }

        /// <summary>
        /// Hard resets the simulation by recreating the simulated machine, reloading the ROM and invoking CPU reset.
        /// </summary>
        public void HardResetSimulation()
        {
            InitializeComponents();
            ResetSimulation();
        }

        /// <summary>
        /// Requests stop of the simulation. 
        /// The stop method is executed in an asynchronous task as it needs to wait for the CPU to finish executing the current operation.
        /// </summary>
        /// <returns>A new asynchronous <see cref="Task"/> instance.</returns>
        public Task StopSimulation()
        {
            return Task.Factory.StartNew(cpu.Stop, TaskCreationOptions.None);
        }

        /// <summary>
        /// Loads a new program from the given binary file.
        /// If the simulation is already running, the method requests stop.
        /// </summary>
        /// <param name="file">The path to file containing the program.</param>
        public async void LoadProgramFromFile(String file)
        {
            // Wait until the simulation stops
            if (cpu.State.IsRunning)
                await StopSimulation();

            // Recreate the simulated computer without loading the ROM - we don't need it now
            InitializeComponents(false);

            // Write the program code to the Memory, beginning at the default starting address
            bus.Write(DEFAULT_START_ADDRESS, File.ReadAllBytes(file));

            // Write the default starting address to the RESET vector location
            bus.Write(0xFFFC, DEFAULT_START_ADDRESS & 0xFF);
            bus.Write(0xFFFD, DEFAULT_START_ADDRESS >> 8);
            bus.Write(0xFFFE, DEFAULT_START_ADDRESS & 0xFF);
            bus.Write(0xFFFF, DEFAULT_START_ADDRESS >> 8);

            // And reset the CPU to set the program counter correctly, ofcourse
            ResetSimulation();
        }

        /// <summary>
        /// Handles the Update event of the CPU.
        /// This method updates the UI and handles basic input/output via the Bus and the UI.
        /// </summary>
        /// <param name="operation">
        /// The operation that has been executed by the CPU before firing this event. 
        /// The value of this parameter may be null as this event is also called on resets when no operation is executed.
        /// </param>
        private void OnCpuUpdate(Operation operation)
        {
            // Update register values and info about the current operation in the UI
            ui.UpdateStateUI(new UpdateUIEventArgs(cpu.State, operation));

            // If this operation changed the memory, update also the memory dump window
            if (operation != null && operation.ChangesMemory())
                ui.UpdateMemoryDump(bus.DumpDevicesMemory());

            // Check if there is some output ready in the IO device and write it to the console
            byte? output = bus.GetConsoleOutput();
            if (output != null)
                ui.WriteConsoleOutput(output.Value);

            // Check if the user has typed in the console and send the input to the IO device if yes
            if (ui.HasConsoleInput())
                bus.SendConsoleInput(ui.GetConsoleInput());
        }

        /// <summary>
        /// Handles the Start event of the CPU.
        /// This method updates the text of the Run button on the UI.
        /// </summary>
        private void OnCpuStart()
        {
            ui.UpdateRunButton(true);
        }

        /// <summary>
        /// Handles the Stop event of the CPU.
        /// This method updates the text of the Run button on the UI.
        /// </summary>
        private void OnCpuStop()
        {
            ui.UpdateRunButton(false);
        }
    }
}
