using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Lab3
{
    public class Fragment1 : Fragment
    {
        string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "temp.txt");
        string text;
        Button ButtonOk, ButtonOpen;
        EditText From, To;
        RadioButton Time;
        int checkedItem = 0;
        RadioGroup myRadioGroup;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);
            From = (EditText)view.FindViewById(Resource.Id.FromRead);
            To = (EditText)view.FindViewById(Resource.Id.ToRead);
            myRadioGroup = view.FindViewById<RadioGroup>(Resource.Id.RG);
            myRadioGroup.CheckedChange += MyRadioGroup_CheckedChange;
            Time = view.FindViewById<RadioButton>(myRadioGroup.CheckedRadioButtonId);
            ButtonOk = (Button)view.FindViewById(Resource.Id.ButtonOk);
            ButtonOpen = (Button)view.FindViewById(Resource.Id.ButtonOpen);
            ButtonOk.Click += OKButton_Click;
            ButtonOpen.Click += ButtonOpen_Click;
            return view;
        }
        /// <summary>
        /// Натиск на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (From.Text == "")
            {
                Toast_Output("Вкажiть початковий пункт");
            }
            else if (To.Text == "")
            {
                Toast_Output("Вкажiть кiнцевий пункт");
            }
            else
            {
                text = "Квиток\n" + From.Text + " - " + To.Text + "\nЧас відправлення: " + Time.Text;
                File.WriteAllText(fileName, text);
                Toast_Output("Квиток збережено в папку " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            }
            /*var intent = new Intent(Activity, typeof(MyActivity));
            intent.PutExtra("from-go", From.Text);
            intent.PutExtra("to-go", To.Text);
            intent.PutExtra("time-go", Time.Text);
            StartActivity(intent);*/
        }
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            bool doesExist = File.Exists(fileName);
            if (!doesExist)
            {
                Toast_Output("Квиток не знайдено");
            }
            else 
            {
                var intent = new Intent(this.Activity, typeof(OpenActivity));
                intent.PutExtra("fpath", fileName);
                StartActivity(intent);
            }
        }
        /// <summary>
        /// Змінено обраний RadioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyRadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            checkedItem = myRadioGroup.CheckedRadioButtonId;
            Time = View.FindViewById<RadioButton>(checkedItem);
        }
        static void Toast_Output(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}