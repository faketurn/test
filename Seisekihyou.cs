using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seisekihyou
{
    public class Seito
    {
        public string name;
        public int[] kamoku;
        public int goukei;
        public double heikin;
        public int juni;

        public Seito(string name, int koku, int suu, int ei, int ri, int sya, int juni)
        {
            this.name = name;
            kamoku = new int[] { koku, suu, ei, ri, sya };
            goukei = 0;
            heikin = 0;
            this.juni = juni;

            /* コンストラクタで計算する場合、下記を用いる。が、メソッド化するのとどっちがいいのだろう？
            for (int i = 0; i < kamoku.Length; i++)
            {
                goukei += kamoku[i];
            }
            // int * int は片方をdoubleにするとキャストで答えがdoubleになる
            heikin = (double)goukei / kamoku.Length;
             */
        }

        public int Goukei()
        {
            for (int i = 0; i < kamoku.Length; i++)
            {
                goukei += kamoku[i];
            }
            return goukei;
        }

        public double Heikin()
        {
            // int * int は片方をdoubleにするとキャストで答えがdoubleになる
            return heikin = (double)goukei / kamoku.Length;
        }
    }

    public class Seisekihyou
    {
        static void Main()
        {
            // 生徒が増えたらSeitoクラスで作成し、配列gakkyuuに追加する
            Seito fanna = new Seito("ファナ　", 50, 43, 80, 70, 61, 1);
            Seito alsea = new Seito("アルシエ", 80, 60, 33, 70, 35, 1);
            Seito quest = new Seito("ケスト　", 35, 59, 68, 65, 51, 1);
            Seito palmila = new Seito("パルミラ", 100, 100, 99, 96, 97, 1);
            Seito shalon = new Seito("シャロン", 51, 23, 17, 71, 97, 1);
            Seito sesilis = new Seito("セシリス", 75, 88, 98, 81, 95, 1);

            Seito[] gakkyuu = { fanna, alsea, quest, palmila, shalon, sesilis };

            // ヘッダー部分
            Console.WriteLine("{0,-8}{1,6}{2,4}{3,4}{4,4}{5,4}{6,4}{7,5}{8,4}", "名前", "国語", "数学", "英語", "理科", "社会", "合計点", "平均点", "順位");

            // 生徒個人の成績合計（横軸）
            int soukei = 0;

            //配列gakkyuuの合計点を求めておく。総合計点を求めるためsoukeiに合計点を足していく
            for (int i = 0; i < gakkyuu.Length; i++)
            {
                soukei += gakkyuu[i].Goukei();
            }


            // 合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < gakkyuu.Length - 1; i++)
            {
                for (int j = i + 1; j < gakkyuu.Length; j++)
                {
                    if (gakkyuu[i].goukei > gakkyuu[j].goukei) gakkyuu[j].juni++;
                    if (gakkyuu[i].goukei < gakkyuu[j].goukei) gakkyuu[i].juni++;
                }
            }

            // 配列gakkyuuの表示部分
            for (int i = 0; i < gakkyuu.Length; i++)
            {
                Console.Write("{0,-8}", gakkyuu[i].name);

                // 科目の分だけ繰り返して科目ごとの点数を表示
                for (int j = 0; j < gakkyuu[i].kamoku.Length; j++)
                {
                    Console.Write("{0,6}", gakkyuu[i].kamoku[j]);
                }

                // すでに合計点は求められているのでメソッドではなく、変数の表示をする
                Console.Write("{0,7}", gakkyuu[i].goukei);

                Console.Write("   {0,0:#.00}", gakkyuu[i].Heikin());

                Console.Write("{0,4}位\n", gakkyuu[i].juni);
            }


            // 生徒全員の成績合計（縦軸）
            Console.Write("合計        ");

            // 科目ごとの合計点を計算、表示
            for (int i = 0; i < gakkyuu[i].kamoku.Length; i++)
            {
                int kamokugoukei = 0;
                for (int j = 0; j < gakkyuu.Length; j++)
                {
                    kamokugoukei += gakkyuu[j].kamoku[i];
                }
                Console.Write("{0,6}", kamokugoukei);
            }

            // 総合計点を表示
            Console.Write("{0,7}", soukei);

            // 総平均点を計算、表示
            double souheikin = 0;
            for (int i = 0; i < gakkyuu.Length; i++)
            {
                souheikin += gakkyuu[i].Heikin();
            }
            Console.Write("  {0:#.00}", souheikin);

            // 配列gakkyuuの人数を表示
            Console.WriteLine("{0,4}名", gakkyuu.Length);
        }
    }

}
