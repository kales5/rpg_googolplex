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
   public class CharacterConsumeTest
    {
        [Fact]
        public void Consume_AEXistingItem()
        {
            var human = new TestCharacters().InjuerdHuman;
            var healthPotion = new TestItems().HealthPotion;

            human.Consume(healthPotion);

            human.Inventory.Should().BeEmpty();
            human.CurrentFluentAttributes.LifePoints.Should().Be(11);
        }
        [Fact]
        public void Consume_AItemThatTheCharDoesnotHave()
        {
            var elve = new TestCharacters().Elve;
            var healthPotion = new TestItems().HealthPotion;

            var ex = Assert.Throws<InvalidOperationException>(() =>elve.Consume(healthPotion));
            ex.Message.Should().Be($"The Character ({elve.Name}) has no {healthPotion.Name} in his Inventory to Consume!");            
        }
    }
}
