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
                    Console.Write(array[i, j]);
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
                    currentpos.Row++;
                    break;
                case ConsoleKey.UpArrow:
                    currentpos.Row--;
                    break;
                case ConsoleKey.LeftArrow:
                    currentpos.Colomn--;

                    break;
                case ConsoleKey.RightArrow:
                    currentpos.Colomn++;
                    break;
            }
            if (currentpos.Row > array.GetLength(0) - 1)
            {
                currentpos.Row--;
            }
            else if (currentpos.Colomn > array.GetLength(1) - 1)
            {
                currentpos.Colomn--;
            }
            else if (currentpos.Row < 0)
            {
                currentpos.Row++;
            }
            else if (currentpos.Colomn < 0)
            {
                currentpos.Colomn++;
            }
            else
                Exchange();
            oldpos.Colomn = currentpos.Colomn;
            oldpos.Row = currentpos.Row;
        }

        private void Exchange()
        {
            if (array[oldpos.Row, oldpos.Colomn] < array[currentpos.Row, currentpos.Colomn])
                array[oldpos.Row, oldpos.Colomn]++ ;
            else if (array[oldpos.Row, oldpos.Colomn] > array[currentpos.Row, currentpos.Colomn])
                array[oldpos.Row, oldpos.Colomn]--;
            int tmp = array[oldpos.Row, oldpos.Colomn];
            array[oldpos.Row, oldpos.Colomn] = array[currentpos.Row, currentpos.Colomn];
            array[currentpos.Row, currentpos.Colomn] = tmp;

            if (array[oldpos.Row, oldpos.Colomn] > 9)
            {
                array[oldpos.Row, oldpos.Colomn] = 9;
            }
            if (array[oldpos.Row, oldpos.Colomn]<0)
            {
                array[oldpos.Row, oldpos.Colomn] = 0;
            }
        }
        public void SetCursor()
        {
                Console.SetCursorPosition(currentpos.Colomn, currentpos.Row);
        }

    }
}
