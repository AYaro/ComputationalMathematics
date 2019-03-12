using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Calculate
    {
        double low, high, p, h; //нижний и верхний пределы, количество шагов
        double In, I2n, ac, uac, rez; // интеграл 1, интеграл 2, размер шага,
                                      // введенная пользователем точность, вычисленная погрешность, итоговое значение интеграла
        Functions func; //функция для интегрирования
        bool flag;

        public Calculate(Functions f, double low, double high, double ac)
        {
            this.func = f;
            if (high > low) //меняем местами пределы, если нижний предел > верхнего
            {
                this.low = low;
                this.high = high;
            }
            else
            {
                flag = true;
                this.low = high;
                this.high = low;
            }
            this.ac = ac;
        }

        public double Sympson_sMethod()
        {
            if (high != low)
            {
                for (int n = 4; n <= 10000; n += 2)
                {
                    In = calcIntg(n); // вычисление интеграла с количеством шагов = n
                    I2n = calcIntg(2 * n);// вычисление интеграла с количеством шагов = 2n

                    //метод Рунге
                    uac = ((Math.Abs(I2n - In) * 1.0) / 15.0);
                    if (uac < ac)  //проверка, заданная пользователем точность меньше вычисленной погрешности?
                    {
                        rez = I2n;
                        p = n;
                        break;
                    }
                    if (n == 10000) { Console.WriteLine("Заданная точность не достигнута. Интеграл не имеет решения."); p = 0; }
                }
            }
            else { rez = 0; p = 0; Console.WriteLine("Пределы интегрирования равны, результат вычисления будет равен 0 в любом случае."); }
            return rez;
        }

        private double calcIntg(int n)
        {
            double sum = 0;
            double h = (high - low) * 1.0 / (n * 1.0); //вычисление размера шага
            for (int i = 1; i < n; i++)
            {
                sum += 4 * func.currentFunc(low + i * h);
                ++i;
                sum += 2 * func.currentFunc(low + i * h);
            }

            return (sum + func.currentFunc(low) - func.currentFunc(high)) * h / 3;
        }

        public void Print() // вывод полученных значений
        {
            if (p != 0)
            {
                if (flag == true) rez = rez * (-1);
                Console.WriteLine("Значение интеграла: " + Math.Round(rez, 9));
                Console.WriteLine("Количество шагов: " + p);
                Console.WriteLine("Погрешность: " + Math.Round(uac, 9));
            }
            Console.ReadKey();
        }
    }
}
