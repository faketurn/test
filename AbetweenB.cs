using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbetweenB
{
    public class String_int
    {
        public static void String_int_henkan(ref int sum, string str1, string str2)
        {
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = Int32.Parse(str1);
                num2 = Int32.Parse(str2);
            }
            catch (FormatException exc)
            {
                Console.WriteLine("「べっ、別に数だけを入れてほしくなんか ないんだからねッ！！」");
                return;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine("「べっ、別に数だけを入れてほしくなんか ないんだからねッ！！」");
                return;
            }
            catch (OverflowException exc)
            {
                Console.WriteLine("「ばっ、バカっ！もっと小さいのを入れてくれないと ダメ……じゃない！！」");
                return;
            }
            if (num1 > num2)
            {
                int t;
                t = num1;
                num1 = num2;
                num2 = t;
            }

            for (int i = num1; i <= num2; i++)
            {
                sum += i;
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

            Console.WriteLine("           『 between計算プログラム ツンデレver. 』\n");
            Console.WriteLine("                                   製作者:faketurn");
            Console.ReadLine();
            Console.WriteLine("\n\n");
            Console.WriteLine("「な、なんであんたがこんなとこにいんのよ！\n  ！？、こ、ここ、これは別にあんたにしてあげる用じゃないから！\n  わ、私用なんだからッ！」\n（訳：これは入力された2つの数字の、双方までの和を求めるプログラムです）");
            Console.WriteLine("\n\n");

            Console.WriteLine("「か、勘違いしないでよね、あんたなんか呼んでないんだからね！」");
            Console.WriteLine("（訳：まず、1つ目の数字を入力してください）");
            first = Console.ReadLine();
            Console.WriteLine("\n\n");

            Console.WriteLine("「さ、さっさとやりなさいよ！人が待ってるんだからぁ！」");
            Console.WriteLine("（訳：次に、2つ目の数字を入力してください）");
            second = Console.ReadLine();
            Console.WriteLine("\n\n");
            
            String_int.String_int_henkan(ref sum, first, second);

            if (sum != 0)
            {
                Console.WriteLine("「あ、あんたは『 {0,0} 』…よ！\n  こっ、こんな恥ずかしいコト…言わせないでよっ！」", sum);
                Console.WriteLine("（訳：入力された数から計算された答えは「{0,0}」です。）", sum);
                Console.WriteLine("\n\n");
            }
        }
    }
}
