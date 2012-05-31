using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Quicksort
    {
        public static void QSort(int[] items)
        {
            qs(items, 0, items.Length - 1);
        }

        static void qs(int[] items, int left, int right)
        {
            int i, j;
            int x;
            // tは入れ替え用
            int t;

            i = left;
            j = right;
            // xは軸用。初期値は配列の中央
            x = items[(left + right)/2];

            do
            {
                while ((items[i] < x) && (i < right)) i++;
                while ((x < items[j]) && (j > left)) j--;

                if (i <= j)
                {
                    t = items[i];
                    items[i] = items[j];
                    items[j] = t;
                    i++;
                    j--;
                }
            } while (i <= j);


            if (left < j)
            {
                // qs()のrightの値にjを渡す
                qs(items, left, j);
            }
            if (i < right)
            {
                // qs()のleftの値にiを渡す
                qs(items, i, right);
            }
        }
    }

    class QSdemo
    {
        static void Main()
        {
            int[] demo = { 520, 84, 16848, 2164, 132, 684, 32, 86, 21, 87, 1, 874, 8216541, 2404 };
            int i;

            Console.WriteLine("元の配列は");
            for (i = 0; i < demo.Length; i++)
            {
                Console.WriteLine(demo[i]);
            }

            Console.WriteLine();

            Quicksort.QSort(demo);
            Console.WriteLine("並び替え後の配列は");
            for (i = 0; i < demo.Length; i++)
            {
                Console.WriteLine( demo[i]);
            }
            Console.WriteLine();
        }
    }
}