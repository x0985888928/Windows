namespace VideoPlayer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            btnOpen = new Button();
            btnPlay = new Button();
            btnStop = new Button();
            trackPosition = new TrackBar();
            updPlaybar = new System.Windows.Forms.Timer(components);

            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackPosition).BeginInit();
            SuspendLayout();

            // videoView1
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1005, 440);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";

            // btnOpen
            btnOpen.Location = new Point(12, 446);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(90, 32);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "選取檔案";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;

            // btnPlay
            btnPlay.Location = new Point(108, 446);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(90, 32);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "播放/暫停";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;

            // btnStop
            btnStop.Location = new Point(204, 446);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 32);
            btnStop.TabIndex = 3;
            btnStop.Text = "中止播放";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;

            // trackPosition
            trackPosition.Location = new Point(300, 446);
            trackPosition.Name = "trackPosition";
            trackPosition.Size = new Size(690, 45);
            trackPosition.TabIndex = 4;
            trackPosition.MouseUp += trackPosition_MouseUp;

            // updPlaybar
            updPlaybar.Interval = 1000;
            updPlaybar.Tick += updPlaybar_Tick;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 488);
            Controls.Add(trackPosition);
            Controls.Add(btnStop);
            Controls.Add(btnPlay);
            Controls.Add(btnOpen);
            Controls.Add(videoView1);
            Name = "Form1";
            Text = "影片播放器";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button btnOpen;
        private Button btnPlay;
        private Button btnStop;
        private TrackBar trackPosition;
        private System.Windows.Forms.Timer updPlaybar;
    }
}
