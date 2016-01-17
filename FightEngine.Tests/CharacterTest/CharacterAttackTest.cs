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
    public class CharacterAttackTest
    {
        [Fact]
        public void Attack_Human_Attacks_Elve()
        {
            var human = new TestCharacters().InjuerdHuman;
            var elve = new TestCharacters().Elve;

            human.Attack(elve);

            elve.CurrentFluentAttributes.LifePoints.Should().BeLessOrEqualTo(11)
                .And.BeGreaterOrEqualTo(6);
        }

        [Fact]
        public void Attack_EqiuppedElve_Attacks_Human()
        {
            var human = new TestCharacters().InjuerdHuman;
            var elve = new TestCharacters().Elve;
            var sword = new TestItems().Sword;
            elve.Eqip(sword);
            elve.Attack(human);

            human.CurrentFluentAttributes.LifePoints.Should().BeLessOrEqualTo(0)
                .And.BeGreaterOrEqualTo(-5);
        }

        [Fact]
        public void Attack_SelfAttack()
        {
            var human = new TestCharacters().InjuerdHuman;

            Action attack = () => human.Attack(human);
            attack.ShouldThrow<InvalidOperationException>().WithMessage($"Character {human.Name} can not attack itself");
        }

        [Fact]
        public void Attack_NullAttack()
        {
            var human = new TestCharacters().InjuerdHuman;

            Action attack = () => human.Attack(null);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Character {human.Name} can not attack null");
        }

        [Fact]
        public void Attack_AttackingEmptyCharcater()
        {
            var human = new TestCharacters().InjuerdHuman;
            var emptyCharacter = new Character();
            Action attack = () => human.Attack(emptyCharacter);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Character {human.Name} can not attack Empty Character");
        }

        [Fact]
        public void Attack_EmptyCharcaterAttacks()
        {
            var human = new TestCharacters().InjuerdHuman;
            var emptyCharacter = new Character();
            Action attack = () => emptyCharacter.Attack(human);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Empty Character can not attack");
        }

        [Fact]
        public void Attack_EmptyCharcaterAttacksEmpty()
        {
            
            var emptyCharacter = new Character();
            var emptyCharacter2 = new Character();
            Action attack = () => emptyCharacter.Attack(emptyCharacter2);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Empty Character can not attack");
        }

        [Fact]
        public void Attack_EmptyCharcaterAttacksNull()
        {
            var emptyCharacter = new Character();
            Action attack = () => emptyCharacter.Attack(null);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Empty Character can not attack");
        }

        [Fact]
        public void Attack_EmptyCharcaterSelfAttacks()
        {
            var emptyCharacter = new Character();
            Action attack = () => emptyCharacter.Attack(emptyCharacter);
            attack.ShouldThrow<ArgumentNullException>().WithMessage($"Empty Character can not attack");
        }
    }
}
