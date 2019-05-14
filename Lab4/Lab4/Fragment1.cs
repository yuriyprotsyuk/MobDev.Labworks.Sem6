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

namespace Lab4
{
    public class Fragment1 : Fragment
    {
        Button ButtonOk;
        RadioButton Media;
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
            ButtonOk = (Button)view.FindViewById(Resource.Id.buttonOk);
            myRadioGroup = (RadioGroup)view.FindViewById(Resource.Id.RG);
            myRadioGroup.CheckedChange += MyRadioGroup_CheckedChange;
            Media = view.FindViewById<RadioButton>(myRadioGroup.CheckedRadioButtonId);
            ButtonOk.Click += OKButton_Click;
            return view;
        }
        private void MyRadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            checkedItem = myRadioGroup.CheckedRadioButtonId;
            Media = View.FindViewById<RadioButton>(checkedItem);
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (Media.Text== "Відворення аудіо")
            {
                var intent = new Intent(this.Activity, typeof(AudioActivity));
                StartActivity(intent);
            }
            else
            {
                var intent = new Intent(this.Activity, typeof(VideoActivity));
                StartActivity(intent);
            }
        }
    }
}