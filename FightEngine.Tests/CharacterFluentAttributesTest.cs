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
    public class CharacterFluentAttributesTest
    {
        public static object[] AddingTestData = new[]
       {
            new object[]
            {
                new CharacterFluentAttributes { LifePoints = 5,},
                 new CharacterFluentAttributes { LifePoints = 4},
                  9
            },
            new object[]
            {
                new CharacterFluentAttributes { LifePoints = 5},
                 new CharacterFluentAttributes { LifePoints = -5},
                   0
            },
            new object[]
            {
                new CharacterFluentAttributes { LifePoints = 5},
                 new CharacterFluentAttributes { LifePoints = -8 },
                   -3
            },
            new object[]
            {
                new CharacterFluentAttributes { LifePoints = 5},
                 new CharacterFluentAttributes { LifePoints = 0},
                   5
            },
            new object[]
            {
                new CharacterFluentAttributes { LifePoints = 5},
                 new CharacterFluentAttributes (),
                  5
            }
        };

        [Theory, MemberData(nameof(AddingTestData))]
        public void AddingTest(CharacterFluentAttributes c1, CharacterFluentAttributes c2, int expectedLifePoints)
        {
            (c1 + c2).LifePoints.Should().Be(expectedLifePoints);
        }

        public static object[] AddingNullTestData = new[]
       {
            new object[] {null, null},
            new object[] {null, new CharacterFluentAttributes()},
            new object[] { new CharacterFluentAttributes(), null},
        };

        [Theory]
        [MemberData(nameof(AddingNullTestData))]
        public void AddingNullTest(CharacterFluentAttributes c1, CharacterFluentAttributes c2)
        {
            Action adding = () => { var e = c1 + c2; };
            adding.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void MinusTest()
        {
            var testdata = new CharacterFluentAttributes { LifePoints = 5 };
            (-testdata).LifePoints.Should().Be(-5);
        }
        [Fact]
        public void MinusNullTest()
        {
            CharacterFluentAttributes testData = null;
            Action minus = () => { var e = -testData; };
            minus.ShouldThrow<NullReferenceException>();
        }
    }
}
