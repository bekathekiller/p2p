using System;
using System.Diagnostics; 
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DirectX.Capture;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace P2P_Video_DirectShow
{

	public class P2PVideoCall : System.Windows.Forms.Form
	{
		private Capture capture = null;
        private Filters filters = new Filters();
		private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem mnuDevices;
		private System.Windows.Forms.MenuItem mnuVideoDevices;
		private System.Windows.Forms.MenuItem mnuAudioDevices;
		private System.Windows.Forms.MenuItem mnuVideoCompressors;
		private System.Windows.Forms.MenuItem mnuAudioCompressors;
		private System.Windows.Forms.MenuItem mnuVideoSources;
		private System.Windows.Forms.MenuItem mnuAudioSources;
		private System.Windows.Forms.Panel panelVideo;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuAudioChannels;
		private System.Windows.Forms.MenuItem mnuAudioSamplingRate;
        private System.Windows.Forms.MenuItem mnuAudioSampleSizes;
		private System.Windows.Forms.MenuItem mnuFrameSizes;
		private System.Windows.Forms.MenuItem mnuFrameRates;
        private System.Windows.Forms.Button btnCue;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem mnuPropertyPages;
		private System.Windows.Forms.MenuItem mnuVideoCaps;
		private System.Windows.Forms.MenuItem mnuAudioCaps;
		private System.Windows.Forms.MenuItem mnuChannel;
		private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuInputType;
        private System.Windows.Forms.PictureBox pictureBox;
        private Label label2;
        private TextBox PeerIP_TXT;
        private Button button_PuchVideo;
        private PictureBox pictureBox_Remote;
        private Button button1;
        private IContainer components;

		public P2PVideoCall()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
			// Start with the first video/audio devices
			// Don't do this in the Release build in case the
			// first devices cause problems.
			#if DEBUG
			capture = new Capture( filters.VideoInputDevices[0], filters.AudioInputDevices[0] ); 
			#endif

			// Update the main menu
			// Much of the interesting work of this sample occurs here

			try { updateMenu(); } 
			catch {}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }
            catch(Exception){}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P2PVideoCall));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mnuDevices = new System.Windows.Forms.MenuItem();
            this.mnuVideoDevices = new System.Windows.Forms.MenuItem();
            this.mnuAudioDevices = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuVideoCompressors = new System.Windows.Forms.MenuItem();
            this.mnuAudioCompressors = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.mnuVideoSources = new System.Windows.Forms.MenuItem();
            this.mnuFrameSizes = new System.Windows.Forms.MenuItem();
            this.mnuFrameRates = new System.Windows.Forms.MenuItem();
            this.mnuVideoCaps = new System.Windows.Forms.MenuItem();
            this.mnuAudioSources = new System.Windows.Forms.MenuItem();
            this.mnuAudioChannels = new System.Windows.Forms.MenuItem();
            this.mnuAudioSamplingRate = new System.Windows.Forms.MenuItem();
            this.mnuAudioSampleSizes = new System.Windows.Forms.MenuItem();
            this.mnuAudioCaps = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuChannel = new System.Windows.Forms.MenuItem();
            this.mnuInputType = new System.Windows.Forms.MenuItem();
            this.mnuPropertyPages = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnCue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PeerIP_TXT = new System.Windows.Forms.TextBox();
            this.button_PuchVideo = new System.Windows.Forms.Button();
            this.pictureBox_Remote = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Location = new System.Drawing.Point(180, 423);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Location = new System.Drawing.Point(283, 423);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuDevices,
            this.menuItem7});
            // 
            // mnuDevices
            // 
            this.mnuDevices.Index = 0;
            this.mnuDevices.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuVideoDevices,
            this.mnuAudioDevices,
            this.menuItem4,
            this.mnuVideoCompressors,
            this.mnuAudioCompressors});
            this.mnuDevices.Text = "Devices";
            // 
            // mnuVideoDevices
            // 
            this.mnuVideoDevices.Index = 0;
            this.mnuVideoDevices.Text = "Video Devices";
            // 
            // mnuAudioDevices
            // 
            this.mnuAudioDevices.Index = 1;
            this.mnuAudioDevices.Text = "Audio Devices";
            this.mnuAudioDevices.Visible = false;
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            this.menuItem4.Visible = false;
            // 
            // mnuVideoCompressors
            // 
            this.mnuVideoCompressors.Index = 3;
            this.mnuVideoCompressors.Text = "Video Compressors";
            this.mnuVideoCompressors.Visible = false;
            // 
            // mnuAudioCompressors
            // 
            this.mnuAudioCompressors.Index = 4;
            this.mnuAudioCompressors.Text = "Audio Compressors";
            this.mnuAudioCompressors.Visible = false;
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuVideoSources,
            this.mnuFrameSizes,
            this.mnuFrameRates,
            this.mnuVideoCaps,
            this.mnuAudioSources,
            this.mnuAudioChannels,
            this.mnuAudioSamplingRate,
            this.mnuAudioSampleSizes,
            this.mnuAudioCaps,
            this.menuItem3,
            this.mnuChannel,
            this.mnuInputType,
            this.mnuPropertyPages,
            this.menuItem8});
            this.menuItem7.Text = "Options";
            // 
            // mnuVideoSources
            // 
            this.mnuVideoSources.Index = 0;
            this.mnuVideoSources.Text = "Video Sources";
            this.mnuVideoSources.Visible = false;
            // 
            // mnuFrameSizes
            // 
            this.mnuFrameSizes.Index = 1;
            this.mnuFrameSizes.Text = "Video Frame Size";
            // 
            // mnuFrameRates
            // 
            this.mnuFrameRates.Index = 2;
            this.mnuFrameRates.Text = "Video Frame Rate";
            this.mnuFrameRates.Click += new System.EventHandler(this.mnuFrameRates_Click);
            // 
            // mnuVideoCaps
            // 
            this.mnuVideoCaps.Index = 3;
            this.mnuVideoCaps.Text = "Video Capabilities...";
            this.mnuVideoCaps.Click += new System.EventHandler(this.mnuVideoCaps_Click);
            // 
            // mnuAudioSources
            // 
            this.mnuAudioSources.Index = 4;
            this.mnuAudioSources.Text = "Audio Sources";
            this.mnuAudioSources.Visible = false;
            // 
            // mnuAudioChannels
            // 
            this.mnuAudioChannels.Index = 5;
            this.mnuAudioChannels.Text = "Audio Channels";
            this.mnuAudioChannels.Visible = false;
            // 
            // mnuAudioSamplingRate
            // 
            this.mnuAudioSamplingRate.Index = 6;
            this.mnuAudioSamplingRate.Text = "Audio Sampling Rate";
            this.mnuAudioSamplingRate.Visible = false;
            // 
            // mnuAudioSampleSizes
            // 
            this.mnuAudioSampleSizes.Index = 7;
            this.mnuAudioSampleSizes.Text = "Audio Sample Size";
            this.mnuAudioSampleSizes.Visible = false;
            // 
            // mnuAudioCaps
            // 
            this.mnuAudioCaps.Index = 8;
            this.mnuAudioCaps.Text = "Audio Capabilities...";
            this.mnuAudioCaps.Visible = false;
            this.mnuAudioCaps.Click += new System.EventHandler(this.mnuAudioCaps_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 9;
            this.menuItem3.Text = "-";
            this.menuItem3.Visible = false;
            // 
            // mnuChannel
            // 
            this.mnuChannel.Index = 10;
            this.mnuChannel.Text = "TV Tuner Channel";
            this.mnuChannel.Visible = false;
            // 
            // mnuInputType
            // 
            this.mnuInputType.Index = 11;
            this.mnuInputType.Text = "TV Tuner Input Type";
            this.mnuInputType.Visible = false;
            this.mnuInputType.Click += new System.EventHandler(this.mnuInputType_Click);
            // 
            // mnuPropertyPages
            // 
            this.mnuPropertyPages.Index = 12;
            this.mnuPropertyPages.Text = "PropertyPages";
            this.mnuPropertyPages.Visible = false;
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 13;
            this.menuItem8.Text = "-";
            this.menuItem8.Visible = false;
            // 
            // panelVideo
            // 
            this.panelVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVideo.Controls.Add(this.pictureBox);
            this.panelVideo.ForeColor = System.Drawing.Color.White;
            this.panelVideo.Location = new System.Drawing.Point(19, 25);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(360, 296);
            this.panelVideo.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(360, 296);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // btnCue
            // 
            this.btnCue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCue.Location = new System.Drawing.Point(77, 423);
            this.btnCue.Name = "btnCue";
            this.btnCue.Size = new System.Drawing.Size(96, 28);
            this.btnCue.TabIndex = 8;
            this.btnCue.Text = "Cue";
            this.btnCue.Visible = false;
            this.btnCue.Click += new System.EventHandler(this.btnCue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Peer IP";
            // 
            // PeerIP_TXT
            // 
            this.PeerIP_TXT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeerIP_TXT.Location = new System.Drawing.Point(84, 332);
            this.PeerIP_TXT.Name = "PeerIP_TXT";
            this.PeerIP_TXT.Size = new System.Drawing.Size(284, 27);
            this.PeerIP_TXT.TabIndex = 12;
            // 
            // button_PuchVideo
            // 
            this.button_PuchVideo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_PuchVideo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_PuchVideo.Location = new System.Drawing.Point(385, 329);
            this.button_PuchVideo.Name = "button_PuchVideo";
            this.button_PuchVideo.Size = new System.Drawing.Size(186, 33);
            this.button_PuchVideo.TabIndex = 11;
            this.button_PuchVideo.Text = "Start Pouching Video";
            this.button_PuchVideo.UseVisualStyleBackColor = true;
            this.button_PuchVideo.Click += new System.EventHandler(this.button_PuchVideo_Click);
            // 
            // pictureBox_Remote
            // 
            this.pictureBox_Remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox_Remote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_Remote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Remote.Location = new System.Drawing.Point(396, 25);
            this.pictureBox_Remote.Name = "pictureBox_Remote";
            this.pictureBox_Remote.Size = new System.Drawing.Size(360, 296);
            this.pictureBox_Remote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Remote.TabIndex = 14;
            this.pictureBox_Remote.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(596, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "End and Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // P2PVideoCall
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(785, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_Remote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PeerIP_TXT);
            this.Controls.Add(this.button_PuchVideo);
            this.Controls.Add(this.btnCue);
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "P2PVideoCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SocketCoder.Com - P2P Video Using DirectShow.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.P2PVideoCall_FormClosing);
            this.Load += new System.EventHandler(this.P2PVideoCall_Load);
            this.panelVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Remote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		private void btnCue_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( capture == null )
					throw new ApplicationException( "Please select a video and/or audio device." );
                if (!capture.Cued)
                    capture.Filename = @"C:\\test.avi"; //txtFilename.Text;
				capture.Cue();
				btnCue.Enabled = false;
				MessageBox.Show( "Ready to capture.\n\nUse Cue() before Start() to " +
					"do all the preparation work that needs to be done to start a " +
					"capture. Now, when you click Start the capture will begin faster " +
					"than if you had just clicked Start. Using Cue() is completely " +
					"optional. The downside to using Cue() is the preview is disabled until " +
					"the capture begins." );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( capture == null )
					throw new ApplicationException( "Please select a video and/or audio device." );
				if ( !capture.Cued )
					capture.Filename = @"C:\\test.avi";
				capture.Start();
				btnCue.Enabled = false;
				btnStart.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( capture == null )
					throw new ApplicationException( "Please select a video and/or audio device." );
				capture.Stop();
				btnCue.Enabled = true;
				btnStart.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void updateMenu()
		{
			MenuItem m;
			Filter f;
			Source s;
			Source current;
			PropertyPage p;
			Control oldPreviewWindow = null;
 
			// Disable preview to avoid additional flashes (optional)
			if ( capture != null )
			{
				oldPreviewWindow = capture.PreviewWindow;
				capture.PreviewWindow = null;
			}

			// Load video devices
			Filter videoDevice = null;
			if ( capture != null )
				videoDevice = capture.VideoDevice;
			mnuVideoDevices.MenuItems.Clear();
			m = new MenuItem( "(None)", new EventHandler( mnuVideoDevices_Click ) );
			m.Checked = ( videoDevice == null );
			//mnuVideoDevices.MenuItems.Add( m );
			for ( int c = 0; c < filters.VideoInputDevices.Count; c++ )
			{
				f = filters.VideoInputDevices[c];
				m = new MenuItem( f.Name, new EventHandler( mnuVideoDevices_Click ) );
				m.Checked = ( videoDevice == f );
				mnuVideoDevices.MenuItems.Add( m );
			}
			mnuVideoDevices.Enabled = ( filters.VideoInputDevices.Count > 0 );

            //// Load audio devices
            //Filter audioDevice = null;
            //if ( capture != null )
            //    audioDevice = capture.AudioDevice;
            //mnuAudioDevices.MenuItems.Clear();
            //m = new MenuItem( "(None)", new EventHandler( mnuAudioDevices_Click ) );
            //m.Checked = ( audioDevice == null );
            //mnuAudioDevices.MenuItems.Add( m );
            //for ( int c = 0; c < filters.AudioInputDevices.Count; c++ )
            //{
            //    f = filters.AudioInputDevices[c];
            //    m = new MenuItem( f.Name, new EventHandler( mnuAudioDevices_Click ) );
            //    m.Checked = ( audioDevice == f );
            //    mnuAudioDevices.MenuItems.Add( m );
            //}
            //mnuAudioDevices.Enabled = ( filters.AudioInputDevices.Count > 0 );


			// Load video compressors
			try
			{
				mnuVideoCompressors.MenuItems.Clear();
				m = new MenuItem( "(None)", new EventHandler( mnuVideoCompressors_Click ) );
				m.Checked = ( capture.VideoCompressor == null );
				mnuVideoCompressors.MenuItems.Add( m );
				for ( int c = 0; c < filters.VideoCompressors.Count; c++ )
				{
					f = filters.VideoCompressors[c];
					m = new MenuItem( f.Name, new EventHandler( mnuVideoCompressors_Click ) );
					m.Checked = ( capture.VideoCompressor == f );
					mnuVideoCompressors.MenuItems.Add( m );
				}
				mnuVideoCompressors.Enabled = ( ( capture.VideoDevice != null ) && ( filters.VideoCompressors.Count > 0 ) );
			}
			catch { mnuVideoCompressors.Enabled = false; }
			
            //// Load audio compressors
            //try
            //{
            //    mnuAudioCompressors.MenuItems.Clear();
            //    m = new MenuItem( "(None)", new EventHandler( mnuAudioCompressors_Click ) );
            //    m.Checked = ( capture.AudioCompressor == null );
            //    mnuAudioCompressors.MenuItems.Add( m );
            //    for ( int c = 0; c < filters.AudioCompressors.Count; c++ )
            //    {
            //        f = filters.AudioCompressors[c];
            //        m = new MenuItem( f.Name, new EventHandler( mnuAudioCompressors_Click ) );
            //        m.Checked = ( capture.AudioCompressor == f );
            //        mnuAudioCompressors.MenuItems.Add( m );
            //    }
            //    mnuAudioCompressors.Enabled = ( ( capture.AudioDevice != null ) && ( filters.AudioCompressors.Count > 0 ) );
            //}
            //catch { mnuAudioCompressors.Enabled = false; }

			// Load video sources
			try 
			{
				mnuVideoSources.MenuItems.Clear();
				current = capture.VideoSource;
				for ( int c = 0; c < capture.VideoSources.Count; c++ )
				{
					s = capture.VideoSources[c];
					m = new MenuItem( s.Name, new EventHandler( mnuVideoSources_Click ) );
					m.Checked = ( current == s );
					mnuVideoSources.MenuItems.Add( m );
				}
				mnuVideoSources.Enabled = ( capture.VideoSources.Count > 0 );
			}
			catch { mnuVideoSources.Enabled = false; }

			// Load audio sources
			try
			{
				mnuAudioSources.MenuItems.Clear();
				current = capture.AudioSource;
				for ( int c = 0; c < capture.AudioSources.Count; c++ )
				{
					s = capture.AudioSources[c];
					m = new MenuItem( s.Name, new EventHandler( mnuAudioSources_Click ) );
					m.Checked = ( current == s );
					mnuAudioSources.MenuItems.Add( m );
				}
				mnuAudioSources.Enabled = ( capture.AudioSources.Count > 0 );
			}
			catch { mnuAudioSources.Enabled = false; }

			// Load frame rates
			try
			{
				mnuFrameRates.MenuItems.Clear();
                int frameRate = 15000;//(int) (capture.FrameRate * 1000);
				m = new MenuItem( "15 fps", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 15000 );
				mnuFrameRates.MenuItems.Add( m );
				m = new MenuItem( "24 fps (Film)", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 24000 );
				mnuFrameRates.MenuItems.Add( m );
				m = new MenuItem( "25 fps (PAL)", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 25000 );
				mnuFrameRates.MenuItems.Add( m );
				m = new MenuItem( "29.997 fps (NTSC)", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 29997 );
				mnuFrameRates.MenuItems.Add( m );
				m = new MenuItem( "30 fps (~NTSC)", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 30000 );
				mnuFrameRates.MenuItems.Add( m );
				m = new MenuItem( "59.994 fps (2xNTSC)", new EventHandler( mnuFrameRates_Click ) );
				m.Checked = ( frameRate == 59994 );
				mnuFrameRates.MenuItems.Add( m );
				mnuFrameRates.Enabled = true;
			}
			catch { mnuFrameRates.Enabled = false; }

			// Load frame sizes
			try
			{
				mnuFrameSizes.MenuItems.Clear();
				Size frameSize = new Size( 320, 240 );//capture.FrameSize;
				m = new MenuItem( "160 x 120", new EventHandler( mnuFrameSizes_Click ) );
				m.Checked = ( frameSize == new Size( 160, 120 ) );
				mnuFrameSizes.MenuItems.Add( m );
				m = new MenuItem( "320 x 240", new EventHandler( mnuFrameSizes_Click ) );
				m.Checked = ( frameSize == new Size( 320, 240 ) );
				mnuFrameSizes.MenuItems.Add( m );
				m = new MenuItem( "640 x 480", new EventHandler( mnuFrameSizes_Click ) );
				m.Checked = ( frameSize == new Size( 640, 480 ) );
				mnuFrameSizes.MenuItems.Add( m );
				m = new MenuItem( "1024 x 768", new EventHandler( mnuFrameSizes_Click ) );
				m.Checked = ( frameSize == new Size( 1024, 768 ) );
				mnuFrameSizes.MenuItems.Add( m );
				mnuFrameSizes.Enabled = true;
			}
			catch { mnuFrameSizes.Enabled = false; }

            //// Load audio channels
            //try
            //{
            //    mnuAudioChannels.MenuItems.Clear();
            //    short audioChannels = capture.AudioChannels;
            //    m = new MenuItem( "Mono", new EventHandler( mnuAudioChannels_Click ) );
            //    m.Checked = ( audioChannels == 1 );
            //    mnuAudioChannels.MenuItems.Add( m );
            //    m = new MenuItem( "Stereo", new EventHandler( mnuAudioChannels_Click ) );
            //    m.Checked = ( audioChannels == 2 );
            //    mnuAudioChannels.MenuItems.Add( m );
            //    mnuAudioChannels.Enabled = true;
            //}
            //catch { mnuAudioChannels.Enabled = false; }

            //// Load audio sampling rate
            //try
            //{
            //    mnuAudioSamplingRate.MenuItems.Clear();
            //    int samplingRate = capture.AudioSamplingRate;
            //    m = new MenuItem( "8 kHz", new EventHandler( mnuAudioSamplingRate_Click ) );
            //    m.Checked = ( samplingRate == 8000 );
            //    mnuAudioSamplingRate.MenuItems.Add( m );
            //    m = new MenuItem( "11.025 kHz", new EventHandler( mnuAudioSamplingRate_Click ) );
            //    m.Checked = ( capture.AudioSamplingRate == 11025 );
            //    mnuAudioSamplingRate.MenuItems.Add( m );
            //    m = new MenuItem( "22.05 kHz", new EventHandler( mnuAudioSamplingRate_Click ) );
            //    m.Checked = ( capture.AudioSamplingRate == 22050 );
            //    mnuAudioSamplingRate.MenuItems.Add( m );
            //    m = new MenuItem( "44.1 kHz", new EventHandler( mnuAudioSamplingRate_Click ) );
            //    m.Checked = ( capture.AudioSamplingRate == 44100 );
            //    mnuAudioSamplingRate.MenuItems.Add( m );
            //    mnuAudioSamplingRate.Enabled = true;
            //}
            //catch { mnuAudioSamplingRate.Enabled = false; } 

            //// Load audio sample sizes
            //try
            //{
            //    mnuAudioSampleSizes.MenuItems.Clear();
            //    short sampleSize = capture.AudioSampleSize;
            //    m = new MenuItem( "8 bit", new EventHandler( mnuAudioSampleSizes_Click ) );
            //    m.Checked = ( sampleSize == 8 );
            //    mnuAudioSampleSizes.MenuItems.Add( m );
            //    m = new MenuItem( "16 bit", new EventHandler( mnuAudioSampleSizes_Click ) );
            //    m.Checked = ( sampleSize == 16 );
            //    mnuAudioSampleSizes.MenuItems.Add( m );
            //    mnuAudioSampleSizes.Enabled = true;
            //}
            //catch { mnuAudioSampleSizes.Enabled = false; }

			// Load property pages
			try
			{
				mnuPropertyPages.MenuItems.Clear();
				for ( int c = 0; c < capture.PropertyPages.Count; c++ )
				{
					p = capture.PropertyPages[c];
					m = new MenuItem( p.Name + "...", new EventHandler( mnuPropertyPages_Click ) );
					mnuPropertyPages.MenuItems.Add( m );
				}
				mnuPropertyPages.Enabled = ( capture.PropertyPages.Count > 0 );
			}
			catch { mnuPropertyPages.Enabled = false; }

			// Load TV Tuner channels
			try
			{
				mnuChannel.MenuItems.Clear();
				int channel = capture.Tuner.Channel;
				for ( int c = 1; c <= 25; c++ )
				{
					m = new MenuItem( c.ToString(), new EventHandler( mnuChannel_Click ) );
					m.Checked = ( channel == c );
					mnuChannel.MenuItems.Add( m );
				}
				mnuChannel.Enabled = true;
			}
			catch { mnuChannel.Enabled = false; }

			// Load TV Tuner input types
			try
			{
				mnuInputType.MenuItems.Clear();
				m = new MenuItem( TunerInputType.Cable.ToString(), new EventHandler( mnuInputType_Click ) );
				m.Checked = ( capture.Tuner.InputType == TunerInputType.Cable );
				mnuInputType.MenuItems.Add( m );
				m = new MenuItem( TunerInputType.Antenna.ToString(), new EventHandler( mnuInputType_Click ) );
				m.Checked = ( capture.Tuner.InputType == TunerInputType.Antenna );
				mnuInputType.MenuItems.Add( m );
				mnuInputType.Enabled = true;
			}
			catch { mnuInputType.Enabled = false; }

			// Enable/disable caps
			mnuVideoCaps.Enabled = ( ( capture != null ) && ( capture.VideoCaps != null ) );
			mnuAudioCaps.Enabled = ( ( capture != null ) && ( capture.AudioCaps != null ) );

			// Check Preview menu option
			//mnuPreview.Checked = ( oldPreviewWindow != null );
			//mnuPreview.Enabled = ( capture != null );

			// Reenable preview if it was enabled before
			if ( capture != null )
				capture.PreviewWindow = oldPreviewWindow;
		}

		private void mnuVideoDevices_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Get current devices and dispose of capture object
				// because the video and audio device can only be changed
				// by creating a new Capture object.
				Filter videoDevice = null;
				Filter audioDevice = null;
				if ( capture != null )
				{
					videoDevice = capture.VideoDevice;
					audioDevice = capture.AudioDevice;
					capture.Dispose();
					capture = null;
				}

				// Get new video device
				MenuItem m = sender as MenuItem;
				videoDevice = ( m.Index>0 ? filters.VideoInputDevices[m.Index-1] : null );

				// Create capture object
				if ( ( videoDevice != null ) || ( audioDevice != null ) )
				{
					capture = new Capture( videoDevice, audioDevice );
					//capture.CaptureComplete += new EventHandler( OnCaptureComplete );
				}

				// Update the menu
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Video device not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioDevices_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Get current devices and dispose of capture object
				// because the video and audio device can only be changed
				// by creating a new Capture object.
				Filter videoDevice = null;
				Filter audioDevice = null;
				if ( capture != null )
				{
					videoDevice = capture.VideoDevice;
					audioDevice = capture.AudioDevice;
					capture.Dispose();
					capture = null;
				}

				// Get new audio device
				MenuItem m = sender as MenuItem;
				audioDevice = ( m.Index>0 ? filters.AudioInputDevices[m.Index-1] : null );

				// Create capture object
				if ( ( videoDevice != null ) || ( audioDevice != null ) )
				{
					capture = new Capture( videoDevice, audioDevice );
					//capture.CaptureComplete += new EventHandler( OnCaptureComplete );
				}

				// Update the menu
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Audio device not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuVideoCompressors_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Change the video compressor
				// We subtract 1 from m.Index beacuse the first item is (None)
				MenuItem m = sender as MenuItem;
				capture.VideoCompressor = ( m.Index>0 ? filters.VideoCompressors[m.Index-1] : null );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Video compressor not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}

		}

		private void mnuAudioCompressors_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Change the audio compressor
				// We subtract 1 from m.Index beacuse the first item is (None)
				MenuItem m = sender as MenuItem;
				capture.AudioCompressor = ( m.Index>0 ? filters.AudioCompressors[m.Index-1] : null );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Audio compressor not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuVideoSources_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Choose the video source
				// If the device only has one source, this menu item will be disabled
				MenuItem m = sender as MenuItem;
				capture.VideoSource = capture.VideoSources[m.Index];
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable to set video source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioSources_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Choose the audio source
				// If the device only has one source, this menu item will be disabled
				MenuItem m = sender as MenuItem;
				capture.AudioSource = capture.AudioSources[m.Index];
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable to set audio source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}


		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			if ( capture != null )
				capture.Stop();
			Application.Exit(); 
		}

		private void mnuFrameSizes_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Disable preview to avoid additional flashes (optional)
				bool preview = (capture.PreviewWindow != null);
				capture.PreviewWindow = null;

				// Update the frame size
				MenuItem m = sender as MenuItem;
				string[] s = m.Text.Split( 'x' );
				Size size = new Size( int.Parse( s[0] ), int.Parse( s[1] ) );
				capture.FrameSize = size;

				// Update the menu
				updateMenu();

				// Restore previous preview setting
				capture.PreviewWindow = ( preview ? panelVideo : null );
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Frame size not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuFrameRates_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				string[] s = m.Text.Split( ' ' );
				capture.FrameRate = double.Parse( s[0] );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Frame rate not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioChannels_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				capture.AudioChannels = (short) Math.Pow( 2, m.Index );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Number of audio channels not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioSamplingRate_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				string[] s = m.Text.Split( ' ' );
				int samplingRate = (int) (double.Parse( s[0] ) * 1000);
				capture.AudioSamplingRate = samplingRate;
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Audio sampling rate not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioSampleSizes_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				string[] s = m.Text.Split( ' ' );
				short sampleSize = short.Parse( s[0] );
				capture.AudioSampleSize = sampleSize;
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Audio sample size not supported.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuPreview_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( capture.PreviewWindow == null )
				{
					//capture.PreviewWindow = panelVideo;
					//mnuPreview.Checked = true;
				}
				else
				{
					//capture.PreviewWindow = null;
					//mnuPreview.Checked = false;
				}
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable to enable/disable preview. \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuPropertyPages_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				capture.PropertyPages[m.Index].Show( this );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable display property page.  \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuChannel_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				capture.Tuner.Channel = m.Index+1;
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable change channel.  \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuInputType_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				capture.Tuner.InputType = (TunerInputType) m.Index;
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable change tuner input type.  \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuVideoCaps_Click(object sender, System.EventArgs e)
		{
			try
			{
				string s;
				s = String.Format(
					"Video Device Capabilities\n" +
					"--------------------------------\n\n" +
					"Input Size:\t\t{0} x {1}\n" +
					"\n" +
					"Min Frame Size:\t\t{2} x {3}\n" +
					"Max Frame Size:\t\t{4} x {5}\n" +
					"Frame Size Granularity X:\t{6}\n" +
					"Frame Size Granularity Y:\t{7}\n" +
					"\n" +
					"Min Frame Rate:\t\t{8:0.000} fps\n" +
					"Max Frame Rate:\t\t{9:0.000} fps\n", 
					capture.VideoCaps.InputSize.Width, capture.VideoCaps.InputSize.Height,
					capture.VideoCaps.MinFrameSize.Width, capture.VideoCaps.MinFrameSize.Height, 
					capture.VideoCaps.MaxFrameSize.Width, capture.VideoCaps.MaxFrameSize.Height, 
					capture.VideoCaps.FrameSizeGranularityX, 
					capture.VideoCaps.FrameSizeGranularityY,
					capture.VideoCaps.MinFrameRate, 
					capture.VideoCaps.MaxFrameRate );
				MessageBox.Show( s );

			}
			catch (Exception ex)
			{
				MessageBox.Show( "Unable display video capabilities.  \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}

		private void mnuAudioCaps_Click(object sender, System.EventArgs e)
		{
			try
			{
				string s;
				s = String.Format(
					"Audio Device Capabilities\n" +
					"--------------------------------\n\n" +
					"Min Channels:\t\t{0}\n" +
					"Max Channels:\t\t{1}\n" +
					"Channels Granularity:\t{2}\n" +
					"\n" +
					"Min Sample Size:\t\t{3}\n" +
					"Max Sample Size:\t\t{4}\n" +
					"Sample Size Granularity:\t{5}\n" +
					"\n" +
					"Min Sampling Rate:\t\t{6}\n" +
					"Max Sampling Rate:\t\t{7}\n" +
					"Sampling Rate Granularity:\t{8}\n",
					capture.AudioCaps.MinimumChannels,
					capture.AudioCaps.MaximumChannels,
					capture.AudioCaps.ChannelsGranularity,
					capture.AudioCaps.MinimumSampleSize, 
					capture.AudioCaps.MaximumSampleSize,
					capture.AudioCaps.SampleSizeGranularity,
					capture.AudioCaps.MinimumSamplingRate,
					capture.AudioCaps.MaximumSamplingRate,
					capture.AudioCaps.SamplingRateGranularity );
				MessageBox.Show( s );

			}
			catch (Exception ex)
			{
				MessageBox.Show( "Unable display audio capabilities.  \n\n" + ex.Message + "\n\n" + ex.ToString() );
			}		
		}

		private void OnCaptureComplete(object sender, EventArgs e)
		{
			// Demonstrate the Capture.CaptureComplete event.
			Debug.WriteLine( "Capture complete." );
		}

        bool isSending = false;
		private void CaptureDone(System.Drawing.Bitmap e)
		{
            try
            {
                this.pictureBox.Image = e;
                //MemoryStream ms = new MemoryStream();
                //pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] buffer = ms.GetBuffer();
                if (isSending)
                ThreadPool.QueueUserWorkItem(new WaitCallback(SendVideoBuffer), pictureBox.Image);
            }
            catch(Exception){}
		}

        private void P2PVideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!stoped)
            {
                try
                {
                    isSending = false;
                    server_sock.Close();
                    ServerThread.Abort();
                }
                catch (Exception) { }

                try
                {
                    capture.PreviewWindow = null;
                    if (capture != null)
                        capture.Stop();
                }
                catch (Exception) { }
            }

        }

        private void button_PuchVideo_Click(object sender, EventArgs e)
        {
            try
            {
                // Start Capturing

                    if (capture != null)
                    {
                        if (capture.PreviewWindow != panelVideo)
                        {
                            capture.PreviewWindow = panelVideo;
                        }
                        capture.FrameEvent2 += new Capture.HeFrame(CaptureDone);
                        capture.GrapImg();

                        PeerIP_TXT.Enabled = false;
                        button_PuchVideo.Enabled = false;
                        mnuDevices.Enabled = false;
                        menuItem7.Enabled = false;
                        isSending = true;
                    }
                

            }
            catch (Exception) { }
        }

        Socket server_sock;
        void server()
        {
            try
            {
                server_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server_sock.Bind(new IPEndPoint(IPAddress.Any, 6000));
                server_sock.Listen(-1);

                while (true)
                {
                    try
                    {
                        Socket new_socket = server_sock.Accept();
                        NetworkStream ns = new NetworkStream(new_socket);
                        pictureBox_Remote.Image = Image.FromStream(ns);
                        ns.Close();
                        new_socket.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch(Exception){}

        }
        void SendVideoBuffer(object bufferIn)
        {
            try
            {
               TcpClient tcp = new TcpClient(PeerIP_TXT.Text, 6000);//
                NetworkStream ns = tcp.GetStream();
                Image buffer = (Image)bufferIn;
                buffer.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);
                ns.Close();
                tcp.Close();
            }
            catch (Exception) { }
        }

        Thread ServerThread;
        private void P2PVideoCall_Load(object sender, EventArgs e)
        {
            try
            {
                PeerIP_TXT.Text = Properties.Settings.Default.P2P_IP;
            }
            catch (Exception) { }

            ServerThread = new Thread(new ThreadStart(server));
            ServerThread.IsBackground = true;
            ServerThread.Start();

            if (capture != null)
            {
                capture.FrameRate = 15;
                capture.FrameSize = new Size(320, 240);
            }
        }
        bool stoped = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                isSending = false;
                server_sock.Close();
                ServerThread.Abort();
            }
            catch (Exception) { }

            try
            {
                capture.PreviewWindow = null;
                if (capture != null)
                    capture.Stop();
            }
            catch (Exception) { }
            stoped = true;
            Application.Exit();

        }

	}
}
