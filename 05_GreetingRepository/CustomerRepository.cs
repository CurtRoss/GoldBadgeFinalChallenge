using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingRepository
{
    public class CustomerRepository
    {
        public readonly List<Customer> _listOfCustomer = new List<Customer>();

        //Create
        public void CreateNewCustomer(Customer customer)
        {
            _listOfCustomer.Add(customer);
        }

        //Read
        public List<Customer> GetList()
        {
            return _listOfCustomer;
        }

        //Update
        public bool UpdateCustomer(int customerID, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByCustomerID(customerID);
            if (oldCustomer != null)
            {
                oldCustomer.Email = newCustomer.Email;
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;

                return true;
            }
            return false;
        }

        //Delete
        public bool DeleteCustomer(int customerID)
        {
            Customer customerToDelete = GetCustomerByCustomerID(customerID);
            if (customerToDelete == null)
            {
                return false;
            }

            int initialCount = _listOfCustomer.Count;
            _listOfCustomer.Remove(customerToDelete);

            if (initialCount > _listOfCustomer.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Helper
        public Customer GetCustomerByCustomerID(int customerID)
        {
            foreach(Customer customer in _listOfCustomer)
            {
                if (customerID == customer.CustomerID)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
