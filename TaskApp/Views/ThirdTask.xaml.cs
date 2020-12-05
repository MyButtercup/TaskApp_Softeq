using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdTask : ContentPage
    {
        public ThirdTask()
        {
            InitializeComponent();
        }

        private void Clear(object sender, EventArgs e)
        {
            num1.Text = null;
            num2.Text = null;
            num3.Text = null;
            Result.Text = null;
        }
        private void Multiplication(object sender, EventArgs e) //Обработчик нажатия на кнопку
        {
            try 
            { 
                int A = Convert.ToInt32(num1.Text);
                int B = Convert.ToInt32(num2.Text);
                if(A <= 1 || A >= 10 || B <= 1 || B >= 10)
                {
                    throw new Exception("Числа A и B не могут быть меньше 1 и больше 10. Попробуйте еще раз.");
                }
                int N = Convert.ToInt32(num3.Text);
                if (N <= 10 || N >= 100)
                {
                    DisplayAlert("Ошибка!", "Число N не может быть меньше 10 и больше 100. Попробуйте еще раз.", "OK");
                    throw new Exception("Число N не может быть меньше 10 и больше 100. Попробуйте еще раз.");
                }

                Result.Text = "Ваше произведение = " + Search(A,B,N).ToString();
            }
            catch(Exception exc)
            {
                DisplayAlert("Ошибка!", exc.Message, "OK");
            }
        }

        public int Search(int a, int b, int n)
        {
            int res = 0;
            int multiA = Multi(a,n);
            int multiB = Multi(b,n);
            int multiAB = Multi(a, b, n);
            if (multiA > multiB && multiA > multiAB)
                res = multiA;
            else if (multiB > multiA && multiB > multiAB)
                res = multiB;
            else if (multiAB > multiA && multiAB > multiB)
                res = multiAB;
            else res = multiA;
            return res;
        }

        public int Multi(int l,int m)
        {
            int Minus = 0;
            int res = 0;
            while (m - l >= 0)
            {
                m -= l;
                Minus++;
            }
            if (m == 0)
            {
                res = Convert.ToInt32(Math.Pow(l, Minus));
            }
                return res;
        }

        public int Multi(int a, int b, int n)
        {
            int countA = 0;
            int countB = 0;
            int res = 0;
            int k = n;
            if(a >= b)
            {
                while(k - a >= 0)
                {
                    k -= a;
                    countA++;
                }
                if (k != 0 && k >= b)
                {
                    while (k - b >= 0)
                    {
                        k -= b;
                        countB++;
                    }
                }
                else if (k != 0 && k < b)
                {
                    countA--;
                    k += a;
                    while(k - b >= 0)
                    {
                        k -= b;
                        countB++;
                    }
                }
                res = Convert.ToInt32(Math.Pow(a, countA)) * Convert.ToInt32(Math.Pow(b, countB));
            }
            else if(b > a)
            {
                while (k - b >= 0)
                {
                    k -= b;
                    countB++;
                }
                if (k != 0 && k >= a)
                {
                    while (k - a >= 0)
                    {
                        k -= a;
                        countA++;
                    }
                }
                else if (k != 0 && k < a)
                {
                    countB--;
                    k += b;
                    while (k - a >= 0)
                    {
                        k -= a;
                        countA++;
                    }
                }
                res = Convert.ToInt32(Math.Pow(a, countA)) * Convert.ToInt32(Math.Pow(b, countB));
            }
            return res;
        }
    }
}