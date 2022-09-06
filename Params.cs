using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAN_Simulator
{
    class Params
    {
        private ushort _scrollBar;
        private bool _checkBoxStatus;
        private bool _checkBoxPower;
        public void Init(ushort position,bool state,bool power)
        {
            _scrollBar = position;
            _checkBoxStatus = state;
            _checkBoxPower = power;
        }
        public string ShowParams()
        {
            return _scrollBar.ToString()+" | "+_checkBoxStatus.ToString()+" | "+_checkBoxPower.ToString();
        }
        public void ChangePositionValue(ushort pos)
        {
            _scrollBar = pos;
        }
        public void ChangeStateValue(bool state)
        {
            _checkBoxStatus = state;
        }
        public void ChangePowerValue(bool power)
        {
            _checkBoxPower = power;
        }
    }
}
