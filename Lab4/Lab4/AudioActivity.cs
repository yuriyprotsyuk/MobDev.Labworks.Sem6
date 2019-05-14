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
using Android.Media;

namespace Lab4
{
    [Activity(Label = "AudioActivity")]
    public class AudioActivity : Activity
    {
        int checkedItem = 0;
        RadioGroup myRadioGroup;
        RadioButton Song;
        protected MediaPlayer player = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.audioactivity);
            var butttonPlay = FindViewById(Resource.Id.playButton);
            butttonPlay.Click += PlayMusic;
            var buttonPause = FindViewById(Resource.Id.pauseButton);
            buttonPause.Click += PauseMusic;
            var buttonStop = FindViewById(Resource.Id.stopButton);
            buttonStop.Click += StopMusic;
            myRadioGroup = (RadioGroup)FindViewById(Resource.Id.RG);
            myRadioGroup.CheckedChange += MyRadioGroup_CheckedChange;
            Song = FindViewById<RadioButton>(myRadioGroup.CheckedRadioButtonId);
        }
        private void MyRadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            checkedItem = myRadioGroup.CheckedRadioButtonId;
            Song = FindViewById<RadioButton>(checkedItem);
        }

        private void PlayMusic(object sender, EventArgs e)
        {
            if (player == null)
            {
                player = new MediaPlayer();
                if (Song.Text != "Song from resources")
                {
                    string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).AbsolutePath;
                    string full_path = path + Java.IO.File.Separator + Song.Text + ".mp3";
                    player.SetDataSource(full_path);
                    player.Prepare();
                    player.Start();
                }
                else
                {
                    Android.Net.Uri uri = Android.Net.Uri.Parse("android.resource://" + PackageName + "/" + Resource.Raw.song);
                    player.SetDataSource(this, uri);
                    player.Prepare();
                    player.Start();
                }
            }
            else
            {
                player.Start();
            }
        }
        private void PauseMusic(object sender, EventArgs e)
        {
            player.Pause();
        }
        private void StopMusic(object sender, EventArgs e)
        {
            player.Stop();
            player = null;
        }
    }
}