using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TimerScreen : Form
    {
        public TimerScreen()
        {
           
            InitializeComponent();
        }

        
        int SecondsCounter = 0;

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

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Seconds.Start();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seconds.Stop();
            
        }

        private void Seconds_Tick(object sender, EventArgs e)
        {
            

            SecondsCounter++;

            if (SecondsCounter >= 60)
            {
                if (SecondsCounter < 3600)
                {
                    lbTime.Text = "00:" + (SecondsCounter / 60).ToString("D2") +":" + (SecondsCounter % 60).ToString("D2"); ;
                   
                }
                else
                {
                    lbTime.Text = (SecondsCounter / 3600).ToString("D2") +":"+ ((SecondsCounter % 3600) / 60).ToString("D2") + ":" + (SecondsCounter % 60).ToString("D2"); 

                  
                }
            }
            else
            {
                lbTime.Text = "00:" +"00:"+ SecondsCounter.ToString("D2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbTime.Text = "00:00:00";
            SecondsCounter = 0;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
    }
}
