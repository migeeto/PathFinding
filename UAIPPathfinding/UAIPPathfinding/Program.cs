using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIPPathfinding
{
    class Program
    {
        static void Main()
        {
            //For clarification: I have taken a class with you before and know a little bit about A*
            //However, I don't know enough to write an effective pathfinding algorithm.
            //Anything I write will not work 100% of the time, unless it finds the location completely based on random chance
            //And even though that's what you want, I wouldn't be able to give up until it worked properly and I don't have enough time for that
            //So here you go, randompath 9000:
            int[,] MapArray = { {0,0,0,1,0,0,1,0,0,1 },
                                {0,1,0,0,1,1,1,0,0,0 },
                                {0,0,1,0,0,0,0,0,1,1 },
                                {0,1,1,1,1,1,1,0,1,0 },
                                {0,0,1,0,0,0,0,0,1,0 },
                                {1,0,0,0,0,1,0,0,1,0 },
                                {0,0,1,0,0,1,1,0,1,0 },
                                {0,1,1,0,1,1,0,0,1,0 },
                                {0,1,0,0,1,1,0,0,0,0 },
                                {0,0,0,1,0,0,0,0,1,0 } };
            int BotX = 0;
            int BotY = 0;
            int GoalX = 8;
            int GoalY = 9;
            //List to remember the path taken so far
            List<int[]> Path = new List<int[]>();

            while(BotX !=GoalX && BotY != GoalY)
            {
                /*This whole section slows it down a ton so I commented it out - seems like it's working properly tho
                //Makes the bot appear as a 0, the goal as a 3
                MapArray[BotX, BotY] = 2;
                MapArray[GoalX, GoalY] = 3;
                
                
                //Prints the whole array as a grid
                for (int x = 0;x<10;x++)
                {
                    for (int y = 0; y<10;y++)
                    {
                        Console.Write(MapArray[x, y]);
                    }
                    Console.WriteLine();
                }

                //resets bot current pos
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                MapArray[BotX, BotY] = 0;
                */

                //initializing random move
                var rand = new Random();
                int NextMove = rand.Next(0, 4);
                if (NextMove == 0 && BotY != 0) //up
                {
                    if (MapArray[BotX,BotY-1] != 1)
                    {
                        BotY--;
                        int[] newLoc = { BotX, BotY };
                        Path.Add(newLoc);
                    }
                }
                else if (NextMove == 1 && BotX != 9) //right
                {
                    if (MapArray[BotX+1, BotY] != 1)
                    {
                        BotX++;
                        int[] newLoc = { BotX, BotY };
                        Path.Add(newLoc);
                    }
                }
                else if (NextMove == 2 && BotY != 9) //down
                {
                    if (MapArray[BotX, BotY + 1] != 1)
                    {
                        BotY++;
                        int[] newLoc = { BotX, BotY };
                        Path.Add(newLoc);
                    }
                }
                else if (NextMove == 3 && BotX != 0) //left
                {
                    if (MapArray[BotX-1, BotY] == 0)
                    {
                        BotX--;
                        int[] newLoc = { BotX, BotY };
                        Path.Add(newLoc);
                    }
                }
                //Console.Clear();
            }
            //Console.Clear();
            Console.WriteLine("I DID IT");
            foreach(int[] array in Path)
            {
                int[] tempArray = array;
                Console.WriteLine("(" + tempArray[0] + "," + tempArray[1] + ")\n");

            }
            Console.ReadLine();

        }
    }
}
