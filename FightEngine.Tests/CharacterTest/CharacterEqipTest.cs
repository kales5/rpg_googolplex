using FightEngine.Exceptions;
using FightEngine.Items;
using FightEngine.Tests.TestData;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace FightEngine.Tests.CharacterTest
{
    
    public class CharacterEqipTest
    {
        [Fact]
        public void Eqip_Sword()
        {
            var human = new TestCharacters().InjuerdHuman;
            var sword = new TestItems().Sword;

            human.Eqip(sword);
            human.Eqipped.Should().BeEquivalentTo(new List<StaticItem> { sword });
        }

        [Fact]
        public void Eqip_Amulet()
        {
            var elve = new TestCharacters().Elve;
            var amulet = new TestItems().ElvishAmulet;

            elve.Eqip(amulet);
            elve.Eqipped.Should().BeEquivalentTo(new List<StaticItem> { amulet });
        }

        [Fact]
        public void Eqip_InvalidItem()
        {
            var human = new TestCharacters().InjuerdHuman;
            var amulet = new TestItems().ElvishAmulet;

           Assert.Throws<WrongRequirementException>(()=> human.Eqip(amulet));           
        }

        [Fact]
        public void Eqip_ToMuch()
        {
            var human = new TestCharacters().InjuerdHuman;
            var sword = new TestItems().Sword;

            human.Eqip(sword);
            human.Eqip(sword);
            Assert.Throws<WrongRequirementException>(() => human.Eqip(sword));
        }
        [Fact]
        public void Eqip_Several()
        {
            var elve = new TestCharacters().Elve;
            var amulet = new TestItems().ElvishAmulet;
            var sword = new TestItems().Sword;
            var axe = new TestItems().Axe;

            elve.Eqip(sword);
            elve.Eqip(axe);
            elve.Eqip(amulet);
            elve.Eqipped.Should().BeEquivalentTo(new List<StaticItem> { amulet, sword, axe });
        }
        [Fact]
        public void Eqip_twice()
        {
            var elve = new TestCharacters().Elve;
            
            var sword = new TestItems().Sword;

            elve.Eqip(sword);
            elve.Eqip(sword);
            elve.Eqipped.Should().BeEquivalentTo(new List<StaticItem> { sword, sword});
        }
    }
}
