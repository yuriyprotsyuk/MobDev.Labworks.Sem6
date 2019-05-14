using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab2
{
    [Activity(Label = "MyActivity")]
    public class MyActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           /* var From = Intent.Extras.GetString("from-go");
            var To = Intent.Extras.GetString("to-go");
            var Time = Intent.Extras.GetString("time-go");

            var detailsFrag = Fragment2.NewInstance(From,To,Time);
            FragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, detailsFrag)
                            .Commit();*/
        }

    }
}