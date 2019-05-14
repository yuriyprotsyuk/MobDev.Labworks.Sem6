using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab3
{
    [Activity(Label = "OpenActivity")]
    public class OpenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.openactivity);
            string fileName = Intent.GetStringExtra("fpath");
            string text = File.ReadAllText(fileName);
            var textView = (TextView) FindViewById(Resource.Id.textView1);
            textView.TextSize = 24;
            textView.Text = text;
        }
    }
}