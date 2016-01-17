using FightEngine.Exceptions;
using FightEngine.Items;
using FightEngine.Tests.TestData;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace FightEngine.Tests.Item
{
   public class ConsumableItemTests
    {
       
        [Fact]
        public void Apply_useHeathPoition()
        {
            var healthPotion = new TestItems().HealthPotion;
            var injuerdHuman = new TestCharacters().InjuerdHuman;
            healthPotion.Apply(injuerdHuman);

            injuerdHuman.CurrentFluentAttributes.LifePoints.Should().Be(11);
        }

        [Fact]
        public void Apply_useHeathPoitionToGetMaxLife()
        {
            var healthPotion = new TestItems().HealthPotion;
            var injuerdHuman = new TestCharacters().InjuerdHuman;

            healthPotion.Apply(injuerdHuman);
            healthPotion.Apply(injuerdHuman);
            injuerdHuman.CurrentFluentAttributes.LifePoints.Should().Be(15);
        }

        [Fact]
        public void Apply_useHeathPoitionOnWrongCharacter()
        {
            var healthPotion = new TestItems().HealthPotion;
            var wolf = new TestCharacters().Wolf;

            Assert.Throws<WrongRequirementException>(()=> healthPotion.Apply(wolf));
        }

        [Fact]
        public void Apply_useHeathPoitionOnHealthyCharcater()
        {
            var healthPotion = new TestItems().HealthPotion;
            var elve = new TestCharacters().Elve;

            healthPotion.Apply(elve);

            elve.CurrentFluentAttributes.LifePoints.Should().Be(13);
        }


        [Fact]
        public void Apply_useHeathPoitionDependsOnModifiedFluidAttributes()
        {
            var healthPotion = new TestItems().HealthPotion;
            var elve = Substitute.For<Character>();
            var baseElve = new TestCharacters().Elve;
            elve.BaseFluentAttributes = baseElve.BaseFluentAttributes;
            elve.CurrentFluentAttributes = baseElve.CurrentFluentAttributes;
            elve.GetModifiedFluentAttributes().Returns(new CharacterFluentAttributes { LifePoints = 20 });
            
            healthPotion.Apply(elve);
            elve.CurrentFluentAttributes.LifePoints.Should().Be(19);
        }

        [Fact]
        public void Apply_useHeathPoitionOnEqipedCharcater()
        {
            var healthPotion = new TestItems().HealthPotion;
            var elve = new TestCharacters().Elve;
            var amuelet = new TestItems().ElvishAmulet;
            
            elve.Eqip(amuelet);

            healthPotion.Apply(elve);
            elve.CurrentFluentAttributes.LifePoints.Should().Be(18);
        }
    }
}
