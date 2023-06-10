using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManage
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        int startPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPos += 1;
            MyProgress.Value = startPos;
            PercentLb1.Text = startPos + "%";
            if(MyProgress.Value == 100 ) 
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
                //Show the login window and close the Splash window.
            }
        }

        private void Splash_Load(object sender, EventArgs e)
            //This method will be triggered when the splash window is opened.
        {
            timer1.Start();
        }
    }
}
