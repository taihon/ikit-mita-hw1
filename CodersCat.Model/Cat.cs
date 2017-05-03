using System;

namespace CodersCat.Model
{
    public class Cat
    {
        private int Heath = 6;
        public string Color {
            get {
                if(Heath < 3) { return "Red"; }
                /* в ТЗ сказано, что желтый цвет должен быть при здоровье
                 * равном 5, а цвет кошки при значениях 3, 4 не определён
                 * Изменил условие, желтой кошка становится при здоровье
                 * от 3 до 5 включительно
                 */
                if (Heath <=5&& Heath>=3) { return "Yellow"; }
                return "Green";
            }
        }

        public Cat(int age)
        {
            if(age <= 0)
                throw new ArgumentOutOfRangeException();
            Age = age;
        }
        private string name;
        public int Age { get; internal set; }
        public string Name { get { return name; } set {
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = value;
                } else
                {
                    throw new InvalidOperationException("You should set name only once!");
                }
            }
        }

        public void Punish()
        {
            if(Heath > 1) { 
                Heath--;
            }
            else { throw new InvalidOperationException("You cannot punish cat to death!"); }
        }

        public void Feed()
        {
            Heath++;
        }
    }
}
