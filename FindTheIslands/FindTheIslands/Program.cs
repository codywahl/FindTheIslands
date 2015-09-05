using System;

namespace FindTheIslands
{
    internal class Program
    {
        private static int rows = 5;
        private static int columns = 5;

        private static int[,] islandsArray = new int[rows, columns];
        private static int[,] visitedArray = new int[rows, columns];

        private static void Main(string[] args)
        {
            PopulateArray();
            PopulateVisited();

            WriteArray(islandsArray);
            Console.WriteLine("");

            int islandCount = CountTheIslands();

            Console.WriteLine("Number of islands: " + islandCount.ToString());
            Console.ReadKey();
        }

        private static int CountTheIslands()
        {
            int islandCount = 0;

            for (int row = 0; row < islandsArray.GetLength(0); row++)
            {
                for (int col = 0; col < islandsArray.GetLength(1); col++)
                {
                    bool isNewIsland = CheckIfItsANewIsland(row, col);

                    if (isNewIsland)
                    {
                        islandCount++;
                    }
                }
            }

            return islandCount;
        }

        private static bool CheckIfItsANewIsland(int row, int col)
        {
            if (islandsArray[row, col] == 1)
            {
                visitedArray[row, col] = 1;

                //Check for upper neighbor island.
                if (row != 0)
                {
                    if (visitedArray[row - 1, col] == 1)
                    {
                        return false;
                    }
                }

                //Check for left neighbor island.
                if (col != 0)
                {
                    if (visitedArray[row, col - 1] == 1)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private static void PopulateArray()
        {
            Random r = new Random();

            for (int row = 0; row < islandsArray.GetLength(0); row++)
            {
                for (int col = 0; col < islandsArray.GetLength(1); col++)
                {
                    islandsArray[row, col] = r.Next(0, 2);
                }
            }
        }

        private static void PopulateVisited()
        {
            for (int row = 0; row < islandsArray.GetLength(0); row++)
            {
                for (int col = 0; col < islandsArray.GetLength(1); col++)
                {
                    visitedArray[row, col] = 0;
                }
            }
        }

        private static void WriteArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row, col] + " ");
                }

                Console.Write("\n");
            }
        }
    }
}