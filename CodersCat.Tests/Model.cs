using System;
using CodersCat.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace CodersCat.Tests
{
    [TestClass]
    public class Model
    {
        [TestMethod]
        public void CreateCatWithAgeEqualToZeroThrowsArgumentOutOfRange()
        {
            Action action = () => new Cat(0);
            action.ShouldThrow<ArgumentOutOfRangeException>("user shouldn't be able to create Cats with age equal to zero");
        }
        [TestMethod]
        public void CreateWithPositiveAgeNotThrows()
        {
            Action action = () => new Cat(1);
            action.ShouldNotThrow<ArgumentOutOfRangeException>("user should be able to create Cats with age greater than zero");
        }
        [TestMethod]
        public void CreateWithNegativeAgeThrowsArgumentOutOfRange()
        {
            Action action = () => new Cat(-1);
            action.ShouldThrow<ArgumentOutOfRangeException>("user shouldn't be able to create Cats with negative age");
        }
        [TestMethod]
        public void CreateCatWithAgeOfOneSetsAgeProperty()
        {
            var cat = new Cat(1);
            cat.Age.Should().Be(1, "age of Cat(1) should be equal to 1");
        }
        [TestMethod]
        public void CreateCatWithAgeOfTwoSetsAgeToTwo()
        {
            var cat = new Cat(2);
            cat.Age.Should().Be(2, "age of Cat(2) should be equal to 2");
        }
        [TestMethod]
        public void CatColorIsGreenByDefault()
        {
            var cat = new Cat(1);
            cat.Color.Should().Be("Green", "healthy Cat color is green");
        }
        [TestMethod]
        public void CatChangesColorToYellowWhenPunishedJustAfterCreation()
        {
            var cat = new Cat(2);
            cat.Punish();
            cat.Color.Should().Be("Yellow", "cat should change color to yellow when hit just after creation");
        }
        [TestMethod]
        public void CatChangesColorToRedWhenHeathBelowThree()
        {
            var cat = new Cat(2);
            for(int i = 0; i < 4; i++)
            {
                cat.Punish();
            }
            cat.Color.Should().Be("Red", "cat should have red color when Heath below 3");
        }
        [TestMethod]
        public void FeedingCatIncreasesHeath()
        {
            var cat = new Cat(2);
            cat.Punish();
            cat.Feed();
            cat.Color.Should().Be("Green", "feeding cat should increase Heath, and change color when appropriate");
        }
        [TestMethod]
        public void PunishingCatShouldNotLowerHeathBelowOne()
        {
            var cat = new Cat(1);
            for (int i = 0; i < 5; i++) { cat.Punish(); }
            Action a = () => cat.Punish();
            a.ShouldThrow<InvalidOperationException>("Heath equal to zero is not allowed")
                .WithMessage("You cannot punish cat to death!");
        }
        [TestMethod]
        public void UserAbleToSetNameForCat()
        {
            var cat = new Cat(1)
            {
                Name = "Fat Sally"
            };
            cat.Name.Should().Be("Fat Sally", "user should be able to set cat's name after creation");
        }
        [TestMethod]
        public void UserUnableToChangeNameAfterAssigningOne()
        {
            var cat = new Cat(1)
            {
                Name = "Fat Sally"
            };
            Action a = () => cat.Name = "Thin Sally";
            a.ShouldThrow<InvalidOperationException>().WithMessage("You should set name only once!");
        }
    }
}
