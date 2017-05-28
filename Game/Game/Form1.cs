using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Scene scene;

        private Timer timerJump;

        private Timer timerGame;

        private Timer timerBlackBall;

        private Timer timerGenFallingObjects;

        private Timer timerMove;

        private bool keyUpDisable;

        private int counter;

        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint | ControlStyles.DoubleBuffer
                | ControlStyles.OptimizedDoubleBuffer, true);
           
            this.Bounds = Screen.PrimaryScreen.Bounds;

            this.DoubleBuffered = true;

            scene = new Scene(Bounds);
                       
            timerJump = new Timer();
            timerJump.Interval = 250;
            timerJump.Tick += new EventHandler(timerJump_Tick);

            timerGame = new Timer();
            timerGame.Interval = 1000;
            timerGame.Tick += new EventHandler(timerGame_Tick);
            timerGame.Start();

            timerBlackBall = new Timer();
            timerBlackBall.Interval = 100;
            timerBlackBall.Tick += new EventHandler(timerBlackBall_Tick);
            
            timerMove = new Timer();
            timerMove.Interval = 100;
            timerMove.Tick += new EventHandler(timerMove_Tick);
            timerMove.Start();

            timerGenFallingObjects = new Timer();
            timerGenFallingObjects.Interval = 1000;
            timerGenFallingObjects.Tick += new EventHandler(timerGenFallingObjects_Tick);
            timerGenFallingObjects.Start();

            player = new SoundPlayer(Game.Properties.Resources.music);
            player.PlayLooping();
           
            counter = 0;
        }

        private void timerGenFallingObjects_Tick(object sender, EventArgs e)
        {
            scene.AddFallingObject();
            Invalidate(true);
        }

       
        private void timerMove_Tick(object sender, EventArgs e)
        {
            scene.MoveFallingObjects();
            scene.RemoveFallingObjects();

            Invalidate(true);

            if (scene.PlayerIsDead())
            {
                EndGame();
            }
           
        }


        private void timerBlackBall_Tick(object sender, EventArgs e)
        {
            if (scene.BlackBall != null)
            {
                scene.MoveBlackBall();
              
            }
            else
            {
                timerBlackBall.Stop();
            }

            Invalidate(true);


            if (scene.PlayerIsDead())
            {
                EndGame();
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            counter++;

             if (scene.GenerateBlackBall())
                {
                    timerBlackBall.Start();
                }

            if (counter% 60== 0)
            {
                scene.UpadteGenAtOnce();
            }

            if (counter % 45 == 0)
            {
                scene.UpdateFallingObjVelocity();
            }

            toolStripProgressBarTimeLeft.Value--;

            if (scene.Player.Score % 50 == 0)
            {
                toolStripProgressBarTimeLeft.Value++;
            }

            Invalidate(true);

            if (toolStripProgressBarTimeLeft.Value == 0)
            {
                EndGame();
            }
        }

        private void timerJump_Tick(object sender, EventArgs e)
        {
            scene.PlayerJumpDown();
            timerJump.Stop();
            keyUpDisable = false;
            Invalidate(true);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode== Keys.Left || e.KeyCode== Keys.Right || e.KeyCode == Keys.Up)
            {
                e.IsInputKey = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Left)
            { 
                scene.MovePlayerLeft();

            }
            else if(e.KeyCode== Keys.Right)
            {
                scene.MovePlayerRight();
                
            }
            else if(e.KeyCode== Keys.Up)
            {
                if (keyUpDisable == false)
                {
                    keyUpDisable = true;
                    scene.PlayerJumpUp();
                    timerJump.Start();
                }
            }
           
            scene.CheckIfPlayerTouchesFallingObj();

            Invalidate(true);

            if (scene.PlayerIsDead())
            {
                EndGame();
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            scene.Draw(e.Graphics);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (scene != null)
            {
                scene.Resize(Bounds);
                               
            }
        }


        private void EndGame()
        {
            timerGame.Stop();
            timerBlackBall.Stop();
            timerJump.Stop();
            timerMove.Stop();
            timerGenFallingObjects.Stop();

            File.AppendAllText("scores.txt", Convert.ToString(scene.Player.Score) +"\n");

            GameEnd dialog = new GameEnd(scene.Player.Score);

                   if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        scene = new Scene(Bounds);

                        toolStripProgressBarTimeLeft.Value = 600;
                        timerGame.Start();
                        timerGenFallingObjects.Start();
                        timerMove.Start();
                        keyUpDisable = false;
                        counter = 0;
                        Invalidate(true);
                    }
                    else
                    {
                        Application.Exit();

                    }
        }


        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLblScore.Text = String.Format(": {0}", scene.Player.Score);
            toolStripStatusLblLifes.Text= String.Format(": {0}", scene.Player.Lifes);

        }

        
    }
}