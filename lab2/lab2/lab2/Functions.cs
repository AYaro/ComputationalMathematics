using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{

    class Functions
    {
        public delegate double Delegate(double x);

        List<string> funcs = new List<string>();
        public Delegate currentFunc;

        public Functions()
        {
            funcs.Add("y = x;");
            funcs.Add("y = 2*x + 1;");
            funcs.Add("y = x^2;");
            funcs.Add("y = sqrt(1+x^2);");
            funcs.Add("y = 1 / x;");
            string s;
            int num;
            bool mistake = false;
            do
            {
                PrintFucns();
                s = Console.ReadLine();
                if (!int.TryParse(s, out num) || num < 1 || num > 5)
                {
                    mistake = true;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                }
                else mistake = false;
            }
            while (mistake);
            switch (num)
            {
                case 1: currentFunc = new Delegate(Func_1); break;
                case 2: currentFunc = new Delegate(Func_2); break;
                case 3: currentFunc = new Delegate(Func_3); break;
                case 4: currentFunc = new Delegate(Func_4); break;
                case 5: currentFunc = new Delegate(Func_5); break;
            }
        }

        private void PrintFucns()
        {
            Console.WriteLine("Выберите функцию, для вычисления:");
            for (int i = 0; i < funcs.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ") " + funcs[i]);
            }
        }

        static double Func_1(double x) { return Math.Pow(Math.Log10(x), x); }

        static double Func_2(double x) { return 2 * x + 1; }

        static double Func_3(double x) { return x * x; }

        static double Func_4(double x) { return Math.Sqrt(1 + Math.Pow(x, 2)); }

        static double Func_5(double x) { return 1 / x; }

    }
}
