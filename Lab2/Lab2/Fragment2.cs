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
    public class Fragment2 : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = LayoutInflater.From(Activity).Inflate(Resource.Layout.fragment2, null);

            if ( Arguments== null)
            {
                return null;
            }
            else
            {
                string From = Arguments.GetString("from-go");
                string To = Arguments.GetString("to-go");
                string Time = Arguments.GetString("time-go");
                var textView = new TextView(this.Activity);
                var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, this.Activity.Resources.DisplayMetrics));
                textView.SetPadding(padding, padding, padding, padding);
                textView.TextSize = 24;
                textView.Text = "Квиток обрано\n" + From + " - " + To + "\nЧас відправлення: " + Time;
                var scroller = new ScrollView(this.Activity);
                scroller.AddView(textView);
                return scroller;
            }
        }
    }
}