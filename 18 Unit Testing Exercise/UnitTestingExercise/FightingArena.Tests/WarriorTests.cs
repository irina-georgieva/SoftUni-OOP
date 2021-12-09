using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        //    [SetUp]
        //    public void Setup()
        //    {
        //    }

        //    [Test]
        //    [TestCase("Stoyan", 50, 70)]
        //    [TestCase("Niki", 67, 20)]
        //    [TestCase("Viktor", 10, 5)]
        //    [TestCase("Kiro", 1, 0)]
        //    public void ConstructorShouldSetEverythingIfDataIsValid(string name,
        //        int damage, int health)
        //    {
        //        Warrior warrior = new Warrior(name, damage, health);

        //        Assert.AreEqual(name, warrior.Name);
        //        Assert.AreEqual(damage, warrior.Damage);
        //        Assert.AreEqual(health, warrior.HP);
        //    } 

        //    [TestCase(null)]
        //    [TestCase(" ")]
        //    [TestCase("")]
        //    public void ConstructorShouldThrowArgumentExceptionForInvalidName(string name)
        //    {
        //        Assert.Throws<ArgumentException>(() => new Warrior(name, 40, 50));
        //    }

        //    [TestCase(0)]
        //    [TestCase(-1)]
        //    [TestCase(-54)]
        //    public void ConstructorShouldThrowArgumentExceptionForInvalidDamage(int damage)
        //    {
        //        Assert.Throws<ArgumentException>(() => new Warrior("Irina", damage, 50));
        //    }

        //    [TestCase(-1)]
        //    [TestCase(-54)]
        //    public void ConstructorShouldThrowArgumentExceptionForInvalidHealth(int damage)
        //    {
        //        Assert.Throws<ArgumentException>(() => new Warrior("Irina", 60, damage));
        //    }

        //    [Test]
        //    [TestCase("Stoyan", 20, 50, "Niki", 40, 50)]
        //    [TestCase("Stoyan", 30, 50, "Niki", 40, 50)]
        //    [TestCase("Stoyan", 50, 50, "Niki", 30, 50)]
        //    [TestCase("Stoyan", 50, 50, "Niki", 20, 50)]
        //    public void AttackMethodShouldThrowExceptionWhenHpIsBelowOrEqualZero
        //        (string name, int health, int damage, string enemyName, int enemyHealth, int enemyDamage)
        //    {
        //        Warrior myWarrior = new Warrior(name, damage, health);
        //        Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);

        //        Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(enemy));
        //    }

        //    [Test]
        //    [TestCase("Stoyan", 50, 50, "Niki", 40, 90)]
        //    public void AttackMethodShouldThrowExceptionWhenHpIsBelowEnemyDamage
        //(string name, int health, int damage, string enemyName, int enemyHealth, int enemyDamage)
        //    {
        //        Warrior myWarrior = new Warrior(name, damage, health);
        //        Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);

        //        Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(enemy));
        //    }

        //    [TestCase("Stoyan", 50, 100, 50, "Kiro", 50, 100, 50)]
        //    [TestCase("Stoyan", 100, 100, 50, "Kiro", 50, 100, 0)]
        //    [TestCase("Stoyan", 120, 100, 50, "Kiro", 50, 100, 0)]
        //    public void AttackMethodShouldReduceHPForWarriorAndEnemyWarrior
        //        (string name, int damage, int health, int resultHP, 
        //        string enemyName, int enemyDamage, int enemyHealth, int resultEnemyHP)
        //    {
        //        Warrior myWarrior = new Warrior(name, damage, health);
        //        Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);

        //        myWarrior.Attack(enemy);

        //        Assert.AreEqual(resultHP, myWarrior.HP);            
        //        Assert.AreEqual(resultEnemyHP, enemy.HP);
        //    }

        private int minAttackHP;
        private Warrior player;
        private Warrior enemy;

        [SetUp]
        public void Setup()
        {
            player = new Warrior("Ragnar", 25, 100);
            enemy = new Warrior("Spartacus", 15, 100);
            minAttackHP = 30;
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(player, "The constructor is broken!");
            Assert.IsNotNull(enemy, "The constructor is broken!");
        }

        [Test]
        public void VerifyNameProperty()
        {
            Assert.AreEqual("Ragnar", player.Name, "Property isn't working right!");
        }

        [Test]
        public void NamePropertyThrowsExceptionIfNullEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => player = new Warrior(null, 5, 5));
            Assert.Throws<ArgumentException>(() => player = new Warrior(" ", 5, 5));
            Assert.Throws<ArgumentException>(() => player = new Warrior("", 1, 2));
        }

        [Test]
        public void VerifyDamageProperty()
        {
            Assert.AreEqual(25, player.Damage, "Property isn't working right!");
        }

        [Test]
        public void DamagePropertyThrowsExceptionIfValueIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => player = new Warrior("Arthur", 0, 5));
            Assert.Throws<ArgumentException>(() => player = new Warrior("Arthur", -5, 2));
        }

        [Test]
        public void VerifyHealthProperty()
        {
            Assert.AreEqual(100, player.HP, "Property isn't working right!");
        }

        [Test]
        public void HealthPropertyThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => player = new Warrior("Crixus", 55, -10));
        }

        [Test]
        public void VerifyAttackMethod()
        {
            player.Attack(enemy);
            Assert.AreEqual(75, enemy.HP);
        }

        [Test]
        public void AttackMethodSetsEnemyHpToZero()
        {
            player = new Warrior("Temp", 150, 100);
            player.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }

        [Test]
        public void AttackMethodThrowsExceptionIfHpIsLowerThanTheEnemy()
        {
            player = new Warrior("Temp", 11, 25);
            Assert.Throws<InvalidOperationException>(() => player.Attack(enemy));
        }

        [Test]
        public void AttackMethodThrowsExceptionIfEnemyHpIsLowerThanTheConstantValue()
        {
            enemy = new Warrior("Temp", 11, 25);
            Assert.Throws<InvalidOperationException>(() => player.Attack(enemy));
        }

        [Test]
        public void AttackMethodThrowsExceptionIfEnemyDamageIsHigherThanPlayerHp()
        {
            player = new Warrior("Temp", 15, 35);
            enemy = new Warrior("Temp", 60, 55);
            Assert.Throws<InvalidOperationException>(() => player.Attack(enemy));
        }
    }
}