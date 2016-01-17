using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Tests.TestData
{
    public class TestCharacters
    {
        public Character InjuerdHuman = new Character
        {
            Name = "Herbert",
            CurrentFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 5
            },
            BaseFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 15
            },
            Attributes = new CharacterAttributes
            {
                AttackPoints = 5,
                DefendPoints = 5
            },
            Inventory = new List<Items.Item>
            {
                new TestItems().HealthPotion
            },
            Features = new List<Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid"),
                    new Claim(RpgClaimTypes.Race, "Human"),
                    new Claim(RpgClaimTypes.Extremities, "Hand"),
                    new Claim(RpgClaimTypes.Extremities, "Hand"),
                    new Claim(RpgClaimTypes.Extremities, "HumanoidTorso"),
                    new Claim(RpgClaimTypes.Extremities, "Head"),
                }
        };

        public Character Elve = new Character
        {
            Name = "Kales",
            CurrentFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 13
            },
            BaseFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 13
            },
            Attributes = new CharacterAttributes
            {
                AttackPoints = 6,
                DefendPoints = 4
            },
            Features = new List<Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid"),
                    new Claim(RpgClaimTypes.Race, "Elve"),
                    new Claim(RpgClaimTypes.Extremities, "Hand"),
                    new Claim(RpgClaimTypes.Extremities, "Hand"),
                    new Claim(RpgClaimTypes.Extremities, "HumanoidTorso"),
                    new Claim(RpgClaimTypes.Extremities, "Head"),
                }
        };
        public Character Wolf = new Character
        {
            CurrentFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 5
            },
            BaseFluentAttributes = new CharacterFluentAttributes
            {
                LifePoints = 9
            },
            Attributes = new CharacterAttributes
            {
                AttackPoints = 7,
                DefendPoints = 5
            },
            Features = new List<Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Monster"),
                    new Claim(RpgClaimTypes.Race, "Wolf")
                }
        };
    }
}
