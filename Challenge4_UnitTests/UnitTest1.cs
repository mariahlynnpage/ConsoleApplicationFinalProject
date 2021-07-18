using Challenge4_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge4_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOutings_CountShouldIncrease()
        {
            // Arrange
            IOutingRepo outingRepo = new OutingRepository();
            var outing = new Outing();
            int initCount = outingRepo.NumberOfOutings();


            // Act
            outingRepo.CreateOuting(outing);

            int addedCount = outingRepo.NumberOfOutings();

            Assert.AreEqual(initCount, addedCount - 1);
        }

        [TestMethod]
        public void GetOutings_ShouldReturnAddedOutings()
        {
            // Arrange
            IOutingRepo orderRepo = new OutingRepository();
            var outing1 = new Outing();
            var outing2 = new Outing();
            orderRepo.CreateOuting(outing1);
            orderRepo.CreateOuting(outing2);

            // Act
            int outingCount = 0;

            foreach (var item in orderRepo.ShowOutings())
            {
                outingCount++;
            }

            Assert.AreEqual(2, outingCount);
        }
    }
}