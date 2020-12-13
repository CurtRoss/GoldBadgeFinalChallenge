using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ClaimsRepository
{
    public class ClaimRepository
    {
        //Create field to hold all existing Claims
        private readonly Queue<Claim> _claimDirectory = new Queue<Claim>();

        //Claim Create
        public void AddClaimToList(Claim claim)
        {
            _claimDirectory.Enqueue(claim);
        }

        //Read Claim List
        public Queue<Claim> GetClaimList()
        {
            return _claimDirectory;
        }

        //Claim Update
        //public bool UpdateExistingClaim(int originalClaim, Claim newClaim)
        //{
        //    Claim oldClaim = GetClaimByClaimNumber(originalClaim);

        //    if(oldClaim != null)
        //    {
        //        oldClaim.ClaimAmount = newClaim.ClaimAmount;
        //        oldClaim.ClaimType = newClaim.ClaimType;
        //        oldClaim.DateOfIncident = newClaim.DateOfIncident;
        //        oldClaim.Description = newClaim.Description;
        //        oldClaim.IsValid = newClaim.IsValid;
        //        oldClaim.DateOfClaim = newClaim.DateOfClaim;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete Claim
        //public bool DeleteClaimByClaimnumber(int claimNumber)
        //{
        //    Claim claimToDelete = GetClaimByClaimNumber(claimNumber);
        //    if (claimToDelete == null)
        //    {
        //        return false;
        //    }

        //    //remove claim from queue by claim number
        //    int initialCount = _claimDirectory.Count;

        //    //Create new queue to replace old queue
        //    Queue<Claim> newQueue = new Queue<Claim>();

        //    //rewrites queue without the claim you deleted
        //    newQueue.Where(x => x != claimToDelete);

        //    if (initialCount > _claimDirectory.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Helper Method
        //public Claim GetClaimByClaimNumber(int claimNumber)
        //{
        //    foreach (Claim claim in _claimDirectory)
        //    {
        //        if (claim.ClaimNumber == claimNumber)
        //        {
        //            return claim;
        //        }
        //    }
        //    return null;
        //}
    }
}
