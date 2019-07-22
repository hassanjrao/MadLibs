using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadLibs_Assignment
{

    public partial class Form2 : Form
    {
        public static string story="";
        int startInd, endInd;
        string wordType;
        public Form2()
        {
            InitializeComponent();
            getStoryFile();
            getTag();
            
        }

        public void getStoryFile()
        {
            string[] files = Directory.GetFiles(@"D:\madlibs-files","*.txt");

            Random rand = new Random();
            
            string randomFile = files[rand.Next(files.Length)];    
            try
            {
                StreamReader sr = new StreamReader(randomFile);

                String line = sr.ReadLine();

                while (line != null)
                {
                    story += line;
                    line = sr.ReadLine();

                }
            }
            catch
            {
                Console.Write("err opening file in frm2");

            }

        }
        public void getTag()
        {
            bool exist=false;
            

            for(int i=0; i<story.Length; i++)
            {
                if (story[i]=='<')
                {
                    exist = true;
                    
                    break;
                }
            }

            if (exist == true)
            {
                
                startInd = story.IndexOf("<");
                endInd = story.IndexOf(">");
                wordType = story.Substring(startInd,endInd-startInd+1);
                lblWord.Text = wordType.ToUpper();
            }
            if (exist==false)
            {
                this.Hide();
                Form3 frm3 = new Form3();
                frm3.Show();
            }
            
        }

        
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            string inputWord = txtBoxInput.Text;
            
            string newStory = story.Replace(wordType,inputWord);
            story = newStory;
            txtBoxInput.Text = "";
            getTag();
        }

      
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
