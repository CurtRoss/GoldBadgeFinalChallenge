using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ClaimsRepository
{
    //sets up an enum so that when we get to property type 'ClaimType' it only has the choices from the enum
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claim
    {
        private static int count = 151432;
        public int ClaimNumber { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim()
        {
            count++;
            ClaimNumber = count;
        }

        public Claim(ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime timeOfClaim, bool isValid)
        {
            count++;
            ClaimNumber = count;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = timeOfClaim;
            IsValid = isValid;
        }
    }
}
