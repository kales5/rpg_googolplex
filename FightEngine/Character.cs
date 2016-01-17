namespace FightEngine
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Items;
    public class Character
    {
        public String Name { get; set; }
        public List<Item> Inventory { get; set; }

        public List<StaticItem> Eqipped { get; private set; }

        public CharacterAttributes Attributes { get; set; }

        public CharacterFluentAttributes BaseFluentAttributes { get; set; }

        public CharacterFluentAttributes CurrentFluentAttributes { get; set; }

        public List<Claim> Features { get; set; }

        public void Eqip(StaticItem item)
        {
            throw new NotImplementedException();
        }

        public virtual CharacterAttributes GetModifiedAttributes()
        {
            throw new NotImplementedException();
        }
        public virtual CharacterFluentAttributes GetModifiedFluentAttributes()
        {
            throw new NotImplementedException();
        }

        public void Attack(Character enemy)
        {
            throw new NotImplementedException();
        }
        public void Defend(int attackPoints)
        {
            throw new NotImplementedException();
        }

        public void Consume(Item item)
        {

        }     

    }
}
