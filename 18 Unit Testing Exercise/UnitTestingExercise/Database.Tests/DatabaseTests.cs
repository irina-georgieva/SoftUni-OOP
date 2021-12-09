using NUnit.Framework;
using System;
using System.Linq;

namespace Database.Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMethodShouldAddNewElementsWhileCountIsLessThan16()
        {
            Database database = new Database();
            database.Add(10);
            database.Add(10);
            database.Add(10);

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenItemsAreAbove16()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }

        [Test]
        public void ConstructorShouldAddItemsWhileBelow16()
        {
            int[] elements = Enumerable.Range(1, 15).ToArray();

            Database database = new Database(elements);

            Assert.AreEqual(15, database.Count);
        }

        [Test]
        [TestCase(1, 25)]
        [TestCase(1, 17)]
        
        public void ConstructorShouldThrowExceptionWhenItemsAreAbove16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() =>
            new Database(elements));

        }

        [Test]
        [TestCase(1, 10, 3, 7)]
        [TestCase(1, 5, 4, 1)]

        public void MethodShouldRemoveElementsWhenTheyAreAbove0(int start, int count, int toRemove, int result)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenElementsAre0()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
            
        [Test]
        public void FetchShouldReturnAllValidItems()
        {
            Database database = new Database(1, 2, 3);

            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchedData = database.Fetch();

            int[] expectedData = new int[] { 1, 2 };
            Assert.AreEqual(expectedData, fetchedData);
        }
    }
}