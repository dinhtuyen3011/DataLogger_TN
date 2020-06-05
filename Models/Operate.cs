using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLogger.Model
{
    class Operate
    {
        public string Channel { get; set; }
        public float Value { get; set; }
        public string Operand { get; set; }
        
        public Operate(string channel,float value)
        {
            Channel = channel;
            Value = value;
        }
    }

}
