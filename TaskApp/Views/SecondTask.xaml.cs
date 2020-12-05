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
    public partial class SecondTask : ContentPage
    {
        public SecondTask()
        {
            InitializeComponent();
        }
        private void Clear(object sender, EventArgs e)
        {
            wheel.Text = null;
            tire.Text = null;
            Result.Text = null;
            editor.Text = null;
        }

        private void ToFindTheWay(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(wheel.Text);
                int M = Convert.ToInt32(tire.Text);
                if (N < 4 || N > 10 || N % 2 != 0)
                {
                    throw new Exception("Число N не можетт быть меньше 4 и больше 10, а также должно быть четным. Попробуйте еще раз.");
                }
                if(N > M || M > 20)
                {
                    throw new Exception("Число M не может быть меньше числа N и больше 20. Попробуйте еще раз.");
                }
                string edit = editor.Text;
                string[] mass = edit.Split(' ');
                int[] MassTires = new int[mass.Length];
                for(int i = 0; i < mass.Length; i++)
                {
                    MassTires[i] = Convert.ToInt32(mass[i]);
                }
                int a = MassTires[0];
                int b = MassTires[2];
                double res = Convert.ToDouble((2 * a * b) / (a + b) + 2 * Math.Pow(b,2)/(a+b));
                res = Math.Ceiling(res);
                Result.Text = res.ToString();
            }
            catch (Exception exc)
            {
                DisplayAlert("Ошибка!", exc.Message, "OK");
            }
        }
    }
}