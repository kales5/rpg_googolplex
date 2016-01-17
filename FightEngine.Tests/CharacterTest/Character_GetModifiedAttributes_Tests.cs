using FightEngine.Exceptions;
using FightEngine.Items;
using FightEngine.Tests.TestData;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace FightEngine.Tests.CharacterTest
{
    public class Character_GetModifiedAttributes_Tests
    {
        [Fact]
        public void GetModifiedAttributes_SwordEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;
            var sword = new TestItems().Sword;
            human.Eqip(sword);

            var testData = human.GetModifiedAttributes();

            testData.AttackPoints.Should().Be(8);
            testData.DefendPoints.Should().Be(5);
        }

        [Fact]
        public void GetModifiedAttributes_SeveralEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;
            var sword = new TestItems().Sword;
            var axe = new TestItems().Axe;
            human.Eqip(sword);
            human.Eqip(axe);

            var testData = human.GetModifiedAttributes();

            testData.AttackPoints.Should().Be(11);
            testData.DefendPoints.Should().Be(4);
        }

        [Fact]
        public void GetModifiedAttributes_NothingEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;

            var testData = human.GetModifiedAttributes();

            testData.AttackPoints.Should().Be(5);
            testData.DefendPoints.Should().Be(5);
        }
    }
}
