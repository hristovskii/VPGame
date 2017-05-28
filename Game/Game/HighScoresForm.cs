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

namespace Game
{
    public partial class HighScoresForm : Form
    {
        public HighScoresForm()
        {
            InitializeComponent();

            if (File.Exists("scores.txt")){
                string[] lines = File.ReadAllLines("scores.txt");
                List<int> scores = new List<int>();

                for (int i = 0;  i < lines.Length; i++)
                {

                    scores.Add(Convert.ToInt32(lines[i]));
                }

                scores = scores.OrderByDescending(c => c).ToList<int>();

                for(int i=0; i<scores.Count && i<5; i++)
                {
                    listBox1.Items.Add(scores[i]);
                }
            }
        }
    }
}
