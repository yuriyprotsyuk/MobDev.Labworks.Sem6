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
using Android.Media;
using static Android.Media.MediaPlayer;
using static Android.Widget.MediaController;

namespace Lab4
{
    [Activity(Label = "VideoActivity")]
    public class VideoActivity : Activity, IOnCompletionListener, IOnPreparedListener
    {
        int checkedItem = 0;
        RadioGroup myRadioGroup;
        RadioButton Video;
        VideoView player;
        //MediaPlayer MP;
        MediaController mediaController;
        int pausePosition = 0;
        string videoUrl = "http://clips.vorwaerts-gmbh.de/VfE_html5.mp4";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.videoactivity);
            if (mediaController == null)
            {
                mediaController = new MediaController(this);
            }
            var butttonPlay = FindViewById(Resource.Id.playButton);
            butttonPlay.Click += PlayVideo;
            var buttonPause = FindViewById(Resource.Id.pauseButton);
            buttonPause.Click += PauseVideo;
            var buttonStop = FindViewById(Resource.Id.stopButton);
            buttonStop.Click += StopVideo;
            player = FindViewById<VideoView>(Resource.Id.videoView);
            myRadioGroup = (RadioGroup)FindViewById(Resource.Id.RG);
            myRadioGroup.CheckedChange += MyRadioGroup_CheckedChange;
            Video = FindViewById<RadioButton>(myRadioGroup.CheckedRadioButtonId);
        }
        private void MyRadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            checkedItem = myRadioGroup.CheckedRadioButtonId;
            Video = FindViewById<RadioButton>(checkedItem);
        }
        private void PlayVideo(object sender, EventArgs e)
        {
            try
            {
                if (!player.IsPlaying && pausePosition==0)
                {
                    player = FindViewById<VideoView>(Resource.Id.videoView);
                    player.SetMediaController(mediaController);
                    if (Video.Text == "Video from net")
                    {
                        Android.Net.Uri uri = Android.Net.Uri.Parse(videoUrl);
                        player.SetVideoURI(uri);
                        player.SetOnCompletionListener(this);
                        player.RequestFocus();
                        player.SetOnPreparedListener(this);
                    }
                    else if (Video.Text == "Video from resources")
                    {
                        Android.Net.Uri uri = Android.Net.Uri.Parse("android.resource://" + PackageName + "/" + Resource.Raw.beauty);
                        player.SetVideoURI(uri);
                        player.SetOnCompletionListener(this);
                        player.RequestFocus();
                        player.SetOnPreparedListener(this);
                    }
                    else
                    {
                        string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMovies).AbsolutePath;
                        string full_path = path + Java.IO.File.Separator + Video.Text + ".mp4";
                        Android.Net.Uri uri = Android.Net.Uri.Parse(full_path);
                        player.SetVideoURI(uri);
                        player.SetOnCompletionListener(this);
                        player.RequestFocus();
                        player.SetOnPreparedListener(this);
                    }
                }
                else
                {
                    player.SeekTo(pausePosition);
                    player.Start();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void PauseVideo(object sender, EventArgs e)
        {
            player.Pause();
        }
        private void StopVideo(object sender, EventArgs e)
        {
            player.StopPlayback();
        }

        public void OnCompletion(MediaPlayer mp)
        {
            throw new NotImplementedException();
        }

        public void OnPrepared(MediaPlayer mp)
        {
            player.SeekTo(pausePosition);
            if (pausePosition == 0)
            {
                player.Start();
            }
            else
                player.Pause();
        }
    }
}