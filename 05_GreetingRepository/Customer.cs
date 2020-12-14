using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingRepository
{
    public enum CustomerType
    {
        Potential = 1,
        Current,
        Past
    }
    public class Customer
    {
        private static int count = 12345;
        public int CustomerID { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Customer()
        {
            count = count + 1;
            CustomerID = count;

        }

        public Customer(CustomerType customerType, string firstName, string lastName, string email)
        {
            count = count + 1;
            CustomerID = count;
            TypeOfCustomer = customerType;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
