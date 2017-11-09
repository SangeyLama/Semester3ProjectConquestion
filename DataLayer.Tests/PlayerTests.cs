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
        /*
        [Test]
        public void NameIsAString(int id)
        {
            var name = Player.getName(id);
            bool isString = false;

            if(name is String)
                isString = true;
          

            Assert.AreEqual(true, isString);
        }
        
        [Test]
        public void NameIsNotEmpty(int id)
        {
            //Arrange
            var name = Player.GetName(id);
            bool empty = true;
            //Act
            if (!name.Equals(string.Empty))
                empty = false;
            //Assert
            Assert.AreEqual(false, empty);

        }
        */
        [Test]
        public void NameIsNotLongerThan20()
        {
            string name = "as";
            bool isLonger = true;

            if (name.Length < 21)
                isLonger = false;

            Assert.AreEqual(false, isLonger);
        }

    }
}
