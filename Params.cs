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
    class Params
    {
        private UInt32 _id;
        private ushort _workinPartPosition;
        private ushort _fallTime;
        private uint _state;
        public UInt32 ID { get { return _id; } }
        public ushort WorkinPartPosition { get { return _workinPartPosition; } }
        public ushort FallTime { get { return _fallTime; } }

        /// <summary>
        /// Инициализация объекта
        /// </summary>
        public void Init(ushort positionValue, UInt32 id, StateCode code)
        {
            _id = id;
            _workinPartPosition = positionValue;
            _fallTime = 500;
            _state = (uint)code;
        }
        public string ShowMessage(CanMessage msg)
        {
            string msgStr = "RawData:\nID: " + _id + "| Pos: " + _workinPartPosition + "| FTime:" + _fallTime + "| State: " + _state + "|\n\nMessage 0x180:\n";
               msgStr += "ID: " + msg.Id + " | Flag: " + msg.Flag + " | Size: " + msg.Size + " | \n";
            msgStr += "Bytes: \n";
            foreach(var bytes in msg.Data){
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
        public void ChangePositionValue(ushort pos)
        {
            _workinPartPosition = pos;
        }
        public void SetState(StateCode pos)
        {
            _state = (uint)pos;
        }
    }
}
