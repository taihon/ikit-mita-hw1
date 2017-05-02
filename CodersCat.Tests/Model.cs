using System;
using CodersCat.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace CodersCat.Tests
{
    [TestClass]
    public class Model
    {
        private Cat cat;
        [TestMethod]
        public void CreateCatWithAgeEqualToZeroThrows()
        {
            Action action = () => new Cat(0);
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
        [TestMethod]
        public void CreateWithPositiveAgeNotThrows()
        {
            Action action = () => new Cat(1);
            action.ShouldNotThrow<ArgumentOutOfRangeException>();
        }
    }
}
