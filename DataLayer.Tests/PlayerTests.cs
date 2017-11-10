using DataLayer.DataLayer.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        static Player player = new Player(1);
        [Test]
        public void NameIsAString()
        {
            //Arrange
            var name = player.Name;
            bool isString = false;
            //Act
            if (name is String)
                isString = true;

            //Assert
            Assert.AreEqual(true, isString);
        }


        [Test]
        public void NameIsNotEmpty()
        {
            //Arrange
            bool empty = true;
            //Act
            if (!player.Name.Equals(string.Empty))
                empty = false;
            //Assert
            Assert.AreEqual(false, empty);

        }

        [Test]
        public void NameIsNotLongerThan20()
        {
            //Arrange
            string name = player.Name;
            bool isLonger = true;
            //Act
            if (name.Length < 21)
                isLonger = false;
            //Assert
            Assert.AreEqual(false, isLonger);
        }
    }
}
