using _05_GreetingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingConsole
{
    public class UI
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public void Run()
        {
            SeedMethod();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Customer Messaging Repository, Where we send annoying messages to all our past, present and future clientelle. I forgot to ask, did you know that you have access to an extended warranty on your vehicle?? Anyways, onto the Menu Options:\n\n" +
                    "1. Add a Customer\n" +
                    "2. Delete a Customer\n" +
                    "3. Display Customer List\n" +
                    "3. Update existing Customer\n" +
                    "4. Send annoying, awful message to each and every possible customer with a pre-recorded message for each!\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Code for Adding a Customer to Repo
                        AddCustomerToList();
                        break;
                    case "2":
                        //Code for deleting a customer from the repo
                        DeleteCustomerFromList();
                        break;
                    case "3":
                        //Code for displaying our customer list
                        DisplayAllCustomers();
                        break;
                    case "4":
                        //Code to send message to each user with message differentiated for their enum
                        SendMessageToAll();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("You entered an invalid option. Try Again.");
                        break;
                }

            }

        }
        //Add Customer to List
        private void AddCustomerToList()
        {
            Customer customerToAdd = new Customer();

            Console.WriteLine("What is the customer's first name?");
            customerToAdd.FirstName = Console.ReadLine();

            Console.WriteLine("What is the Customer's last name?");
            customerToAdd.LastName = Console.ReadLine();

            Console.WriteLine("What is the customer's Email address?");
            customerToAdd.Email = Console.ReadLine();

            Console.WriteLine("What is the customer type?\n\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    int num1 = int.Parse(input);
                    customerToAdd.TypeOfCustomer = (CustomerType)num1;
                    break;
                case "2":
                    int num2 = int.Parse(input);
                    customerToAdd.TypeOfCustomer = (CustomerType)num2;
                    break;
                case "3":
                    int num3 = int.Parse(input);
                    customerToAdd.TypeOfCustomer = (CustomerType)num3;
                    break;
                default:
                    Console.WriteLine("You have entered an invalid input. Try again.");
                    break;
            }
            _customerRepository.CreateNewCustomer(customerToAdd);
        }

        //Delete Existing Customer from List
        private void DeleteCustomerFromList()
        {
            DisplayAllCustomers();

            Console.WriteLine("Please enter the Customer ID of the Customer you would like to delete from the list");

            bool isTrue = int.TryParse(Console.ReadLine(), out int input);
            if (isTrue)
            {
                Customer customerToDelete = _customerRepository.GetCustomerByCustomerID(input);
                if (customerToDelete != null)
                {
                    bool didItWork = _customerRepository.DeleteCustomer(input);
                    if (didItWork)
                    {
                        Console.WriteLine("Customer was successfully deleted");
                        Console.ReadLine();
                    }
                    //this else statement is probably superfluous.
                    else
                    {
                        Console.WriteLine("Customer was not deleted.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("There is no customer with that Customer ID");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("You entered something that was not a number, try again");
                Console.ReadLine();
            }
        }

        //Display Customer Method
        private List<Customer> DisplayAllCustomers()
        {
            List<Customer> displayList = _customerRepository.GetList();
            


            //build out container for each data collection
            List<int> customerID = new List<int>();
            List<CustomerType> customerType = new List<CustomerType>();
            List<string> firstName = new List<string>();
            List<string> lastName = new List<string>();
            List<string> email = new List<string>();

            //Fill each List with contents per each Customer.
            foreach (Customer customer in displayList.OrderBy(x => x.LastName).ThenBy(x => x.LastName).ThenBy(x => x.CustomerID))
            {
                customerID.Add(customer.CustomerID);
                customerType.Add(customer.TypeOfCustomer);
                firstName.Add(customer.FirstName);
                lastName.Add(customer.LastName);
                email.Add(customer.Email);
            }

            //Display contents of each list formatted into columns. 
            var display = new System.Text.StringBuilder();
            display.Append(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,-35}\n\n", "Customer ID", "Customer Type", "Customer First Name", "Customer Last Name", "Customer Email"));

            for (int i = 0; i < customerID.Count; i++)
            {
                display.Append(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,-35}\n", customerID[i], customerType[i], firstName[i], lastName[i], email[i]));
            }
            Console.WriteLine(display);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            return displayList;

        }

        //Send mass email
        private void SendMessageToAll()
        {
            List<Customer> emailAll = _customerRepository.GetList();
            Console.WriteLine("Press enter to email promotional material to the entire Client List");
            Console.ReadLine();
            foreach (Customer customer in emailAll)
            {
                if (customer.TypeOfCustomer == (CustomerType)1)
                {
                    Console.WriteLine($"Sent to {customer.LastName}, {customer.FirstName}. Email Address: {customer.Email} at {DateTime.Now}: \nEmail: You should buy our insurance, we are incompetent nincompoops who would like your money. Insurance is a scam (kind of), we will use your pool of money to invest and make us rich, all the while we will likely do our best to deny your actual real life claim which was super legit. Thanks for coming to my TedTalk. \n\n");
                    
                }
                else if (customer.TypeOfCustomer == (CustomerType)2)
                {
                    Console.WriteLine($"Sent to {customer.LastName}, {customer.FirstName}. Email Address: {customer.Email} at {DateTime.Now}: \nEmail: Thanks for being a loyal customer! If you are reading this you already know that we take your money while providing a pseudo-service, at best. If you continue to give us your hard earned dollars, we will continue to grow our fortunes while you become 'insurance poor'.\n\n");
                    
                }
                else
                {
                    Console.WriteLine($"Sent to {customer.LastName}, {customer.FirstName}. Email Address: {customer.Email} at {DateTime.Now}: \nEmail: You were the intelligent ones that got out while you could. If you feel so inclined to pay us money again, we will make sure to invest it for your, erm, I mean OUR future yachts.\n\n");
                    
                }
            }
                Console.ReadLine();
        }
        private void SeedMethod()
        {
            Customer customer1 = new Customer((CustomerType)1, "Curt", "Reigelsperger", "curt.reigelsperger@gmail.com");
            Customer customer2 = new Customer((CustomerType)2, "Jeff", "Davis", "jd@isGod.com");
            Customer customer3 = new Customer((CustomerType)3, "Jerry", "Springer", "terribletalkshowhost@gmail.com");
            Customer customer4 = new Customer((CustomerType)3, "Jefferson", "Davis", "leaderofconfederacythefirstlosers@racists.com");

            _customerRepository.CreateNewCustomer(customer1);
            _customerRepository.CreateNewCustomer(customer2);
            _customerRepository.CreateNewCustomer(customer3);
            _customerRepository.CreateNewCustomer(customer4);
        }
    }
}