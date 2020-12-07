
using _01_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Claims
{
    public class UI
    {
        private readonly ClaimRepository _claimRepository = new ClaimRepository();
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
                //Display our options to the user
                Console.WriteLine("Select a Menu Option:\n\n" +
                    "1. See all claims.\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit program");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Display all Claims in the Queue
                        DisplayAllClaims();
                        break;
                    case "2":
                        //Take care of the next claim
                        TakeCareOfClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        CreateClaim();
                        break;
                    case "4":
                        //Exit program
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Display all claims in queue
        private Queue<Claim> ShowClaimQueue()
        {
            Console.Clear();

            Queue<Claim> claimQueue = _claimRepository.GetClaimList();
            Console.WriteLine("Claim ID     Type        Description     Amount      DateOfAccident      DateOfClaim     IsValid\n");
            foreach (Claim claim in claimQueue)
            {
                Console.WriteLine($"{claim.ClaimNumber}.    {claim.ClaimType}   {claim.Description}     ${claim.ClaimAmount}    {claim.DateOfIncident}  {claim.DateOfClaim}     {claim.IsValid}");
            }

            return claimQueue;
        }

        private Queue<Claim> DisplayAllClaims()
        {
            //Build out containers for each data collection
            List<int> _claimNumbers = new List<int>();
            List<ClaimType> _claimTypes = new List<ClaimType>();
            List<string> _descriptions = new List<string>();
            List<double> _claimAmounts = new List<double>();
            List<DateTime> _dateOfAccidents = new List<DateTime>();
            List<DateTime> _dateOfClaims = new List<DateTime>();
            List<bool> _isValids = new List<bool>();

            //Fill those dontainers with contents
            Queue<Claim> claimQueue = _claimRepository.GetClaimList();
            foreach (Claim claim in claimQueue)
            {
                _claimNumbers.Add(claim.ClaimNumber);
                _claimTypes.Add(claim.ClaimType);
                _descriptions.Add(claim.Description);
                _claimAmounts.Add(claim.ClaimAmount);
                _dateOfAccidents.Add(claim.DateOfIncident);
                _dateOfClaims.Add(claim.DateOfClaim);
                _isValids.Add(claim.IsValid);
            }
            //Display contents of each item in Queue. Formatted. Aligned left.
            var display = new System.Text.StringBuilder();
            display.Append(String.Format("{0,-10} {1,-10} {2,-60} {3,-10} {4,-15} {5,-15} {6,-10}\n", "Number", "Type", "Description", "Amount", "Incident Date", "Date of Claim", "Is Claim Valid"));

            for (int index = 0; index < _claimNumbers.Count; index++)
                display.Append(String.Format("{0,-10} {1,-10} {2,-60} {3,-10} {4,-15} {5,-15} {6,-10}\n", _claimNumbers[index], _claimTypes[index], _descriptions[index], _claimAmounts[index], _dateOfAccidents[index].ToShortDateString(), _dateOfClaims[index].ToShortDateString(), _isValids[index]));
            Console.WriteLine(display);

            return claimQueue;
        }


        //Take care of next claim
        private void TakeCareOfClaim()
        {
            //Get claim list
            Queue<Claim> claims = DisplayAllClaims();
            Console.WriteLine("Please press enter to process first claim");
            Console.ReadLine();

            //Display claim to be handled
            Claim firstOnList = claims.First<Claim>();
            Console.WriteLine($"ClaimID: {firstOnList.ClaimNumber}\n\n" +
                $"Type: {firstOnList.ClaimType}\n\n" +
                $"Description: {firstOnList.Description}\n\n" +
                $"Amount: ${firstOnList.ClaimAmount}\n\n" +
                $"DateOfAccident: {firstOnList.DateOfIncident}\n\n" +
                $"DateOfClaim: {firstOnList.DateOfClaim}\n\n" +
                $"IsValid: {firstOnList.IsValid}");

            //I dont think I needed to do the above because dequeue should return my claim, but I figured that out after I wrote this code, and well, this works too.


            //Dequeue
            Claim claimToTakeCareOf = claims.Dequeue();

            //Check if valid by IsValid and amount of days between incident and claim
            TimeSpan hasItBeenThirtyDays = claimToTakeCareOf.DateOfClaim - claimToTakeCareOf.DateOfIncident;
            if (claimToTakeCareOf.IsValid)
            {
                if (hasItBeenThirtyDays.TotalDays <= 30)
                {
                    Console.WriteLine($"Write a check for ${claimToTakeCareOf.ClaimAmount}\n" +
                        $"This claim has been stored in the 'paid claims' file");
                }
                else
                {
                    Console.WriteLine("This claim is not valid. This claim has been filed in the 'denied due to exceeds time limit' file");

                }
            }
            else
            {
                Console.WriteLine("This claim is not valid. This claim has been filed in the 'denied due to invalid' list");
            }
            //Create repo for denied/accepted claims?
        }


        //Create a new claim
        private void CreateClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //Claim Type
            //Console.WriteLine();

            //Claim Description
            Console.WriteLine("Enter a description of the incident");
            newClaim.Description = Console.ReadLine();

            //Claim Type
            int input = -1;
            bool isTrue = false;
            while (isTrue == false)
            {
                Console.WriteLine("What is the type of incident? Enter the number for your choice\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");

                string inputAsString = Console.ReadLine();

                isTrue = int.TryParse(inputAsString, out input);


                switch (input)
                {
                    case 1:
                        newClaim.ClaimType = ClaimType.Car;
                        isTrue = true;
                        break;
                    case 2:
                        newClaim.ClaimType = ClaimType.Home;
                        isTrue = true;
                        break;
                    case 3:
                        newClaim.ClaimType = ClaimType.Theft;
                        isTrue = true;
                        break;
                    default:
                        Console.WriteLine("You did not choose a valid option, please choose 1, 2, or 3");
                        break;
                }
            }

            //Claim Amount
            double input2 = -1;
            bool isFalse = false;
            while (isFalse == false)
            {
                Console.WriteLine("Enter the amount of the claim");
                string amountAsString = Console.ReadLine();
                isFalse = double.TryParse(amountAsString, out input2);
                newClaim.ClaimAmount = input2;
            }


            //Date of Incident
            Console.Clear();
            Console.WriteLine("Next you will be entering information for the date of the incident. Please press Enter to continue");
            Console.ReadLine();

            //month
            int incidentMonth = GetMonthNumber();

            //year
            int incidentYear = GetYear();

            //day of month
            int incidentDay = GetDateNumber(incidentMonth, incidentYear);

            //Compile Date of incident
            DateTime dateOfIncident = new DateTime(incidentYear, incidentMonth, incidentDay);
            newClaim.DateOfIncident = dateOfIncident;

            //Date of Claim
            Console.Clear();
            Console.WriteLine("Now you will be entering the date of the claim");
            //month
            int claimMonth = GetMonthNumber();

            //year
            int claimYear = GetYear();

            //day of month
            int claimDay = GetDateNumber(claimMonth, claimYear);

            //Compile Date of claim
            DateTime dateOfClaim = new DateTime(claimYear, claimMonth, claimDay);
            newClaim.DateOfClaim = dateOfClaim;


            //Is Valid
            Console.WriteLine("Is this claim valid? Y/N?");
            if (Console.ReadLine().ToLower().Contains("y"))
            {
                newClaim.IsValid = true;
            }
            newClaim.IsValid = false;

            _claimRepository.AddClaimToList(newClaim);
        }


        //Helper Methods Go Below
        private int GetMonthNumber()
        {

            while (true)
            {
                int month = -1;
                bool didItWork = false;
                while (didItWork == false)
                {
                    Console.WriteLine("\n\nPlease enter the number for the correct month");
                    Console.WriteLine("1. January\n" +
                       "2. February\n" +
                       "3. March\n" +
                       "4. April\n" +
                       "5. May\n" +
                       "6. June\n" +
                       "7. July\n" +
                       "8. August\n" +
                       "9. September\n" +
                       "10. October\n" +
                       "11. November\n" +
                       "12. December");

                    string monthAsString = Console.ReadLine();

                    didItWork = int.TryParse(monthAsString, out month);
                }

                if (month >= 1 && month <= 12)
                {
                    Console.WriteLine($"Are you sure you wanted to choose {month}? Y/N?");

                    if (Console.ReadLine().ToLower().Contains("y"))
                    {
                        return month;
                    }
                }
                else
                {
                    Console.WriteLine("That is an invalid option. Press Enter to try again");
                    Console.ReadLine();
                    Console.Clear();

                }
            }
        }

        private int GetDateNumber(int month, int year)
        {
            while (true)
            {
                int dayOfIncident = -1;
                bool didItWork = false;
                while (didItWork == false)
                {
                    Console.WriteLine("\n\nPlease enter the day of the month");
                    didItWork = int.TryParse(Console.ReadLine(), out dayOfIncident);

                    if (didItWork == false)
                    {
                        Console.WriteLine("You entered an invalid option, press enter to try again");
                        Console.ReadLine();
                    }
                }

                Console.WriteLine($"Are you sure you wanted to input {dayOfIncident} Y/N?");
                string answer = Console.ReadLine();

                if (dayOfIncident > 0 && dayOfIncident <= DateTime.DaysInMonth(year, month))
                {
                    if (answer.ToLower().Contains("y"))
                    {
                        return dayOfIncident;
                    }
                }
            }
        }

        public int GetYear()
        {
            while (true)
            {
                int yearOfIncident = -1;
                bool didItWork = false;
                while (didItWork == false)
                {
                    Console.WriteLine("\n\nPlease enter the correct year (YYYY)");
                    didItWork = int.TryParse(Console.ReadLine(), out yearOfIncident);

                    if (didItWork == false)
                    {
                        Console.WriteLine("invalid input for year, please format your year with 4 digits (yyyy). Press Enter to try again");
                        Console.ReadLine();
                    }
                }

                Console.WriteLine($"Are you sure you wanted to input {yearOfIncident} Y/N?");

                string answer = Console.ReadLine();

                if (answer.ToLower().Contains("y"))
                {
                    return yearOfIncident;
                }
            }
        }


        //Seed Method
        private void SeedMethod()
        {
            Claim claim1 = new Claim(ClaimType.Car, "worst accident ever", 67.42, new DateTime(2020, 10, 10), new DateTime(2020, 10, 15), true);
            Claim claim2 = new Claim(ClaimType.Theft, "stupid thief took my headphones", 150, new DateTime(2020, 4, 12), new DateTime(2020, 5, 18), false);
            Claim claim3 = new Claim(ClaimType.Home, "A big branch went through my window", 600, new DateTime(2019, 5, 22), new DateTime(2019, 6, 1), true);
            Claim claim4 = new Claim(ClaimType.Car, "Dude was eating a burger and rammed my backside (gross)", 1500.43, new DateTime(2020, 1, 1), new DateTime(2020, 2, 1), true);

            _claimRepository.AddClaimToList(claim1);
            _claimRepository.AddClaimToList(claim2);
            _claimRepository.AddClaimToList(claim3);
            _claimRepository.AddClaimToList(claim4);


        }
    }
}
