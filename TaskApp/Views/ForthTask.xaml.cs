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
    public partial class ForthTask : ContentPage
    {
        public ForthTask()
        {
            InitializeComponent();
        }
        private void Clear(object sender, EventArgs e)
        {
            white.Text = null;
            black.Text = null;
            Result.Text = null;
        }

        private void ToFind(object sender, EventArgs e)
        {
            try
            {
                int M = Convert.ToInt32(white.Text);
                int N = Convert.ToInt32(black.Text);
                if (M < 1 || M > 1000 || N < 1 || N > 1000)
                {
                    throw new Exception("Числа M и N не могут быть меньше 1 и больше 1000. Попробуйте еще раз.");
                }
                Result.Text = ToFindTheAnswer(M,N).ToString();
            }
            catch(Exception exc)
            {
                DisplayAlert("Ошибка!", exc.Message, "OK");
            }
        }

        public int ToFindTheAnswer(int a, int b)
        {
            return a * b + (a + b);
        }
    }
}