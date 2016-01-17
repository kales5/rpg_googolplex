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
    public class Character_GetModifiedFluentAttributes_Tests
    {
        [Fact]
        public void GetModifiedFluentAttributes_AmuelettEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;
            var amulett = new TestItems().AmuletOfLife;
            human.Eqip(amulett);

            var testData = human.GetModifiedFluentAttributes();

            testData.LifePoints.Should().Be(20);
        }

        [Fact]
        public void GetModifiedFluentAttributes_SeveralEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;
            var amuletOfLife = new TestItems().AmuletOfLife;
            var amulettOfDead = new TestItems().AmuletOfDead;
            human.Eqip(amuletOfLife);
            human.Eqip(amulettOfDead);

            var testData = human.GetModifiedFluentAttributes();

            testData.LifePoints.Should().Be(13);
        }

        [Fact]
        public void GetModifiedFluentAttributes_NothingEquipped()
        {
            var human = new TestCharacters().InjuerdHuman;

            var testData = human.GetModifiedFluentAttributes();

            testData.LifePoints.Should().Be(15);
        }

    }
}
