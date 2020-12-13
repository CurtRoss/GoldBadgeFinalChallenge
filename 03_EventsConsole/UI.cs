using _03_EventsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventsConsole
{
    public class UI
    {

        private readonly EventsRepository _eventsRepository = new EventsRepository();
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
                //Display Menu Options
                Console.WriteLine("Please select an option from the following choices\n\n" +
                    "1. Add new event to the list of outings.\n" +
                    "2. Display all outings.\n" +
                    "3. Display costs of outings\n" +
                    "4. Exit Program");

                //Take User Input 
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Method to add new event
                        AddEventToList();
                        break;
                    case "2":
                        //Method to Display all outings
                        DisplayAllOutings();
                        break;
                    case "3":
                        //Method to pull up Calculation sub-menu
                        Calculations();
                        break;
                    case "4":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("You have typed in an invalid option. Please try again (1, 2, 3, or 4.)");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Add event to List
        private void AddEventToList()
        {
            //Create new Event
            Events eventToAdd = new Events();

            //Populate properties by asking user series of Questions and storing their answers.
            while (true)
            {

                Console.WriteLine("What was the date of the event? Format: DD/MM/YYYY");
                string eventDateAsString = Console.ReadLine();
                bool didItWork = DateTime.TryParse(eventDateAsString, out DateTime dateOfEvent);
                if (didItWork)
                {
                    eventToAdd.DateOfEvent = dateOfEvent.Date;
                    break;
                }
                else
                {
                    Console.WriteLine("Did not input valid entry for date, try again.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            //What type of event?
            {
                Console.WriteLine("What type of event was it? Enter the number of the corresponding event.\n\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert");

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        eventToAdd.EventType = (EventType)1;
                        break;
                    case "2":
                        eventToAdd.EventType = (EventType)2;
                        break;
                    case "3":
                        eventToAdd.EventType = (EventType)3;
                        break;
                    case "4":
                        eventToAdd.EventType = (EventType)4;
                        break;
                    default:
                        Console.WriteLine("You have entered an invalid option, Try again");
                        break;
                }
            }

            //How many people attended the event?
            string restate = "How many people attended the event? Please enter a number.";
            Console.WriteLine(restate);
            eventToAdd.NumberOfAttendees = TryParseIntMethod(Console.ReadLine());


            //How much did the event cost per person?
            string restate2 = "How much did this event cost per person?";
            Console.WriteLine(restate2);
            eventToAdd.CostPerPerson = TryParseDoubleMethod(Console.ReadLine());

            _eventsRepository.AddEventToList(eventToAdd);
        }

        //Display all outings
        private void DisplayAllOutings()
        {
            //Get List of Events
            List<Events> _listOfEvents = _eventsRepository.GetEventList();

            //Display content from each Event
            foreach (Events events in _listOfEvents)
            {
                Console.WriteLine($"{events.DateOfEvent}    {events.EventType}      {events.NumberOfAttendees}  {events.TotalCost}");
            }
        }

        //Calculations
        private void Calculations()
        {
            //SubMenu
            Console.WriteLine("What would you like to calculate?\n\n" +
                "1. Combined cost of all outings?\n" +
                "2. Outings costs per type of outing");

            string input = Console.ReadLine();
            try
            {
                switch (input)
                {
                    case "1":
                        //Calculate costs for all outings.
                        List<double> listOfCosts = new List<double>();
                        foreach (Events events in _eventsRepository._allEventsList)
                        {
                            listOfCosts.Add(events.TotalCost);
                        }
                        Console.WriteLine(listOfCosts.Sum());

                        break;
                    case "2":
                        //Another submenu
                        Console.WriteLine("Calculate the total costs for which type?\n\n" +
                            "1. Golf\n" +
                            "2. Bowling\n" +
                            "3. Amusement Park\n" +
                            "4. Concert");

                        int input2 = int.Parse(Console.ReadLine());
                        EventType typeOfEvent = (EventType)input2;
                        switch (input2)
                        {
                            case 1:
                                //Code to calulate total costs for Golf
                                CalculateTotalForEnum(typeOfEvent);
                                break;
                            case 2:
                                //Code to calculate total costs for Bowling
                                CalculateTotalForEnum(typeOfEvent);
                                break;
                            case 3:
                                //Code to calculate total costs for Amusement Park
                                CalculateTotalForEnum(typeOfEvent);
                                break;
                            case 4:
                                //Code to calulate total costs for concerts
                                CalculateTotalForEnum(typeOfEvent);
                                break;
                            default:
                                //This is an invalid option
                                Console.WriteLine("This is an invalid option, Please select again.");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("You have input an invalid choice");
                        break;
                }
            }
            catch (Exception) 
            {

                Console.WriteLine($"Sorry wrong choice");
            }
        }


        //Helper Methods
        //Add all costs for particular enum method
        private void CalculateTotalForEnum(EventType eventType)
        {
            
            List<double> costs = new List<double>();
            foreach (Events events in _eventsRepository._allEventsList)
            {
                if((int)events.EventType == (int)eventType)
                {
                    costs.Add(events.TotalCost);
                }
            }
            Console.WriteLine(costs.Sum());
        }


        //Try Parse Int Helper Method
        private int TryParseIntMethod(string str)
        {
            while (true)
            {
                bool isTrue = int.TryParse(str, out int strAsInt);
                if (isTrue)
                {
                    return strAsInt;
                }
                else
                {
                    Console.WriteLine("You entered an invalid option, try another value (must be a number).");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }


        //Try Parse Double Helper Method
        private double TryParseDoubleMethod(string str)
        {
            while (true)
            {

                bool isTrue = double.TryParse(str, out double strAsDouble);
                if (isTrue)
                {
                    return strAsDouble;
                }
                Console.WriteLine("You entered an invalid option, try another value (must be a number).");
                Console.ReadLine();
                Console.Clear();

            }
        }

        private void SeedMethod()
        {
            Events event1 = new Events(EventType.AmusementPark, 43, new DateTime(1986, 12, 25), 25.25);
            Events event2 = new Events(EventType.Bowling, 72, new DateTime(1999, 11, 15).Date, 37);
            Events event3 = new Events(EventType.Concert, 115, new DateTime(2020, 06, 01).Date, 62.34);
            Events event4 = new Events(EventType.Concert, 65, new DateTime(1919, 03, 13).Date, 42.42);
            Events event5 = new Events(EventType.Golf, 43, new DateTime(2019, 11, 25).Date, 13);

            _eventsRepository.AddEventToList(event1);
            _eventsRepository.AddEventToList(event2);
            _eventsRepository.AddEventToList(event3);
            _eventsRepository.AddEventToList(event4);
            _eventsRepository.AddEventToList(event5);

        }

    }
}
