using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Book : Product
    {
        public string Author { get; set; }

        public Book(int id, string name, decimal price, string author) : base(id, name, price)
        {
            Author = author;
        }

        public override string GetAdditionalInfo()
        {
            return Author;
        }
        public override void UpdateAdditionalInfo(string newAdditionalInfo)
        {
            Author = newAdditionalInfo;
        }
    }
}
