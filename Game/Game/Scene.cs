using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Scene
    {
        //the player in the game
        public Player Player { get; set; }

        //the black ball in the game
        public BlackBall BlackBall { get; set; }

        //list of falling objects
        public List<FallingObject> FallingObjects { get; set; }

        //the bounds where all the objects can move
        public Rectangle Bounds { get; set; }

        //how many falling objects to generate 
        public int GenAtOnce { get; set; }

        public Scene(Rectangle bounds)
        {
            Bounds = bounds;

            Player = new Player(Bounds);

            FallingObjects = new List<FallingObject>();

            GenAtOnce = 1;
        }

        //moves player right
        public void MovePlayerRight()
        {
            Player.MoveRight();
        }

        //moves player left
        public void MovePlayerLeft()
        {
            Player.MoveLeft();
        }

        //draws all the objects in the scene 
        public void Draw(Graphics g)
        {
            Player.Draw(g);

            for (int i = 0; i < FallingObjects.Count; i++)
            {
                FallingObjects[i].Draw(g);
            }

            if (BlackBall != null)
            {
                BlackBall.Draw(g);
            }
          
        }

        //sets new bounds 
        public void Resize(Rectangle bounds)
        {
            Bounds = bounds;

            Player.Bounds = bounds;
            
            foreach(FallingObject obj in FallingObjects)
            {
                obj.Bounds = bounds;
            }

            if (BlackBall != null)
            {
                BlackBall.Bounds = bounds;
            }

            Player.Position = new Point(Player.Position.X, Bounds.Bottom- Player.HEIGHT-55);
        }

        //the player jumps up
        public void PlayerJumpUp()
        {
            Player.JumpUp();
        }

        //the player jumps back down
        public void PlayerJumpDown()
        {
            Player.JumpDown();

            //checks if the player landed on a black ball
            if (BlackBall != null)
            {
                if (Player.TouchesBlackBall(BlackBall.Position))
                {
                    Player.Lifes--;
                    BlackBall = null;
                }
            }
        }

        //generates a black ball with 1/10 probability
        public bool GenerateBlackBall()
        {
            Random random = new Random();
            int flag = random.Next(101);
            
            if (flag < 10)
            {
                BlackBall = new BlackBall(Bounds);
            }

            //returns true if new black ball has been generated
            return BlackBall != null;
        }

        //moves the black ball
        public void MoveBlackBall()
        {
            BlackBall.Move();

            //if the player has touched the black ball, the black ball disappeares and the player loses life
            if (Player.TouchesBlackBall(BlackBall.Position))
            {
                Player.Lifes--;
                BlackBall = null;
            }
            else if(BlackBall.Position.X>= Bounds.Right) //the black ball is removed if it is outside the bounds
            {
                BlackBall = null;
            }
        }

        //removes the falling objects which are outside the bounds or have touched the player
        public void RemoveFallingObjects()
        {
           List<FallingObject> toRemove = new List<FallingObject>();

            CheckIfPlayerTouchesFallingObj();

            for(int i=0; i< FallingObjects.Count; i++)  
            {
               if (FallingObjects[i].HitTheFloor())
                {
                   toRemove.Add(FallingObjects[i]);
                }
            }

            foreach(FallingObject obj in toRemove)
            {
                FallingObjects.Remove(obj);
            }

         }

        //updates the number of falling objects that will be generate (max is 5)
        public void UpadteGenAtOnce()
        {
            if (GenAtOnce < 5)
            {
                GenAtOnce++;
            }
        }

        //updates the velocity of the falling objects
        public void UpdateFallingObjVelocity()
        {
            FallingObject.UpdateVelocity();
        }

        //checks if player touched some falling object and updates its score and life depending on the object it touched
        public void CheckIfPlayerTouchesFallingObj()
        {
            List<FallingObject> toRemove = new List<FallingObject>();

            for (int i = 0; i < FallingObjects.Count; i++)
            {
                if (FallingObjects[i].Touches(Player.Position, Player.WIDTH, Player.HEIGHT))
                {
                    if (FallingObjects[i].GetCode() == 'F') //if the player touched flower, the score is incremented
                    {
                        Player.Score++;
                    }
                    else if (FallingObjects[i].GetCode() == 'M')// if the player touched monster, the number of lifes  decrements
                    {
                        Player.Lifes--;
                        
                    }
                    else if (FallingObjects[i].GetCode() == 'S') //if the player touched a star, the number of lifes increments
                    {
                        Player.Lifes++;
                        
                    }
                    toRemove.Add(FallingObjects[i]); //adds the objects the player has touched to the list to be removed
                }
            }

            //removes all of the objects the player has touched
            foreach (FallingObject obj in toRemove)
            {
                FallingObjects.Remove(obj);
            }
        }

        //returns true if the player is dead
        public bool PlayerIsDead()
        {
            return Player.IsDead();
        }

         
        //adds new falling objects (49/100 probability it would be monster or flower and 2/100 it would be a star)
        public void AddFallingObject()
        {
            Random random = new Random();

            Point position; 

            int oldSize = FallingObjects.Count;

            int flag = random.Next(101);

            
            while(FallingObjects.Count!= oldSize + GenAtOnce) //new falling objects are added until the number of falling objects is 
                                                                //the old number + the number of new objects that should be added
            {
               
                if (2< flag && flag< 51)
                    {
                    position = new Point(random.Next(0, Bounds.Right-Flower.WIDTH), Bounds.Top);

                    if (shouldAdd(position, Flower.WIDTH, Flower.HEIGHT))
                        {
                            FallingObjects.Add(new Flower(Bounds, position));
                             flag = random.Next(101);
                        }
                    }
                 else if(flag>51)
                    {
                    position = new Point(random.Next(0, Bounds.Right-Monster.WIDTH), Bounds.Top);

                    if (shouldAdd(position, Monster.WIDTH, Monster.HEIGHT))
                        {
                           FallingObjects.Add(new Monster(Bounds, position));
                            flag = random.Next(101);
                         }
                    }
                else
                {
                    position = new Point(random.Next(0, Bounds.Right-Star.WIDTH), Bounds.Top);

                    if (shouldAdd(position, Star.WIDTH, Star.HEIGHT))
                    {
                        FallingObjects.Add(new Star(Bounds, position));
                        flag = random.Next(101);
                    }
                }
                }
            }

        //returns true if the falling object doesn't touch any of the other falling objects in the list
        private bool shouldAdd(Point position, int width, int height)
        {
            foreach (FallingObject obj in FallingObjects)
            {
                if (obj.Touches(position, width, height)) //chekcs if the falling object touches the other falling object
                {
                    return false;
                    
                }
            }

            return true;
        }

        //moves all the falling objects 
        public void MoveFallingObjects()
        {
            foreach(FallingObject obj in FallingObjects)
            {
                obj.Move();
            }
        }
      
       
    }
}
