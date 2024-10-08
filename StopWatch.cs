using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StopWatch : Form
    {
        public StopWatch()
        {
            InitializeComponent();
        }

        
        private void SetRoundedCornersToForm()
        {
            int radius = 30; // نصف قطر الزوايا الدائرية
            GraphicsPath path = new GraphicsPath();

            // إضافة مستطيل بزوايا دائرية إلى المسار
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path); // تعيين المنطقة المحددة للمسار
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetRoundedCornersToForm(); // إعادة تعيين الزوايا عند تغيير حجم النموذج

        }

        TimeSpan dateTime = new TimeSpan(0, 0, 0);
        TimeSpan timeSpan = new TimeSpan(0, 0, 1);

        private void StopWatch_Load(object sender, EventArgs e)
        {
            cbSeconds.SelectedIndex = 0;
            cbMintues.SelectedIndex = 0;
            cbHours.SelectedIndex = 0;  

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int hour = Convert.ToInt32(cbHours.Text);
            int Minute = Convert.ToInt32(cbMintues.Text);
            int Second = Convert.ToInt32(cbSeconds.Text);

            dateTime = new TimeSpan(hour, Minute, Second);
            lbTime.Text = dateTime.Hours.ToString("D2") + ":" + dateTime.Minutes.ToString("D2") + ":" + dateTime.Seconds.ToString("D2");

            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Convert.ToInt32(dateTime.Seconds + (dateTime.Minutes * 60) + (dateTime.Hours * 3600));
            progressBar1.Value = Convert.ToInt32(dateTime.Seconds + (dateTime.Minutes * 60) + (dateTime.Hours * 3600));
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            dateTime = dateTime.Subtract(timeSpan);
            progressBar1.Value--;
            lbTime.Text = dateTime.Hours.ToString("D2") + ":" + dateTime.Minutes.ToString("D2") + ":" + dateTime.Seconds.ToString("D2");

            if(progressBar1.Value==0)
            {
                timer1.Stop();
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Note";
                notifyIcon1.BalloonTipText = "Ended Time";
                notifyIcon1.ShowBalloonTip(1000);
                return;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        
    }
}
