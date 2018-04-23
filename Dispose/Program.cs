using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    
    class Program
    { 
        static void Main(string[] args)
        {
            MyArray array = new MyArray(5,6);
            array.InitArray();
            ConsoleKey key;
            do {
                Console.Clear();
                array.ShowArray();
                array.SetCursor();
                key = Console.ReadKey().Key;
                array.Move(key);
            } while (key != ConsoleKey.Escape);
            
        }
    }
}
