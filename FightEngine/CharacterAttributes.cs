
namespace FightEngine
{
    public class CharacterAttributes
    {
        public int AttackPoints { get; set; }
        public int DefendPoints { get; set; }

        public static CharacterAttributes operator +(CharacterAttributes c1, CharacterAttributes c2)
        {
            return new CharacterAttributes
            {
                AttackPoints = c1.AttackPoints + c2.AttackPoints,
                DefendPoints = c1.DefendPoints + c2.DefendPoints
            };
        }

        public static CharacterAttributes operator -(CharacterAttributes c1)
        {
            return new CharacterAttributes
            {
                AttackPoints = -c1.AttackPoints,
                DefendPoints = -c1.DefendPoints
            };
        }        
    }
}
