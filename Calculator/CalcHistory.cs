using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcHistory
    {
        public string Entry { get; set; }
        public string Operator { get; set; }
        public Decimal Result { get; set; }
        public decimal? PreviousEntry { get; set; }


    }

}
