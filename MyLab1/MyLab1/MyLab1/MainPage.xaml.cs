using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLab1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void Mypicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTime = Mypicker.Items[Mypicker.SelectedIndex];
        }
        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (FromRead.Text=="")
            {
                DisplayAlert("Квиток не обрано", message: "Оберiть початковий пункт", cancel: "OK");

            }
            else if (ToRead.Text=="")
            {
                DisplayAlert("Квиток не обрано", message: "Оберiть пункт призначення", cancel: "OK");

            }
            else if (selectedTime=="")
            {
                DisplayAlert("Квиток не обрано", message: "Оберiть час вiдправлення", cancel: "OK");
            }
            else  DisplayAlert("Квиток обрано", message: FromRead.Text + "–" + ToRead.Text + " \nЧас вiдправлення: " + selectedTime, cancel: "OK");
        }
        public string selectedTime="";
    }
}
