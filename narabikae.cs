using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace narabikae
{
    public class narabikae
    {
        static void Main()
        {
            int[] n = { 3, 4, 2, 5, 1 };
            int i, j, t;
            int kosuu = 5;

            Console.Write("初期の配列は");
            for (int x = 0; x < 5; x++)
            {
                Console.Write(" " + n[x]);
            }

            Console.WriteLine();

            for (i = 0; i < kosuu; i++)
            {
                for (j = i; j < 5; j++)
                {
                    if (n[i] > n[j])
                    {
                        t = n[i];
                        n[i] = n[j];
                        n[j] = t;
                    }
                }
            }

            Console.Write("ソート後の配列は");
            for (int x = 0; x < 5; x++)
            {
                Console.Write(" " + n[x]);
            }
            Console.WriteLine();
        }
    }
}
