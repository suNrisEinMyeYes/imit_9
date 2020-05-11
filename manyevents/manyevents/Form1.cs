using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace manyevents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            chart1.ChartAreas[0].AxisX.Interval = 0;
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            ErrorLbl.Visible = false;
            chart1.Visible = true;
            chart1.Series[0].Points.Clear();
            List<float> values = new List<float>();
            values.Add(float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat));
            values.Add(float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat));
            values.Add(float.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat));
            values.Add(float.Parse(textBox4.Text, CultureInfo.InvariantCulture.NumberFormat));
            values.Add(float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat));
            var SumToCheck = 0f;
            foreach (var value in values)
            {
                SumToCheck += value;
            }
            if (SumToCheck == 1f)
            {
                var x = 0.1;
                foreach (var value in values)
                {
                    
                    chart1.Series[0].Points.AddXY(x, value);
                    x += 0.2;
                }
            }
            else
            {
                chart1.Visible = false;
                ErrorLbl.Visible = true;
            }
            
            
            

        }
    }
}
