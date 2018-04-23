using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    class MyArray
    {
        int[,] array;
        Position currentpos = new Position();
        Position oldpos = new Position();
        Position cursor = new Position();
        Random r = new Random();
        public MyArray()
        {
            array = new int[5, 5];
        }
        public MyArray(int a, int b)
        {
            array = new int[a, b];
        }

        public void ShowArray()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]+ " ");
                }
                Console.WriteLine();
            }
        }

        public void InitArray()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(0, 10);
                }
            }
        }

        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    currentpos.X++;
                    cursor.Y++;
                    break;
                case ConsoleKey.UpArrow:
                    currentpos.X--;
                    cursor.Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    currentpos.Y--;
                    cursor.X-=2;
                    break;
                case ConsoleKey.RightArrow:
                    cursor.X += 2;
                    break;
            }
            if (currentpos.X > array.GetLength(0) - 1)
            {
                currentpos.X--;
                cursor.Y--;
            }
            else if (currentpos.Y > array.GetLength(1) - 1)
            {
                currentpos.Y--;
                cursor.X -= 2;
            }
            else if (currentpos.X < 0)
            {
                currentpos.X++;
                cursor.Y++;
            }
            else if (currentpos.Y < 0)
            {
                currentpos.Y++;
                cursor.X+=2;
            }
            else
                Exchange();
            oldpos = currentpos;
        }

        private void Exchange()
        {
            if (array[oldpos.X, oldpos.Y] < array[currentpos.X, currentpos.Y])
                array[oldpos.X, oldpos.Y]++;
            else
                array[oldpos.X, oldpos.Y]--;
            int tmp = array[oldpos.X, oldpos.Y];
            array[oldpos.X, oldpos.Y] = array[currentpos.X, currentpos.Y];
            array[currentpos.X, currentpos.Y] = tmp;
        }
        public void SetCursor()
        {
                Console.SetCursorPosition(cursor.X, cursor.Y);
        }

    }
}
