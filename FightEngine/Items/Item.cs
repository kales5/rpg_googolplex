namespace FightEngine.Items
{
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    public abstract class Item
    {
        public List<Claim> Requirements { get; set; }
        
        public String Name { get; set; }

        public String Description { get; set; } 
        
        public void CheckRequirements(List<Claim> features)
        {
            if (Requirements.Any(requierdClaim =>
                 !features.Any(featuredClaim => featuredClaim.Type == requierdClaim.Type
                                                     && featuredClaim.Value == requierdClaim.Value)
            ))
            {
                throw new WrongRequirementException();
            }
            var requierdSlots = Requirements.Where(c => c.Type == RpgClaimTypes.Slot);
            var availableSlots = features.Where(c => c.Type == RpgClaimTypes.Slot);
            if (requierdSlots.Any(rqs=> availableSlots.Count(avs=>avs.Value == rqs.Value) < requierdSlots.Count(rs=>rs.Value == rqs.Value)))
            {
                throw new WrongRequirementException();
            }
        } 
    }
}
