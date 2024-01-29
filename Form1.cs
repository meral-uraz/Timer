using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stopwatch stopwatch = new Stopwatch();
        string StateS = "START";
        int hour = 0, minute = 0, second = 0;
        double splits = 0;

        private void txtState_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            if (StateS == "START")
            {
                txtState.Text = "STOP";
                StateS = "STOP";
                timer1.Start();
            }
            else if (StateS == "STOP")
            {
                txtState.Text = "START";
                StateS = "START";
                timer1.Stop();
            }
        }

        int rcr = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            rcr++;
            lsTimes.Items.Add(rcr + ": " + lbHour.Text + ":" + lbMinute.Text + ":" + lbSecond.Text + "." + lbSplit.Text);
            lsTimes.SelectedIndex = lsTimes.Items.Count - 1;
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            lsTimes.Items.Clear();
            rcr = 0;
        }

        private void txtReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            hour = 0;
            minute = 0;
            second = 0;
            txtState.Text = "START";
            StateS = "START";

            lbHour.Text = "0";
            lbMinute.Text = "0";
            lbSecond.Text = "0";
            lbSplit.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            splits += 1;
            lbSplit.Text = Convert.ToString(Convert.ToInt16(splits));
            if (splits>=9)
            {
                splits = 0;
                second++;
                lbSecond.Text = Convert.ToString(second);
            }
            if (second == 60)
            {
                second = -1;
                minute++;
            }
            else if (minute == 60)
            {
                minute = 0;
                second = 0;
                hour++;
            }
            lbHour.Text = Convert.ToString(hour);
            lbMinute.Text = Convert.ToString(minute);
            lbSecond.Text = Convert.ToString(second);
            lbSplit.Text = Convert.ToString(Convert.ToInt16(splits));
        }
    }
}