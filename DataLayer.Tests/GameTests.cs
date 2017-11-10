using DataLayer.DataLayer.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Tests
{
    class GameTests
    {
        static Game game = new Game { Name = "Asd"};

        [Test]
        public void GameNameIsNotEmpty()
        {
            //Arrange
            bool empty = true;
            //Act
            if (!game.Name.Equals(string.Empty))
            {
                empty = false;
            }
            //Assert
            Assert.AreEqual(false, empty);

        }

        [Test]
        public void GameNameIsNotLongerThan15()
        {
            //Arrange
            string name = game.Name;
            bool isLonger = true;
            //Act
            if (name.Length < 16)
            {
                isLonger = false;
            }
            //Assert
            Assert.AreEqual(false, isLonger);
        }
    }
}
