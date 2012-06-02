using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbetweenB
{
    public class String_int
    {
        /// <summary>
        /// キーボードから入力された2つの数字（string）をintに変換し、その2つの数字までの数を全て足し算するメソッド
        /// </summary>
        /// <param name="sum">intは値渡しなのでrefで参照渡しにして計算</param>
        /// <param name="str1">1つ目の入力</param>
        /// <param name="str2">2つ目の入力</param>
        public static void String_int_AtoB(ref int sum, string str1, string str2)
        {
            int num1 = 0;
            int num2 = 0;

            // 入力文字列が数字以外の場合の例外処理
            try
            {
                // Int32.Parse()でstringをintに変換できる
                num1 = Int32.Parse(str1);
                num2 = Int32.Parse(str2);
            }
            catch (FormatException exc)
            {
                Console.WriteLine("「べっ、別に数だけを入れてほしくなんか ないんだからねッ！！」");

                // return;行が実行されると、以下の処理が全て省略される
                return;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine("「べっ、別に数だけを入れてほしくなんか ないんだからねッ！！」");

                // return;行が実行されると、以下の処理が全て省略される
                return;
            }
            catch (OverflowException exc)
            {
                Console.WriteLine("「ばっ、バカっ！もっと小さいのを入れてくれないと ダメ……じゃない！！」");

                // return;行が実行されると、以下の処理が全て省略される
                return;
            }

            // 常にnum1 <= num2となるようif文で制御
            if (num1 > num2)
            {
                int t;
                t = num1;
                num1 = num2;
                num2 = t;
            }

            // num1からnum2までを順にsumに足していく。引数のrefで呼び出し側の変数も変更される
            for (int i = num1; i <= num2; i++)
            {
                sum += i;
            }

            // 2つの入力が共にゼロだった場合この処理を行う。
            // このif文がないと、例外処理で返ったのか入力がゼロだったのか判定が出来ない。
            if (sum == 0)
            {
                Console.WriteLine("「あ、あんたは『 {0,0} 』…よ！\n  こっ、こんな恥ずかしいコト…言わせないでよっ！」", sum);
                Console.WriteLine("（訳：入力された数から計算された答えは「{0,0}」です。）", sum);
                Console.WriteLine("\n\n");
            }
        }
    }

    public class AbetweenBmain
    {
        static void Main()
        {
            string first;
            string second;
            int sum = 0;

            // このあたりはおふざけの駄文。
            Console.WriteLine("           『 between計算プログラム ツンデレver. 』\n");
            Console.WriteLine("                                   製作者:faketurn");
            Console.ReadLine();
            Console.WriteLine("\n\n");
            Console.WriteLine("「な、なんであんたがこんなとこにいんのよ！\n  ！？、こ、ここ、これは別にあんたにしてあげる用じゃないから！\n  わ、私用なんだからッ！」\n（訳：これは入力された2つの数字の、双方までの和を求めるプログラムです）");
            Console.WriteLine("\n\n");

            Console.WriteLine("「か、勘違いしないでよね、あんたなんか呼んでないんだからね！」");
            Console.WriteLine("（訳：まず、1つ目の数字を入力してください）");

            // 1つ目の入力をfirstに代入
            first = Console.ReadLine();
            Console.WriteLine("\n\n");

            Console.WriteLine("「さ、さっさとやりなさいよ！人が待ってるんだからぁ！」");
            Console.WriteLine("（訳：次に、2つ目の数字を入力してください）");

            // 2つ目の入力をsecontに代入
            second = Console.ReadLine();
            Console.WriteLine("\n\n");
            
            // staticメソッドなのでクラス名.メソッド名で呼び出す。ここでもsumにrefが必要。
            String_int.String_int_AtoB(ref sum, first, second);

            // 例外処理でreturnが実行された場合、処理を行わない
            if (sum != 0)
            {
                Console.WriteLine("「あ、あんたは『 {0,0} 』…よ！\n  こっ、こんな恥ずかしいコト…言わせないでよっ！」", sum);
                Console.WriteLine("（訳：入力された数から計算された答えは「{0,0}」です。）", sum);
                Console.WriteLine("\n\n");
            }
        }
    }
}
