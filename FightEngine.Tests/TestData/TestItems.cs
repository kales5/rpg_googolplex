using FightEngine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Tests.TestData
{
    public class TestItems
    {
        public ConsumableItem HealthPotion = new ConsumableItem
        {
            Name = "HealthPoition",
            Description = "Regains some Healt",
            FluentAttributesEffekts = new CharacterFluentAttributes
            {
                LifePoints = 6
            },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid")
                }
        };

        public StaticItem Sword = new StaticItem
        {
            Name = "Sword",
            Description = "A Badass Sword",
            AttributesEffekts = new CharacterAttributes
            {
                AttackPoints = 3
            },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid"),
                    new Claim(RpgClaimTypes.Extremities, "Hand")
                }
        };

        public StaticItem ElvishAmulet = new StaticItem
        {
            Name = "ElvishAmulet",
            Description = "A Might Amulett",
            AttributesEffekts = new CharacterAttributes
            {
                AttackPoints = 3,
            },
            FluentAttributesEffekts = new CharacterFluentAttributes { LifePoints = 5 },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid"),
                    new Claim(RpgClaimTypes.Race, "Elve")
                }
        };
        public StaticItem AmuletOfLife = new StaticItem
        {
            Name = "AmuletOfLife",
            Description = "A Might Amulett",
            FluentAttributesEffekts = new CharacterFluentAttributes { LifePoints = 5 },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid")
                }
        };
        public StaticItem AmuletOfDead = new StaticItem
        {
            Name = "AmuletOfDead",
            Description = "A Might Amulett",
            FluentAttributesEffekts = new CharacterFluentAttributes { LifePoints = -7 },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid")
                }
        };

        public StaticItem Axe = new StaticItem
        {
            Name = "Sword",
            Description = "A Badass Sword",
            AttributesEffekts = new CharacterAttributes
            {
                AttackPoints = 3,
                DefendPoints = -1
            },
            Requirements = new List<System.Security.Claims.Claim>
                {
                    new Claim(RpgClaimTypes.Type, "Humanoid"),
                    new Claim(RpgClaimTypes.Extremities, "Hand")
                }
        };
    }
}
