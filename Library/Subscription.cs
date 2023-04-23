using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library
{
    public class Subscription : Object<Subscription>
    {
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public decimal RentalPrice { get {
              
                    int expectedDuration = (ExpectedReturnDate - DateOfIssue).Days;
                    decimal PricePerDay = 1.5M;
                    return   PricePerDay * expectedDuration;
            } }
        public override string ToString()
        {
            return $"Взято {DateOfIssue}, очікувана дата повернення{ExpectedReturnDate}, цiна прокату #{RentalPrice}";
        }
    }
}
