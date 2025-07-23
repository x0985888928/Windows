using LibVLCSharp.Shared;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        public Form1()
        {
            InitializeComponent();
            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mediaPlayer;

            _mediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackPosition.Minimum = 0;
            trackPosition.Maximum = 1000;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "影片檔案 (*.mp4;*.mkv;*.avi;*.mov;*.webm)|*.mp4;*.mkv;*.avi;*.mov;*.webm|所有檔案|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var media = new Media(_libVLC, new Uri(ofd.FileName));
                _mediaPlayer.Play(media);
                updPlaybar.Start();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_mediaPlayer.IsPlaying)
                _mediaPlayer.Pause();
            else
                _mediaPlayer.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
            updPlaybar.Stop();
            trackPosition.Value = 0;
        }

        private void updPlaybar_Tick(object sender, EventArgs e)
        {
            if (_mediaPlayer.Length > 0)
            {
                var ratio = (double)_mediaPlayer.Time / _mediaPlayer.Length;
                trackPosition.Value = Math.Min(trackPosition.Maximum, (int)(ratio * trackPosition.Maximum));
            }
        }

        private void trackPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length > 0)
            {
                long newTime = _mediaPlayer.Length * trackPosition.Value / trackPosition.Maximum;
                _mediaPlayer.Time = newTime;
            }
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            // 不建議這裡直接更新 trackBar，交由 timer 控制就好
            // 除非你要每 100ms 非同步更新
        }
    }
}
