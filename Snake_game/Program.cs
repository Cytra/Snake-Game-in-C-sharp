using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    class Program
    {
        static void Main(string[] args)
        {

            //Testing
            int gameSpeed = 150;
            int[] food = new int[2];
            int snakeLength = 1;
            int[] xPositions = new int[100];
            int[] yPositions = new int[100];
            xPositions[0] = 35;
            yPositions[0] = 20;

            bool isGameOn = true;
            bool isWallHit = false;

        
            Console.CursorVisible = false;

            buildwall();
            food = buildFood();

            Console.SetCursorPosition(20, 42);
            Console.WriteLine("Press any arrow key");
            ConsoleKey command = Console.ReadKey().Key;


            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPositions[0], yPositions[0]);
                        xPositions[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPositions[0], yPositions[0]);
                        yPositions[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPositions[0], yPositions[0]);
                        xPositions[0] ++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPositions[0], yPositions[0]);
                        yPositions[0]++;
                        break;

                }

                paintTheSnake(xPositions, yPositions, snakeLength);

                isWallHit = didSnakeHitWall(xPositions[0], yPositions[0]);

                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("The snake hit the wall and it's dead");
                }

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }

                if (xPositions[0] == food[0] && yPositions[0] == food[1])
                {
                    food = buildFood();
                    snakeLength++;
                    Console.SetCursorPosition(20, 20);
                }
                System.Threading.Thread.Sleep(gameSpeed);

            } while (isGameOn);

            Console.ReadKey();
        }

        static void paintTheSnake(int[] xPosition, int[] yPosition, int snakeLengh)
        {


            Console.SetCursorPosition(xPosition[0], yPosition[0]);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine((char)4);



            for (int i = 1; i < snakeLengh + 1; i++)
            {
                Console.SetCursorPosition(xPosition[i], yPosition[i]);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine((char)4);
            }

            Console.SetCursorPosition(xPosition[snakeLengh], yPosition[snakeLengh]);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ");

            for (int i = snakeLengh; i > 0; i--)
            {
                xPosition[i] = xPosition[i - 1];
                yPosition[i] = yPosition[i - 1];
            }
        }

        static bool didSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void buildwall()
        {
            for (int i = 0; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("|");
                Console.SetCursorPosition(70, i);
                Console.Write("|");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
                Console.SetCursorPosition(i, 40);
                Console.Write("-");

            }
        }
        static int[] buildFood()
        {
            int[] location = new int[2];
            int xFood = new Random().Next(2, 70);
            int yFood = new Random().Next(2, 40);
            location[0] = xFood;
            location[1] = yFood;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(xFood,yFood);
            Console.WriteLine((char)6);
            //Commentsdfa sdsd 

            return location;
        }
    }
}
