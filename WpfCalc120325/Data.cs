using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalc120325
{
    public enum Operation
    {
        Minus,
        Plus,
        Divide,
        Multiply,
        Equal
    }

    public class Data
    {
        public double Number {  get; set; }
        public Operation? Operation { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsNew { get; set; }
    }
}
