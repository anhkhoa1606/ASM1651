using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Clothing : Product
    {
        public string Size { get; set; }

        public Clothing(int id, string name, decimal price, string size) : base(id, name, price)
        {
            Size = size;
        }

        public override string GetAdditionalInfo()
        {
            return Size;
        }
        public override void UpdateAdditionalInfo(string newAdditionalInfo)
        {
            Size = newAdditionalInfo;
        }
    }
}
