using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine
{
    public class CharacterFluentAttributes
    {
        public int LifePoints { get; set; }
        public static CharacterFluentAttributes operator +(CharacterFluentAttributes c1, CharacterFluentAttributes c2)
        {
            return new CharacterFluentAttributes
            {
                LifePoints = c1.LifePoints + c2.LifePoints
            };
        }

        public static CharacterFluentAttributes operator -(CharacterFluentAttributes c1)
        {
            return new CharacterFluentAttributes
            {
                LifePoints = -c1.LifePoints
            };
        }

        public void AddAttributesWithMaximum(CharacterFluentAttributes addableAttirbutes, CharacterFluentAttributes maximumAttributes)
        {
            this.LifePoints += addableAttirbutes.LifePoints;

            if(this.LifePoints > maximumAttributes.LifePoints)
            {
                this.LifePoints = maximumAttributes.LifePoints;
            }
        }
    }
}
