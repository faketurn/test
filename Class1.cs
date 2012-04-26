using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BobbleSort
{
    public class Class1
    {
        static void Main()
        {
            int[] n = { 3, 2, 5, 4, 1 };
            int x, a, t;
            int kosuu;

            // kosuuは配列の個数のこと
            kosuu = 5;

            Console.Write("Original array is: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(" " + n[i]);
            }
            Console.WriteLine();

            for (x = 1; x < kosuu; x++)
            {
                for (a = kosuu - 1; a >= x; a--)
                {
                    if (n[a - 1] > n[a])
                    {
                        t = n[a - 1];
                        n[a - 1] = n[a];
                        n[a] = t;
                    }
                }
            }

            Console.Write("Sorted array is: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(" " + n[i]);
            }
            Console.WriteLine();
        }
    }
}
