using FightEngine.Tests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace FightEngine.Tests.CharacterTest
{
    public class CharacterDefendTest
    {
        [Theory]
        [InlineData(7, 3)]
        [InlineData(5, 5)]
        [InlineData(2, 5)]
        [InlineData(-5, 5)]
        [InlineData(12, -2)]
        public void Defend_HumanDefends(int attackPoints, int expectedLifePoint)
        {
            var human = new TestCharacters().InjuerdHuman;

            human.Defend(attackPoints);
            human.CurrentFluentAttributes.LifePoints.Should().Be(expectedLifePoint);
        }

        [Fact]
        public void Defend_EmptyCharacter()
        {
            var empty = new Character();
            Action defend = () => empty.Defend(4);
            defend.ShouldThrow<ArgumentNullException>().WithMessage($"{nameof(empty.Attributes)} is Null!");
        }
    }
}
