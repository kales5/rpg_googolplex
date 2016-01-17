using FightEngine.Items;
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
        public void Consume_AExistingItem()
        {
            var human = new TestCharacters().InjuerdHuman;
            

            human.Consume(human.Inventory.Single() as ConsumableItem);

            human.Inventory.Should().BeEmpty();
            human.CurrentFluentAttributes.LifePoints.Should().Be(11);
        }
        [Fact]
        public void Consume_AItemThatTheCharDoesnotHave()
        {
            var human = new TestCharacters().InjuerdHuman;
            var healthPotion = new TestItems().HealthPotion;

            var ex = Assert.Throws<InvalidOperationException>(() => human.Consume(healthPotion));
            ex.Message.Should().Be($"The Character ({human.Name}) has not this Item: {healthPotion.Name}");            
        }
    }
}
