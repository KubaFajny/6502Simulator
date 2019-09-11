using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    enum ACIAStatusFlag { PariotyError, FramingError, Overrun, RxDataFull, TxDataEmpty, DCD, DSR, Interrupt }

    /// <summary>
    /// The ACIA (The 6551 Asynchronous Communications Interface Adapter) is an IO device simulating the actual chip used in some 8-bit computers with the 6502 processor.
    /// This device simulates transmitting and receiving data from keyboard to the computer, data transport speed with configurable baudrate and interrupt requests.
    /// This device class implements five 8-bit registers: ReceiveData, TransmitData, Command, Status and Control.
    /// Further documentation here: http://archive.6502.org/datasheets/mos_6551_acia.pdf
    /// </summary>
    class ACIA : Device
    {
        byte receiveDataRegister;
        byte transmitDataRegister;
        byte commandRegister;
        byte statusRegister;
        byte controlRegister;
        bool rxInterruptRequestEnabled;
        bool txInterruptRequestEnabled;
        long lastRead;
        long lastWrite;
        int delay;
        bool hasTxData;

        public ACIA(string name = "ACIA", double baudRate = 0)
        {
            DevType = DeviceType.ACIA;
            Name = name;
            CalculateDelay(baudRate);
            Reset();
        }

        public override void Write(int address, byte data)
        {
            switch (address)
            {
                case 0:
                    hasTxData = true;
                    ChangeStatusFlag(ACIAStatusFlag.TxDataEmpty, false);
                    lastWrite = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    transmitDataRegister = data;
                    break;
                case 1:
                    Reset();
                    break;
                case 2:
                    commandRegister = data;
                    rxInterruptRequestEnabled = (commandRegister & 0x2) == 0;
                    txInterruptRequestEnabled = (commandRegister & 0x4) != 0 && (commandRegister & 0x8) == 0;
                    break;
                case 3:
                    controlRegister = data;
                    if (data != 0)
                        SetBaudRateFromControlRegister();
                    else
                        Reset();
                    break;
            }
        }

        public override byte Read(int address)
        {
            switch (address)
            {
                case 0:
                    ChangeStatusFlag(ACIAStatusFlag.RxDataFull, false);
                    ChangeStatusFlag(ACIAStatusFlag.Overrun, false);
                    lastRead = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    return receiveDataRegister;
                case 1:
                    long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    if (HasStatusFlag(ACIAStatusFlag.RxDataFull))
                        ChangeStatusFlag(ACIAStatusFlag.RxDataFull, now >= lastRead + delay);

                    if (HasStatusFlag(ACIAStatusFlag.TxDataEmpty))
                        ChangeStatusFlag(ACIAStatusFlag.TxDataEmpty, now >= lastWrite + delay);

                    return statusRegister;
                case 2:
                    return commandRegister;
                case 3:
                    return controlRegister;
            }

            return 0; // Or throw exception?
        }

        public override void Write(int address, byte[] data)
        {
            throw new NotImplementedException();
        }

        public override byte[] Read(int address, int length)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetMemoryDump()
        {
            return new byte[] { transmitDataRegister, receiveDataRegister, statusRegister, commandRegister, controlRegister };
        }

        public bool HasStatusFlag(ACIAStatusFlag statusFlag)
        {
            return (statusRegister & (1 << (byte)statusFlag)) != 0;
        }

        public byte? GetTxData()
        {
            if (!hasTxData)
                return null;

            hasTxData = false;
            ChangeStatusFlag(ACIAStatusFlag.TxDataEmpty, true);
            if (txInterruptRequestEnabled)
            {
                ChangeStatusFlag(ACIAStatusFlag.Interrupt, true);
                FireInterruptRequestEvent();
            }

            return transmitDataRegister;
        }

        public void SetRxData(byte data)
        {
            if (HasStatusFlag(ACIAStatusFlag.RxDataFull))
                ChangeStatusFlag(ACIAStatusFlag.Overrun, true);

            ChangeStatusFlag(ACIAStatusFlag.RxDataFull, true);
            if (rxInterruptRequestEnabled)
            {
                ChangeStatusFlag(ACIAStatusFlag.Interrupt, true);
                FireInterruptRequestEvent();
            }

            receiveDataRegister = data;
        }

        private void Reset()
        {
            ChangeStatusFlag(ACIAStatusFlag.TxDataEmpty, true);
            ChangeStatusFlag(ACIAStatusFlag.RxDataFull, false);
            ChangeStatusFlag(ACIAStatusFlag.Interrupt, false);
            rxInterruptRequestEnabled = false;
            txInterruptRequestEnabled = false;
            transmitDataRegister = 0;
            receiveDataRegister = 0;
        }

        private void ChangeStatusFlag(ACIAStatusFlag statusFlag, bool set = false)
        {
            if (!set)
                statusRegister &= (byte)~(1 << (byte)statusFlag);
            else
                statusRegister |= (byte)(1 << (byte)statusFlag);
        }

        private void SetBaudRateFromControlRegister()
        {
            double baudRate = 0;
            switch (controlRegister & 0x0F)
            {
                case 0:
                    baudRate = 0;
                    break;
                case 1:
                    baudRate = 50;
                    break;
                case 2:
                    baudRate = 75;
                    break;
                case 3:
                    baudRate = 109.92;
                    break;
                case 4:
                    baudRate = 134.58;
                    break;
                case 5:
                    baudRate = 150;
                    break;
                case 6:
                    baudRate = 300;
                    break;
                case 7:
                    baudRate = 600;
                    break;
                case 8:
                    baudRate = 1200;
                    break;
                case 9:
                    baudRate = 1800;
                    break;
                case 10:
                    baudRate = 2400;
                    break;
                case 11:
                    baudRate = 3600;
                    break;
                case 12:
                    baudRate = 4800;
                    break;
                case 13:
                    baudRate = 7200;
                    break;
                case 14:
                    baudRate = 9600;
                    break;
                case 15:
                    baudRate = 19200;
                    break;
            }

            CalculateDelay(baudRate);
        }

        private void CalculateDelay(double baudRate)
        {
            
            delay = baudRate > 0 ? (int) ((10 / baudRate) * 1000) : 0;
        }
    }
}
