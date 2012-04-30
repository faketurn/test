using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace janken
{
    public class janken
    {
        static void Main()
        {
            string a = "グー";
            string b = "チョキ";
            string c = "パー";
            string keyin;

            Console.WriteLine("じゃんけんをしよう！");
            Console.ReadLine();
            Console.WriteLine("ルールは簡単。グーは「A」、チョキは「B」、パーは「C」だ。\n私に勝てるかな。");
            Console.ReadLine();

            Console.WriteLine("じゃんけん……");
            Console.WriteLine("（アルファベットで入力してね。グーは「A」、チョキは「B」、パーは「C」だよ）");
            keyin = Console.ReadLine();

            Console.WriteLine("ぽん！");
            while (keyin == "a")
            {
                Console.WriteLine("わたし：" + a);
                Console.WriteLine("きみ　：グー");
                Console.ReadLine();

                Console.WriteLine("あいこで……");
                Console.WriteLine("（アルファベットで入力してね。グーは「A」、チョキは「B」、パーは「C」だよ）");
                keyin = Console.ReadLine();
            }
            if (keyin == "b")
            {
                Console.WriteLine("わたし：" + b);
                Console.WriteLine("きみ　：グー");
                Console.ReadLine();
                Console.WriteLine("きみの勝ちだ！");
                Console.ReadLine();
            }
            else if (keyin == "c")
            {
                Console.WriteLine("わたし：" + c);
                Console.WriteLine("きみ　：グー");
                Console.ReadLine();
                Console.WriteLine("きみの負けだね");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("まじめにやらないなら、やめるよ！");
                Console.ReadLine();
            }
        }
    }
}
