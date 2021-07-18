using Challenge1_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItem_CountShouldIncrease()
        {
            // Arrange
            ICafeMenuRepo itemRepo = new CafeMenuRepo();
            var menuItem = new MenuItem();
            int initCount = itemRepo.NumberOfItems();


            // Act
            itemRepo.CreateMenuItem(menuItem);

            int addedCount = itemRepo.NumberOfItems();

            Assert.AreEqual(initCount, addedCount - 1);
        }
        [TestMethod]
        public void RemoveItem_CountShouldDecrease()
        {
            // Arrange
            ICafeMenuRepo itemRepo = new CafeMenuRepo();
            var menuItem = new MenuItem();
            itemRepo.CreateMenuItem(menuItem);

            int initCount = itemRepo.NumberOfItems();


            // Act
            itemRepo.DeleteItem(menuItem);

            int deletedCount = itemRepo.NumberOfItems();

            Assert.AreEqual(initCount, deletedCount + 1);
        }
        [TestMethod]
        public void GetItems_ShouldReturnAddedItems()
        {
            // Arrange
            ICafeMenuRepo itemRepo = new CafeMenuRepo();
            var item1 = new MenuItem();
            var item2 = new MenuItem();
            itemRepo.CreateMenuItem(item1);
            itemRepo.CreateMenuItem(item2);

            // Act
            int itemCount = 0;

            foreach (var item in itemRepo.GetMenuItems())
            {
                itemCount++;
            }

            Assert.AreEqual(2, itemCount);
        }
    }
}
