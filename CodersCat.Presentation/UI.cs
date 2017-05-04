using CodersCat.Model;
using System;

namespace CodersCat.Presentation
{
    public class UI
    {
        public Cat Cat;

        public string BuyCat(int v)
        {
            try
            {
                Cat = new Cat(v);
                return $"Возраст кошки, которую Вы только что купили: {Cat.Age} лет";
            }
            catch { return "У кошки не может быть возраст меньше 1 года!"; }

        }

        public string ChangeCatName(string v)
        {
            try
            {
                Cat.Name = v;
            }
            catch { return "Вы уже назвали кошку! Изменить своё решение нельзя..."; };
            return "";
        }

        public string PunishCat()
        {
            try { Cat.Punish(); }
            catch { return "Нельзя забить питомца до смерти!"; }
            return null;
        }

        public void FeedCat()
        {
            Cat.Feed();
        }

        public object GetCatInfo()
        {
            return $"Кошка по имени: {Cat.Name}, цвет: {Cat.Color}";
        }
    }
}
