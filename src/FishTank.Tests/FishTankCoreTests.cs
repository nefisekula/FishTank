using FishTank.Core;
using FishTank.Core.Entities;
using FishTank.Core.Interfaces;
using NUnit.Framework;
using System;

namespace FishTank.Tests
{
    [TestFixture]
    public class FishTankCoreTests
    {
        private ITank _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Tank();
        }

        [Test]
        public void Should_GoldFish_Created_Correctly()
        {
            var goldFish = new GoldFish("Test Gold Fish");

            Assert.AreEqual(0.1, goldFish.FoodRequired);
        }

        [Test]
        public void Should_AngelFish_Created_Correctly()
        {
            var angelFish = new AngelFish("Test Angel Fish");

            Assert.AreEqual(0.2, angelFish.FoodRequired);
        }

        [Test]
        public void Should_BabelFish_Created_Correctly()
        {
            var babelFish = new BabelFish("Test Babel Fish");

            Assert.AreEqual(0.3, babelFish.FoodRequired);
        }

        [Test]
        public void Should_Add_To_The_sut_Gold_Fish()
        {
            var goldFish = new GoldFish("Test Gold Fish");

            var actal = _sut.AddFish(goldFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.1, _sut.Feed());
        }

        [Test]
        public void Should_Add_To_The_sut_Angel_Fish()
        {
            var angelFish = new AngelFish("Test Angel Fish");

            var actal = _sut.AddFish(angelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.2, _sut.Feed());
        }

        [Test]
        public void Should_Add_To_The_sut_Babel_Fish()
        {
            var babelFish = new BabelFish("Test Babel Fish");

            var actal = _sut.AddFish(babelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.3, _sut.Feed());
        }


        [Test]
        public void Should_Add_To_The_sut_Gold_And_Angel_Fish()
        {
            var goldFish = new GoldFish("Test Gold Fish");
            var actal = _sut.AddFish(goldFish);

            var angelFish = new AngelFish("Test Angel Fish");
            actal = _sut.AddFish(angelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.3, _sut.Feed());
        }

        [Test]
        public void Should_Add_To_The_sut_Gold_And_Babel_Fish()
        {
            var goldFish = new GoldFish("Test Gold Fish");
            var actal = _sut.AddFish(goldFish);

            var babelFish = new BabelFish("Test Babel Fish");
            actal = _sut.AddFish(babelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.4, _sut.Feed());
        }


        [Test]
        public void Should_Add_To_The_sut_Angel_And_Babel_Fish()
        {
            var angelFish = new AngelFish("Test Angel Fish");
            var actal = _sut.AddFish(angelFish);

            var babelFish = new BabelFish("Test Babel Fish");
            actal = _sut.AddFish(babelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.5, _sut.Feed());
        }


        [Test]
        public void Should_Add_To_The_sut_Gold_And_Angel_And_Babel_Fish()
        {
            var goldFish = new GoldFish("Test Gold Fish");
            var actal = _sut.AddFish(goldFish);

            var angelFish = new AngelFish("Test Angel Fish");
            actal = _sut.AddFish(angelFish);

            var babelFish = new BabelFish("Test Babel Fish");
            actal = _sut.AddFish(babelFish);

            Assert.IsTrue(actal);
            Assert.AreEqual(0.6, _sut.Feed());
        }


        [Test]
        public void Should_Return_1_Gram_Feed_For_sut()
        {
            var goldFish = new GoldFish("Test Gold Fish");
            var actal = _sut.AddFish(goldFish);

            var angelFish = new AngelFish("Test Angel Fish");
            actal = _sut.AddFish(angelFish);

            var babelFish = new BabelFish("Test Babel Fish");
            actal = _sut.AddFish(babelFish);

            var goldFishN1 = new GoldFish("Test Gold Fish N1");
            actal = _sut.AddFish(goldFishN1);

            var babelFishN1 = new BabelFish("Test Babel Fish N1");
            actal = _sut.AddFish(babelFishN1);

            Assert.IsTrue(actal);
            Assert.AreEqual(1, _sut.Feed());
        }


        [Test]
        public void Should_Return_Fish_Count_1()
        {
            var goldFish = new GoldFish("Test Gold Fish");
            var actal = _sut.AddFish(goldFish);

            var count = _sut.GetFishList().Count;

            Assert.IsTrue(actal);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void Should_Throw_Exception_For_Null_Gold_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new GoldFish(null));
        }

        [Test]
        public void Should_Throw_Exception_For_Null_Angel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new AngelFish(null));
        }

        [Test]
        public void Should_Throw_Exception_For_Null_Babel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new BabelFish(null));
        }

        [Test]
        public void Should_Throw_Exception_For_Empty_Gold_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new GoldFish(""));
        }

        [Test]
        public void Should_Throw_Exception_For_Empty_Angel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new AngelFish(""));
        }

        [Test]
        public void Should_Throw_Exception_For_Empty_Babel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new BabelFish(""));
        }


        [Test]
        public void Should_Throw_Exception_For_Space_Gold_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new GoldFish(" "));
        }

        [Test]
        public void Should_Throw_Exception_For_Space_Angel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new AngelFish(" "));
        }

        [Test]
        public void Should_Throw_Exception_For_Space_Babel_Fish_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new BabelFish(" "));
        }

        [Test]
        public void Should_Return_False_Tank_Add_For_Null_Fish()
        {
            var actual = _sut.AddFish(null);

            Assert.IsFalse(actual);
        }

    }
}
