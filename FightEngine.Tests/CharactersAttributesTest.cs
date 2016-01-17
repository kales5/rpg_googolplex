using FightEngine.Tests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FightEngine.Tests
{
   public class CharactersAttributesTest
    {
        public static object[] AddingTestData = new[]
        {
            new object[]
            {
                new CharacterAttributes { AttackPoints = 5, DefendPoints = 3},
                 new CharacterAttributes { AttackPoints = 4, DefendPoints = 2},
                  9, 5
            },
            new object[]
            {
                new CharacterAttributes { AttackPoints = 5, DefendPoints = 3},
                 new CharacterAttributes { AttackPoints = -5, DefendPoints = -3},
                   0, 0
            },
            new object[]
            {
                new CharacterAttributes { AttackPoints = 5, DefendPoints = 3},
                 new CharacterAttributes { AttackPoints = -8, DefendPoints = 3},
                   -3, 6
            },
            new object[]
            {
                new CharacterAttributes { AttackPoints = 5, DefendPoints = 3},
                 new CharacterAttributes { AttackPoints = 0, DefendPoints = 0},
                   5, 3
            },
            new object[]
            {
                new CharacterAttributes { AttackPoints = 5, DefendPoints = 3},
                 new CharacterAttributes (),
                  5,3
            }
        };

        [Theory, MemberData(nameof(AddingTestData))]
        public void AddingTest(CharacterAttributes c1, CharacterAttributes c2, int expectedAttacPoints, int expectedDefensePoints)
        {
            (c1 + c2).AttackPoints.Should().Be(expectedAttacPoints);
            (c1 + c2).DefendPoints.Should().Be(expectedDefensePoints);
        }

        public static object[] AddingNullTestData = new[]
       {
            new object[] {null, null},
            new object[] {null, new CharacterAttributes ()},
            new object[] { new CharacterAttributes(), null},
        };

        [Theory]
        [MemberData(nameof(AddingNullTestData))]
        public void AddingNullTest(CharacterAttributes c1, CharacterAttributes c2)
        {
             Action adding = () => {var e = c1 + c2; };
            adding.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void MinusTest()
        {
            var testdata = new CharacterAttributes { AttackPoints = 5, DefendPoints = 3 };
            (-testdata).AttackPoints.Should().Be(-5);
            (-testdata).DefendPoints.Should().Be(-3);
        }
        [Fact]
        public void MinusNullTest()
        {
            CharacterAttributes testData = null;
            Action minus = () => { var e = -testData; };
            minus.ShouldThrow<NullReferenceException>();
        }
    }
}
