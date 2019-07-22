using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadLibs_Assignment
{
    
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            richTextBox1.Text = Form2.story;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
