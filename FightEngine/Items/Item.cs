namespace FightEngine.Items
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    public abstract class Item
    {
        public List<Claim> Requirements { get; set; }
        
        public String Name { get; set; }

        public String Description { get; set; }        
    }
}
