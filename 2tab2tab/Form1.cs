using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2tab2tab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[][] tab_array_in_double = null;
            int nom_begin = 0;
            string[] tab0 = File.ReadAllLines(@"c:\1.csv", Encoding.Default);
            string[] tab_array_in;
            tab_array_in_double = new string[tab0.Length][];

            for (int i = 0; i < tab0.Length; i++)
            {
                tab_array_in_double[i] = new string[4];
                if (!String.IsNullOrEmpty(tab0[i]))
                {
                    tab_array_in = tab0[i].Split(';');
                    for (int j = 0; j < 4; j++)
                    { tab_array_in_double[i][j] = tab_array_in[j]; }
                }
            }

        }
    }
}
