using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eratosthenes
{
    public class Eratosthenes
    {
        static void Main()
        {
            // 配列Hの長さは配列Prime以下で指定する
            int x = 1000;
            int[] H = new int[x];
            int[] Prime = new int[x];
            int i;
            int j;
            int p = 0;

            Console.WriteLine("配列の内容は以下の通り");

            // 配列Hに2から最大値までの値を代入
            for (i = 0; i < H.Length; i++)
            {
                H[i] = i+2;
                Console.Write(" " + H[i]);
            }

            Console.WriteLine();

            // 添え字iの2乗が配列Hの最大値を上回るまで処理を繰り返す
            for (i = 0; i * i < H.Length; i++)
            {
                if (H[i] != 0)
                {
                    Prime[p] = H[i];

                    for (j = 0; j < H.Length; j++)
                    {
                        if (H[j] != 0 && H[j] % Prime[p] == 0)
                        {
                            H[j] = 0;
                        }
                    }

                    p++;
                }
            }

            // 添え字iが配列Hの最大値を上回るまで処理を繰り返す
            for (i = 0; i < H.Length; i++)
            {
                if (H[i] != 0)
                {
                    Prime[p] = H[i];

                    p++;
                }
                
            }

            Console.WriteLine();
            Console.WriteLine("上記範囲内の素数は以下の通り");

            // 添え字に注意、pじゃないよ
            for (i = 0; i < Prime.Length; i++)
            {
                if (Prime[i] != 0)
                {
                    Console.Write(" " + Prime[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
