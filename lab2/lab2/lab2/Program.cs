using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Functions func = new Functions();
            double low = Limit("нижний");
            double high = Limit("верхний");
            double ac = Accuracy();

            Calculate cal = new Calculate(func, low, high, ac);
            cal.Sympson_sMethod();
            cal.Print();
        }

        static public double Limit(string text)
        {
            string s;
            double lim;
            bool mistake = false;
            do
            {
                Console.WriteLine("Введите " + text + " предел интегрирования:");
                s = Console.ReadLine();
                if (!double.TryParse(s, out lim))
                {
                    mistake = true;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                }
                else mistake = false;
            }
            while (mistake);
            return lim;
        }

        static public double Accuracy()
        {
            string s;
            double ac;
            bool mistake = false;
            do
            {
                Console.WriteLine("Введите точность: ");
                s = Console.ReadLine();
                if (!double.TryParse(s, out ac) || ac <= 0) // проверка корректности введенных данных
                {
                    mistake = true;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                }
                else mistake = false;
            }
            while (mistake);
            return ac;
        }
    }
}
