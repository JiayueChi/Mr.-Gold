using System;

namespace BigGoldMine
{
    class BigGoldMine
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int row = random.Next(0, 10);
            int col = random.Next(0, 10);
            int[,] storage = BigGoldMine.Generate(row, col); //the 2d array to store numbers
            int[,] display = BigGoldMine.Start(); // the 2d array shown to users

            //Intro
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("In 1850, your great great great grandfather's friend Mr. Gold was the worst miner at a mining compnay and");
            Console.WriteLine("his boss decided to fire him. However, he gave Mr. Gold the last chance to keep his job. An ABANDONED");
            Console.WriteLine("mining site was reported to have gold undeground...");
            Console.WriteLine("......");
            Console.WriteLine("The boss gave him a shovel to dig holes into the ground and calculate something weird number in the soil");
            Console.WriteLine("to determine if there's gold around. The number gets bigger when Mr. Gold gets closer to the gold. But it");
            Console.WriteLine("was a bad shovel that will be broken after being used for several times.");
            Console.WriteLine("Will Mr. Gold find the gold and keep his job?");
            Console.WriteLine("......");
            Console.WriteLine("Input X is a for the row number and intput Y is for the columm number.");
            Console.WriteLine("$$$$$ INPUT NUMBER X AND Y FROM 0-9 TO START");

            //Game play
            for (int i = 90; i >= 0; i-=10)
            {
                Console.Write("X?:"); //user input: x (0-9)
                int x = Convert.ToInt16(Console.ReadLine());
                Console.Write("Y?:"); //user input: y (0-9)
                int y = Convert.ToInt16(Console.ReadLine());

                display[x, y] = storage[x, y]; //update the displayed 2d array from the storage array

                if (x==row && y == col) //when the user wins the game
                {
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                    Console.WriteLine("$ Mr. Gold gave the gold to his boss. He kept his job, but the boss kept the gold... $");
                    Console.WriteLine("$ But, should Mr. Gold have done it differently?... Since the site was Abandoned...  $");
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                    break;
                }
                else //to display how many attemps left for the user
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Shovel: " + i + '%');
                    Console.WriteLine("----------");
                }
                BigGoldMine.Display(display); //update the display 2d array and show it to the user
                Console.WriteLine("");
                

                if (i == 0) //when the user loses the game
                {
                    Console.WriteLine("The shovel broke and Mr. Gold was too broke to afford a new one. Mr. Gold was fired...");
                }
            }
            Console.WriteLine("Input anything to exit."); //exiting the game
            Console.Read();

            /* FOR TEST ONLY --- to check the storage 2d array
            for(int i=0; i<10;i++)
            {
                Console.WriteLine("");
                for(int j=0; j<10;j++)
                {
                    Console.Write(storage[i, j]+"(" +i + "," +j+")"+"     |");
                }
            }
            */
        }

        static int[,] Start() //generate the display 2d array with value of all 0
        {
            int[,] display = new int[10, 10];

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    display[i, j] = 0;
                }
            }
            return display;
        }

        static int[,] Generate(int row, int col) //generate the "centrally dense" storage 2d array
        {                                        //the biggest value is randomly generated in a random loacation of the 2d array
            Random random = new Random();        //then generate smaller values around the biggest value into the 2d array
            int gold = random.Next(50, 100);     //the value gets smaller when it gets further away from the position holding the biggest value
                                                 //the deduction of each layer away from the "centre" position is random but within a range see line 107, 125, 143, 161
            int[,] storage = new int[10, 10];    //if the value is smaller than 0, the position will hold the value of 1
            storage[row, col] = gold;

            //upside
            int subUp = 0;
            for (int i=row-1; i>=0; i--)
            {
                for(int j = col -(row-i);j<10;j++)
                {
                    if(i>=0 && i <10 && j >=0 && j <= col+(row-i) && col <10)
                    {
                        storage[i, j] = gold - subUp - random.Next(1, 3);
                        if (storage[i,j]<=0)
                        {
                            storage[i, j] = 1;
                        }
                    }
                }
                subUp += 10;
            }

            //downside
            int subDown = 0;
            for(int i=row+1; i<10;i++)
            {
                for(int j = col - (i - row); j < 10; j++)
                {
                    if(i >= 0 && i < 10 && j >= 0 && j <= col + (i-row) && col < 10)
                    {
                        storage[i, j] = gold - subDown - random.Next(1, 3);
                        if (storage[i, j] <= 0)
                        {
                            storage[i, j] = 1;
                        }
                    }
                }
                subDown += 10;
            }

            //leftside
            int subLeft = 0;
            for(int i = col - 1; i >= 0; i--)
            {
                for(int j = row - (col - i); j < 10; j++)
                {
                    if(i >= 0 && i < 10 && j >= 0 && j <= row+(col-i) && col < 10)
                    {
                        storage[j, i] = gold - subLeft - random.Next(1, 3);
                        if (storage[j,i] <= 0)
                        {
                            storage[j, i] = 1;
                        }
                    }
                }
                subLeft += 10;
            }

            //rightside
            int subRight = 0;
            for(int i = col + 1; i < 10; i++)
            {
                for(int j = row - (i - col); j < 10; j++)
                {
                    if(i >= 0 && i < 10 && j >= 0 && j <= row+(i-col) && col < 10)
                    {
                        storage[j, i] = gold - subRight - random.Next(1, 3);
                        if (storage[j,i] <= 0)
                        {
                            storage[j, i] = 1;
                        }
                    }
                }
                subRight += 10;
            }
            /* FOR TEST ONLY --- to check the position holding the biggest value (expected user input)
            Console.WriteLine(row +","+ col);
            */
            return storage;
        }

        static void Display(int[,] display) //to display the display 2d array
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(display[i, j] + "(" + i + "," + j + ")" + "     |");
                }
            }
        }

    }
}