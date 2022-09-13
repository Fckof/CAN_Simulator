using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAN_Simulator
{
    public enum StateCode : uint
    {
        Ok=0,
        Defect=1,
        DriveMgmtDefect=2,
        BothDefect=3
    }
    public enum WorkinPartType : byte
    {
        AZ=1,
        KR=2,
        AR=3
    }
    public enum OutputSignals : int
    {
        VKV=0,
        PKV=455,
        NKV=650
    }
    public enum OutputSignalsAR : int
    {
        VKV = 0,
        PKV30 = 180,
        PKV50=300,
        PKV70=420,
        NKV = 600
    }

    class WorkPart
    {
        public UInt32 _Id { get; private set; }
        public ushort _WorkinPartPosition { get; private set; }
        public ushort _FallTime { get; private set; }
        public StateCode _State { get; private set; }
        public WorkinPartType _DriverType { get; private set; }
        public byte _KskuSignals { get; private set; }
        public byte _IOSignals { get; private set; }
        public byte _OutSignalsBUP { get; private set; }
        public List<byte> _BitsArrayBUP { get; private set; } = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0 };
        

        /// <summary>
        /// Инициализация объекта
        /// </summary>
        public void Init(ushort positionValue, int id, StateCode code, WorkinPartType drType)
        {
            _Id = (UInt32)id;
            _WorkinPartPosition = positionValue;
            _FallTime = 350;
            _State = code;
            _DriverType = drType;
            _OutSignalsBUP = 0;
            OutputSignalsBUP();
            OutputStatusBUP();
            SetBUPSignalsValue(BitsToByte(_BitsArrayBUP));
        }

        public void OutputSignalsBUP()
        {
            switch (_DriverType)
            {
                case WorkinPartType.AR:
                    if (_WorkinPartPosition == (ushort)OutputSignalsAR.VKV)
                    
                        _BitsArrayBUP = new List<byte> { 0, 0, 0, 0, 1, 1, 1, 1 };

                    else if (_WorkinPartPosition >= (ushort)OutputSignalsAR.VKV && _WorkinPartPosition <= (ushort)OutputSignalsAR.PKV30)

                        _BitsArrayBUP = new List<byte> { 1, 0, 0, 0, 1, 1, 1, 1 };

                    else if(_WorkinPartPosition >= (ushort)OutputSignalsAR.PKV30 && _WorkinPartPosition <= (ushort)OutputSignalsAR.PKV50)
                    
                        _BitsArrayBUP = new List<byte> { 1, 0, 1, 0, 1, 1, 1, 1 };
                    
                    else if(_WorkinPartPosition >= (ushort)OutputSignalsAR.PKV50 && _WorkinPartPosition <= (ushort)OutputSignalsAR.PKV70)
                    
                        _BitsArrayBUP = new List<byte> { 1, 0, 1, 1, 1, 1, 1, 1 };
                    
                    else if (_WorkinPartPosition >= (ushort)OutputSignalsAR.PKV70 && _WorkinPartPosition < (ushort)OutputSignalsAR.NKV)
                    
                        _BitsArrayBUP = new List<byte> { 1, 0, 1, 1, 0, 1, 1, 1 };
                    
                    else _BitsArrayBUP = new List<byte> { 1, 0, 1, 1, 0, 0, 1, 1 };
                    break;

                case WorkinPartType.AZ: case WorkinPartType.KR:
                    if(_WorkinPartPosition== (ushort)OutputSignals.VKV)
                        _BitsArrayBUP = new List<byte> { 0, 1, 0, 0, 0, 1, 1, 1 };
                    else if (_WorkinPartPosition > (ushort)OutputSignals.VKV && _WorkinPartPosition < (ushort)OutputSignals.PKV)
                        _BitsArrayBUP = new List<byte> { 1, 1, 0, 0, 0, 1, 1, 1 };
                    else if (_WorkinPartPosition > (ushort)OutputSignals.PKV && _WorkinPartPosition < (ushort)OutputSignals.NKV)
                        _BitsArrayBUP = new List<byte> { 1, 0, 0, 0, 0, 1, 1, 1 };

                    else _BitsArrayBUP = new List<byte> { 1, 0, 0, 0, 0, 0, 1, 1 };
                    break;

            }
        }
        public byte BitsToByte(List<byte> arr)
        {
            byte bits = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                bits += (byte)(arr[i] * Math.Pow(2, i));
            }
            return bits;
        }
        public void OutputStatusBUP()
        {
            switch (_State)
            {
                case StateCode.Defect:
                    _BitsArrayBUP[6] = (byte)0;
                    _BitsArrayBUP[7] = (byte)1;
                    break;
                case StateCode.DriveMgmtDefect:
                    _BitsArrayBUP[6] = (byte)1;
                    _BitsArrayBUP[7] = (byte)0;
                    break;
                case StateCode.BothDefect:
                    _BitsArrayBUP[6] = (byte)0;
                    _BitsArrayBUP[7] = (byte)0;
                    break;
                default:
                    _BitsArrayBUP[6] = (byte)1;
                    _BitsArrayBUP[7] = (byte)1;
                    break;
            }
        }
        public string ShowMessage(CanMessage msg, CanMessage msg2)
        {
            string msgStr = "RawData:\nID: " + _Id + " | Pos: " + _WorkinPartPosition + " | FTime:" + _FallTime + " | State: " + _State + " |\n\nMessage 0x180:\n";
            msgStr += "ID: " + msg.Id + " | Flag: " + msg.Flag + " | Size: " + msg.Size + " | \n";
            msgStr += "Bytes: \n";
            foreach(var bytes in msg.Data){
                msgStr += bytes + " | ";
            }
            msgStr +="\n\nMessage 0x280:\n";
            msgStr += "ID: " + msg2.Id + " | Flag: " + msg2.Flag + " | Size: " + msg2.Size + " | \n";
            msgStr += "Bytes: \n";
            foreach (var bytes in msg2.Data)
            {
                msgStr += bytes + " | ";
            }
            return msgStr;

        }
        public CanMessage CompareFirstMsg()
        {
            CanMessage message = new CanMessage();
            message.Id = Convert.ToUInt32(0x180) + _Id;
            var posBytes = BitConverter.GetBytes((ushort)(_WorkinPartPosition * (ushort)10));
            var ftimeBytes = BitConverter.GetBytes((ushort)(_FallTime/(ushort)10));
            var codeBytes = BitConverter.GetBytes((uint)_State);
            IEnumerable<byte> bytes = posBytes.Concat(ftimeBytes).Concat(codeBytes);
            message.Data = bytes.ToArray();
            message.Size = (Byte)message.Data.Length;
            if (message.Size > 8)
                throw new ArgumentException("Данные имеют размер больше допустимого (8 байт)");
            return message;
        }
        public CanMessage CompareSecondMsg()
        {
            CanMessage message = new CanMessage();
            message.Id = Convert.ToUInt32(0x280) + _Id;
            message.Data = new byte[4] { _KskuSignals , (byte)_DriverType , _OutSignalsBUP, _IOSignals};
            message.Size = (Byte)message.Data.Length;
            if (message.Size > 8)
                throw new ArgumentException("Данные имеют размер больше допустимого (8 байт)");
            return message;
        }
        public void ChangePositionValue(ushort pos)
        {
            _WorkinPartPosition = pos;
        }
        public void SetBUPSignalsValue(byte val)
        {
            _OutSignalsBUP = val;
        }
        public void SetState(StateCode pos)
        {
            _State = pos;
        }
        public void SetKSKUSignals(byte bytes)
        {
            _KskuSignals = bytes;
        }
        public void SetIOSignals(byte bytes)
        {
            _IOSignals = bytes;
        }
    }
}
