using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }


        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            if (help.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
           
            HighScoresForm form = new HighScoresForm();
            form.ShowDialog();
        }
    }
    }

