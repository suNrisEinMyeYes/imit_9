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
        Random rnd;
        List<float> values = new List<float>();
        int[] freq = new int[5];
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            chart1.ChartAreas[0].AxisX.Interval = 0;
            rnd = new Random();
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {

            ErrorLbl.Visible = false;
            chart1.Visible = true;
            chart1.Series[0].Points.Clear();
            double A = 0;
            int k = 0;
            values.Clear();
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
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    A = rnd.NextDouble();
                    k = 0;
                    foreach (var value in values)
                    {
                        A -= value;
                        if (A <= 0)
                        {
                            freq[k]++;
                            break;
                        }
                        k++;
                        

                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    chart1.Series[0].Points.AddXY(i, freq[i]/(float)numericUpDown1.Value);
                    freq[i] = 0;
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
