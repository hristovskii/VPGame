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
    public partial class GameEnd : Form
    {
        private int score;

        public GameEnd(int score)
        {
            InitializeComponent();

            this.score = score;
            
            FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void GameEnd_Load(object sender, EventArgs e)
        {
            lblScore1.BackColor = Color.Transparent;
            lblScore1.Text = String.Format("GAME OVER\nScore: {0}", score);
        }

    }
}
