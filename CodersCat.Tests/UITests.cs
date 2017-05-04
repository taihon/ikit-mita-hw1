using CodersCat.Model;
using CodersCat.Presentation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersCat.Tests
{
    [TestClass]
    public class UITests
    {
        UI ui;
        [TestInitialize]
        public void Setup()
        {
            ui = new UI();
        }
        [TestMethod]
        public void CanBuyCat()
        {
            var cat = new Cat(1);
            ui.BuyCat(1);
            ui.Cat.ShouldBeEquivalentTo(cat, "user should be able to buy a cat");
        }
        [TestMethod]
        public void ByingCatWithNegativeAgeNotifiesUser()
        {
            var a = ui.BuyCat(-1);
            a.Should().Be("У кошки не может быть возраст меньше 1 года!");
        }
        [TestMethod]
        public void UserAbleToSetCatsName()
        {
            ui.BuyCat(1);
            ui.ChangeCatName("Мурка");
            ui.Cat.Name.Should().Be("Мурка");
        }
        [TestMethod]
        public void UserProperlyNotifiedWhenTryingToSetNameTwice()
        {
            ui.BuyCat(1);
            ui.ChangeCatName("Мурка");
            var a = ui.ChangeCatName("Зорька");
            a.Should().Be("Вы уже назвали кошку! Изменить своё решение нельзя...");
        }
        [TestMethod]
        public void UserNotifiedWhenTryingToPunishCatToDeath()
        {
            ui.BuyCat(1);
            string t = null;
            for (int i = 0; i < 6; i++)
            {
                t = ui.PunishCat();
            }
            t.Should().Be("Нельзя забить питомца до смерти!");
        }
        [TestMethod]
        public void UserCanFeedPet()
        {
            ui.BuyCat(1);
            ui.PunishCat();
            ui.FeedCat();
            ui.Cat.Color.Should().Be("Green", "feeding cat after punishing should change cat's color back to green");
        }
        [TestMethod]
        public void UserCanGetInfoAboutCat()
        {
            ui.BuyCat(1);
            ui.ChangeCatName("Том");
            var t = ui.GetCatInfo();
            t.Should().Be("Кошка по имени: Том, цвет: Green");
        }
    }
}
