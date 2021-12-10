using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeAllValues()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorIfNotExisting()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Stoyan", 50, 80);
            Warrior warrior2 = new Warrior("Stoyan2", 150, 280);
            Warrior warrior3 = new Warrior("Stoyan3", 350, 480);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);

            bool warriorExists = arena.Warriors.Contains(warrior);
            bool warrior2Exists = arena.Warriors.Contains(warrior2);
            bool warrior3Exists = arena.Warriors.Contains(warrior3);

            Assert.True(warriorExists);
            Assert.True(warrior2Exists);
            Assert.True(warrior3Exists);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionForDoubledWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Stoyan", 50, 80);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));
        }

        [Test]
        public void FigthMethodShouldThrowExceptionForInvalidWarriors()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Kiro", 40, 70);


            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Kiro", "Stoyan"));
        }

        [Test]
        public void FigthMethodShouldThrowExceptionForInvalidAttacker()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Stoyan", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Kiro", "Stoyan"));
        }

        [Test]
        public void FigthMethodShouldThrowExceptionForInvalidDefender()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Kiro", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Kiro", "Stoyan"));
        }

        [Test]
        public void FightShouldReduceHP()
        {
            Arena arena = new Arena();

            Warrior attacker = new Warrior("Stoyan", 100, 50);
            Warrior defender = new Warrior("Kiro", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Stoyan", "Kiro");

            Warrior warriorAttacker = arena.Warriors
                .FirstOrDefault(x => x.Name == "Stoyan");
            Warrior warriorDefender = arena.Warriors
                .FirstOrDefault(x => x.Name == "Kiro");

            Assert.AreEqual(10, warriorAttacker.HP);
            Assert.AreEqual(0, warriorDefender.HP);
        }
    }
}
