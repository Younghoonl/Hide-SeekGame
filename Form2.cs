using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hide_SeekGame
{
    public partial class Form2 : Form
    {
        public string WinnerColor
        {
            get; set;
        }
        public Form1 form1 { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label2.Text = WinnerColor;
            if (WinnerColor == "Red")
            {
                this.label2.ForeColor = Color.Red;
            }
            else if (WinnerColor == "Green")
            {
                this.label2.ForeColor = Color.Green;
            }
            else if (WinnerColor == "Blue")
            {
                this.label2.ForeColor = Color.Blue;
            }
            else
            {
                this.label2.ForeColor = Color.Yellow;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            form1.CloseForm();
            this.Close();
            this.Dispose();
        }
    }
}
