namespace FightEngine
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Items;
    using System.Linq;
    using Exceptions;
    using System.Security.Cryptography;
    public class Character
    {
        public String Name { get; set; }
        public List<Item> Inventory { get; set; }

        public List<StaticItem> Eqipped { get; private set; }

        public CharacterAttributes Attributes { get; set; }

        public CharacterFluentAttributes BaseFluentAttributes { get; set; }

        public CharacterFluentAttributes CurrentFluentAttributes { get; set; }

        public List<Claim> Features { get; set; }
        public Character()
        {
            Eqipped = new List<StaticItem>();
            Inventory = new List<Item>();
            
        }

        public void Eqip(StaticItem item)
        {
            var features = Features.Where(claim => claim.Type != RpgClaimTypes.Slot).ToList();
            var baseSlots = Features.Where(c => c.Type == RpgClaimTypes.Slot).GroupBy(c=>c.Value);
            var takenSlots = Eqipped.SelectMany(i => i.Requirements).Where(c => c.Type == RpgClaimTypes.Slot);
            foreach (var group in baseSlots)
            {
                features.AddRange(group.Skip(takenSlots.Count(c=>c.Value == group.Key)));
            }           

            item.CheckRequirements(features);

            Eqipped.Add(item);

        }

        public virtual CharacterAttributes GetModifiedAttributes()
        {
            var combinedAttributesEffect = new CharacterAttributes();            
            foreach (var item in Eqipped)
            {
                combinedAttributesEffect += item.AttributesEffekts;
            }
            return combinedAttributesEffect + Attributes;
        }

        public virtual CharacterFluentAttributes GetModifiedFluentAttributes()
        {
            var combinedFluentAttributesEffect = new CharacterFluentAttributes();
            foreach(var item in Eqipped)
            {
                combinedFluentAttributesEffect += item.FluentAttributesEffekts; 
            }
            return combinedFluentAttributesEffect + BaseFluentAttributes;
        }

        public void Attack(Character enemy)
        {
            if(enemy == this)
            {
                throw new InvalidOperationException("Character can not Attack it self!");
            }
            var modifiedAttributes = GetModifiedAttributes();
            enemy.Defend(modifiedAttributes.AttackPoints + new Random().Next(1, 6));
        }

        public void Defend(int attackPoints)
        {
            var modifiedAttributes = GetModifiedAttributes();
            if(modifiedAttributes.DefendPoints >= attackPoints)
            {
                return;
            }

            CurrentFluentAttributes.LifePoints -= (attackPoints - modifiedAttributes.DefendPoints);
        }

        public void Consume(ConsumableItem item)
        {
            if(!Inventory.Any(i => i == item))
            {
                throw new InvalidOperationException($"The Character ({Name}) has not this Item: {item.Name}");
            }
            Inventory.Remove(item);
            item.Apply(this);
        }     

    }
}
