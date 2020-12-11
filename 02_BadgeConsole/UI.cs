using _02_BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeConsole
{
    public class UI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();
        public List<Door> _doorList = new List<Door>();


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
                bool isTrue = false;
                while (isTrue == false)
                {

                    Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                        "1. Add a Badge.\n" +
                        "2. Edit existing Badge.\n" +
                        "3. Show All Badge Numbers.");

                    string inputAsString = Console.ReadLine();

                    isTrue = int.TryParse(inputAsString, out int input);
                    if (input < 1 && input > 3)
                    {
                        Console.WriteLine("That was an invalid selection. Press enter to try again");
                        Console.ReadLine();
                    }
                    Console.WriteLine("Hit Enter to continue");
                    Console.ReadLine();

                    //Evaluate the user's input and act accordingly
                    switch (input)
                    {
                        case 1:
                            //Add Badge to Library
                            CreateBadge();
                            break;
                        case 2:
                            //Update Existing Badges
                            UpdateExistingBadge();
                            break;
                        case 3:
                            //List all Badges
                            DisplayAllBadgeNumbers();
                            break;
                        case 4:
                            Console.WriteLine("Goodbye.");
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("That was an errant selection, Press enter to try a different selection");
                            Console.ReadLine();
                            break;
                    }
                    Console.WriteLine("Please press Enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        //Create Badge and add it to the dictionary
        private void CreateBadge()
        {
            Badge newBadge = new Badge();

            //Show assigned Badge value and give the choice to overwrite it.

            Console.WriteLine($"New Badge is assigned Badge Number: {newBadge.BadgeNumber}\n\n" +
                $"Would you like to overwrite assigned Badge Number? Y/N?");
            if (Console.ReadLine().ToLower().Contains("y"))
            {
                bool thisTrue = true;
                while (thisTrue)
                {
                    Console.WriteLine("Enter new Badge Number");
                    thisTrue = int.TryParse(Console.ReadLine(), out int badgeNumber);
                    if (thisTrue)
                    {
                        newBadge.BadgeNumber = badgeNumber;
                        thisTrue = false;
                    }
                }
            }

            // Add doors to list of doors Badge gives access to
            bool isTrue = false;
            while (isTrue == false)
            {

                Console.WriteLine("Select the number of the door you want to add access to for this Badge");
                for (int i = 0; i < _doorList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.  {_doorList[i].DoorName}");
                }
                string inputAsString = Console.ReadLine();
                bool didItWork = int.TryParse(inputAsString, out int input);

                if (didItWork)
                {

                    newBadge.DoorNames.Add(_doorList[input - 1].DoorName);
                    Console.WriteLine("Would you like to add access to an additional door? Y/N?");
                    if (Console.ReadLine().ToLower().Contains("n"))
                    {
                        isTrue = true;
                    }
                }

            }
            _badgeRepository.AddBadgeToDictionary(newBadge.BadgeNumber, newBadge);
        }

        //Update Existing Badge
        private void UpdateExistingBadge()
        {

            DisplayAllBadgeNumbers();
            Console.WriteLine("Enter the number of the ID you want to change");
            string answer = Console.ReadLine();
            bool isParsed = int.TryParse(answer, out int answerAsInt);
            if (isParsed)
            {
                Badge toChange = _badgeRepository.GetBadgeByBadgeNumber(answerAsInt);
                if (toChange != null)
                {
                    Console.WriteLine("What would you like to do?\n\n" +
                        "1. Remove a door.\n" +
                        "2. Add a door.");
                    string answer2 = Console.ReadLine();

                    switch (answer2)
                    {
                        case "1":
                            //Remove door
                            Console.WriteLine("Please select door to remove");

                            for (int i = 0; i < toChange.DoorNames.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}   {toChange.DoorNames[i]}");
                            }
                            string selectionAsString = Console.ReadLine();
                            int selection = int.Parse(selectionAsString);
                            toChange.DoorNames.RemoveAt(selection - 1);
                            break;
                        case "2":
                            //Add Door
                            Console.WriteLine("Please select the door you would like to add access to.");
                            for (int i = 0; i < _doorList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}   {_doorList[i].DoorName}");
                            }

                            string selectionAsString2 = Console.ReadLine();
                            int selection2 = int.Parse(selectionAsString2);
                            toChange.DoorNames.Add(_doorList[selection2 - 1].DoorName);
                            break;
                        default:
                            Console.WriteLine("Not a valid selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There is no badge with that number.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Not a valid selection. Press enter to continue");
                Console.ReadLine();
            }
        }

        //Display All Badges
        private Dictionary<int, Badge> DisplayAllBadgeNumbers()
        {
            Dictionary<int, Badge> badgeList = _badgeRepository.GetDictionary();
            Console.WriteLine("Badge Number   Doors Accessed\n");
            foreach (KeyValuePair<int, Badge> kvp in badgeList)
            {
                //for (int i = 0; i < kvp.Value.DoorNames.Count; i++)
                //{

                    Console.Write($"    {kvp.Key}         ");
                    foreach (string str in kvp.Value.DoorNames)
                    {
                        Console.Write(str + ", ");
                    }
                        Console.WriteLine("\n");
                //}
            }
            return badgeList;
        }

        private void SeedMethod()
        {

            //Create a bunch of doors
            Door A1 = new Door("A1");
            Door A2 = new Door("A2");
            Door A3 = new Door("A3");
            Door A4 = new Door("A4");
            Door A5 = new Door("A5");
            Door B1 = new Door("B1");
            Door B2 = new Door("B2");
            Door B3 = new Door("B3");
            Door B4 = new Door("B4");
            Door B5 = new Door("B5");
            Door C1 = new Door("C1");
            Door C2 = new Door("C2");
            Door C3 = new Door("C3");
            Door C4 = new Door("C4");

            //Add doors to door list
            _doorList.Add(A1);
            _doorList.Add(A2);
            _doorList.Add(A3);
            _doorList.Add(A4);
            _doorList.Add(A5);
            _doorList.Add(B1);
            _doorList.Add(B2);
            _doorList.Add(B3);
            _doorList.Add(B4);
            _doorList.Add(B5);
            _doorList.Add(C1);
            _doorList.Add(C2);
            _doorList.Add(C3);
            _doorList.Add(C4);

            Badge badge1 = new Badge();
            badge1.DoorNames.Add(A1.DoorName);
            badge1.DoorNames.Add(A2.DoorName);
            badge1.DoorNames.Add(C3.DoorName);
            _badgeRepository.AddBadgeToDictionary(123, badge1);
            Badge badge2 = new Badge();
            badge2.DoorNames.Add(B3.DoorName);
            badge2.DoorNames.Add(C1.DoorName);
            badge2.DoorNames.Add(A5.DoorName);
            _badgeRepository.AddBadgeToDictionary(124, badge2);
            Badge badge3 = new Badge();
            badge3.DoorNames.Add(C1.DoorName);
            badge3.DoorNames.Add(A2.DoorName);
            badge3.DoorNames.Add(B3.DoorName);
            _badgeRepository.AddBadgeToDictionary(125, badge3);
            
        }
    }
}
