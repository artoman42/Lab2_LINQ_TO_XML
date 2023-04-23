using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.enums;
namespace Library
{
    public class Client: Object<Client> 
    {
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public Categories Category { get; set; }
        public override string ToString()
        {
            return $"{FullName} {Adress} {Phone} {Category}";
        }
    }
}
