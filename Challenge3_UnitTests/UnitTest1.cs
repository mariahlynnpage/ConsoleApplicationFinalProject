using Challenge3_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge3_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBadgeName_ShouldSetBadge()
        {
            // Arrange
            var badgeName = "Samantha";

            // Act
            var newBadgeName = new Badge(badgeName);

            // Assert
            Assert.AreEqual(badgeName, newBadgeName.BadgeName);
        }
        [TestMethod]
        public void CreateSCInRepo_ShouldAddSC()
        {
            // Arrange
            var repo = new BadgeRepository();
            var badgeToAdd = new Badge("Richard");
            int countBeforeAdd = repo._badges.Count;

            // Act
            repo.CreateNewBadge(badgeToAdd);

            int countAfterAdd = repo._badgeDirectory.Count;

            // Assert
            // Assert.AreEqual(repo.GetAllStreamingContent().Contains(scToAdd));
            Assert.AreEqual(countBeforeAdd, countAfterAdd - 1);
        }
    }
}
