using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Lab2
{
    public class Fragment1 : Fragment
    {
        Button ButtonOk;
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
            ButtonOk.Click += OKButton_Click;
            return view;
        }
        /// <summary>
        /// Натиск на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Fragment2 frag = new Fragment2();
            Bundle args = new Bundle();
            args.PutString("from-go", From.Text);
            args.PutString("to-go", To.Text);
            args.PutString("time-go", Time.Text);
            frag.Arguments = args;
            var fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Replace(Resource.Id.fragment1, frag);
            fragmentTransaction.Commit();
        }
        /// <summary>
        /// Змінено обраний RadioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyRadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs  e)
        {
            checkedItem = myRadioGroup.CheckedRadioButtonId;
            Time = View.FindViewById<RadioButton>(checkedItem);
        }
    }
}