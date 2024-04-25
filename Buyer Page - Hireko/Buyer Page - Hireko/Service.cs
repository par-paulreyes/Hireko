using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buyer_Page___Hireko
{
    public class Service
    {
        public string Name { get; set; }

        public string Information { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Service(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
    }
}

