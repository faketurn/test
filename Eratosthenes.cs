using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eratosthenes
{
    public class Eratosthenes
    {
        public static void Sosuu_keisan(ref int input)
        {
            int not_sosuu = 0;
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                {
                    not_sosuu = input;
                    input = -1;
                }
            }

            if (input != 0 && input != 1)
            {
                if (input == -1)
                {
                    Console.WriteLine("{0}は素数ではありません。\n", not_sosuu);
                }
                else
                {
                    Console.WriteLine("{0}は素数です。\n", input);
                }
            }
            else
            {
                Console.WriteLine("入力は数字の2以上にしてください");
            }
        }
    }
    public class Sosu_input
    {
        static void Main()
        {
            int hantei;
            string input;

            Console.WriteLine("素数判定プログラム");
            do
            {
                Console.WriteLine("2以上の数字を入力してエンターを押してください。");
                input = Console.ReadLine();
                hantei = Int32.Parse(input);

                Eratosthenes.Sosuu_keisan(ref hantei);

            } while (hantei != 0 && hantei != 1);

            /*
            // 配列Hの長さは配列Prime以下で指定する
            int x = 100;
            int[] H = new int[x];
            int[] Prime = new int[x];
            int i;
            int j;
            int p = 0;
            // 配列Hに最小の素数である2から最大値までの値を代入
            for (i = 0; i < H.Length; i++)
            {
                H[i] = i + 2;
            }

            // 配列Hの内容を表示
            Console.WriteLine("配列の内容は以下の通り");
            foreach (int item in H)
            {
                Console.Write(" " + item);
            }

            Console.WriteLine();

            // 添え字iの2乗が配列Hの最大値を上回るまで処理を繰り返す
            // それ以上の数の素数は下記計算の一部が必要ないので別途求める
            for (i = 0; (i * i) < H.Length; i++)
            {
                if (H[i] != 0)
                {
                    // 配列H[i]の値を素数として配列Primeに代入
                    Prime[p] = H[i];

                    for (j = 0; j < H.Length; j++)
                    {
                        // 既に確定した素数の倍数、つまり素数じゃない数を洗い出す
                        // 配列Primeに代入された素数で割り切れたらその数は素数ではないので値に0を代入する
                        if (H[j] != 0 && H[j] % Prime[p] == 0)
                        {
                            H[j] = 0;
                        }
                    }
                    p++;
                }
            }

            // iの2乗までの素数はすでにPrimeに代入されているが、それ以上の数は求まってはいるがPrimeに代入されていない
            // 配列H[i]の値を素数として配列Primeに代入
            for (i = 0; i < H.Length; i++)
            {
                // 上記処理で値が0になった要素以外を配列Primeに代入する
                if (H[i] != 0)
                {
                    Prime[p] = H[i];
                    p++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("上記範囲内の素数は以下の通り");

            foreach (int item in Prime)
            {
                if (item != 0)
                {
                    Console.Write(" " + item);
                }
            }
            Console.WriteLine();
             */
        }
    }
}
