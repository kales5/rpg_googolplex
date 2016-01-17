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
    }
}
