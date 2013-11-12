using System;
using System.Windows.Forms;

namespace LeavingWorkCountdownTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DateTime offDate;

        private void Form1_Load(object sender, EventArgs e)
        {

            SetMessage();            
            offDate= new DateTime(int.Parse(GetValue("OffDate_year")), int.Parse(GetValue("OffDate_month")), int.Parse(GetValue("OffDate_day")), int.Parse(GetValue("OffTime_hour")), int.Parse(GetValue("OffTime_min")), int.Parse(GetValue("OffTime_sec")));           
            label1.Text = "Days:";
            this.timer1.Enabled = true;
            this.timer1.Interval = 100;
        }

        private string GetValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key]; 
        }

        private void SetMessage()
        {
            var message = System.Configuration.ConfigurationManager.AppSettings["Message"];
            if (message == null)
            {
                message = "I am off...";
            }
            Message.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            var timeTillGone = offDate.Subtract(DateTime.Now);
            label11.Text = timeTillGone.ToString();
            label2.Text = timeTillGone.TotalDays.ToString();
            label4.Text = timeTillGone.TotalHours.ToString();
            label6.Text = timeTillGone.TotalMinutes.ToString();
            label8.Text = timeTillGone.TotalSeconds.ToString();
            label10.Text = timeTillGone.TotalMilliseconds.ToString();
        }
    }
}
