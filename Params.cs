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
    class Params
    {
        private UInt32 _id;
        private ushort _workinPartPosition;
        private ushort _fallTime;
        private uint _state;
        private byte _driverType;
        private byte _kskuSignals;
        private byte _ioSignals;
        public UInt32 ID { get { return _id; } }
        public ushort WorkinPartPosition { get { return _workinPartPosition; } }
        public ushort FallTime { get { return _fallTime; } }

        /// <summary>
        /// Инициализация объекта
        /// </summary>
        public void Init(ushort positionValue, int id, StateCode code, WorkinPartType drType)
        {
            _id = (UInt32)id;
            _workinPartPosition = positionValue;
            _fallTime = 500;
            _state = (uint)code;
            _driverType = (byte)drType;
        }
        public string ShowMessage(CanMessage msg, CanMessage msg2)
        {
            string msgStr = "RawData:\nID: " + _id + " | Pos: " + _workinPartPosition + " | FTime:" + _fallTime + " | State: " + _state + " |\n\nMessage 0x180:\n";
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
            message.Id = Convert.ToUInt32(0x180) + _id;
            var posBytes = BitConverter.GetBytes(_workinPartPosition);
            var ftimeBytes = BitConverter.GetBytes(_fallTime);
            var codeBytes = BitConverter.GetBytes(_state);
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
            message.Id = Convert.ToUInt32(0x280) + _id;
            message.Data = new byte[4] { _kskuSignals , _driverType ,0,_ioSignals};
            message.Size = (Byte)message.Data.Length;
            if (message.Size > 8)
                throw new ArgumentException("Данные имеют размер больше допустимого (8 байт)");
            return message;
        }
        public void ChangePositionValue(ushort pos)
        {
            _workinPartPosition = pos;
        }
        public void SetState(StateCode pos)
        {
            _state = (uint)pos;
        }
        public void SetKSKUSignals(byte bytes)
        {
            _kskuSignals = bytes;
        }
        public void SetIOSignals(byte bytes)
        {
            _ioSignals = bytes;
        }
    }
}
