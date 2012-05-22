using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seisekihyou
{
    public class Seito
    {
        public string namae;
        public int kokugo;
        public int suugaku;
        public int eigo;
        public int rika;
        public int syakai;

        public int goukei;
        public decimal heikin;
        public int juni;

        // デフォルトコンストラクタ
        public Seito()
        {
            this.namae = "";
            this.kokugo = 0;
            this.suugaku = 0;
            this.eigo = 0;
            this.rika = 0;
            this.syakai = 0;

            goukei = 0;
            heikin = 0;
            juni = 1;
        }

        // 引数つきのコンストラクタ（オーバーロードで2種類目のコンストラクタの作り方を示している）
        public Seito(string namae, int kokugo, int suugaku, int eigo, int rika, int syakai)
        {
            this.namae = namae;
            this.kokugo = kokugo;
            this.suugaku = suugaku;
            this.eigo = eigo;
            this.rika = rika;
            this.syakai = syakai;

            goukei = 0;
            heikin = 0;
            juni = 1;
        }

        public int Goukei()
        {
            return kokugo + suugaku + eigo + rika + syakai;
        }

        public decimal Heikin()
        {
            // int * int は片方をdecimalにするとキャストで答えがdecimalになる
            return (decimal)(kokugo + suugaku + eigo + rika + syakai) / 5;
        }
    }

    public class Seisekihyou
    {
        static void Main()
        {
            #region // 生徒が増えたらSeitoクラスで作成し、リストgakkyuuに追加する //
            List<Seito> gakkyuu = new List<Seito>();

            /*
            string namae;
            string kokugo;
            int kokugoi = 0;
            int suugaku;
            int eigo;
            int rika;
            int syakai;

            Console.WriteLine("名前を入力してください");
            namae = Console.ReadLine();
            Console.WriteLine("国語の点数を入力してください");
            kokugo = Console.ReadLine();
            kokugoi = int.Parse(kokugo);

            gakkyuu.Add(new Seito(namae, kokugoi, 1, 1, 1, 1));
            */

            gakkyuu.Add(new Seito("ファナ　", 50, 43, 80, 70, 61));
            gakkyuu.Add(new Seito("アルシエ", 80, 60, 33, 70, 35));
            gakkyuu.Add(new Seito("ケスト　", 35, 59, 68, 65, 51));
            gakkyuu.Add(new Seito("パルミラ", 100, 100, 99, 96, 97));
            gakkyuu.Add(new Seito("シャロン", 51, 23, 17, 71, 97));
            gakkyuu.Add(new Seito("セシリス", 75, 88, 98, 81, 95));

            #endregion
            #region// ヘッダー部分 //
            Console.WriteLine("{0,-8}{1,6}{2,4}{3,4}{4,4}{5,4}{6,4}{7,5}{8,4}", "名前", "国語", "数学", "英語", "理科", "社会", "合計点", "平均点", "順位");

            // 生徒個人の成績合計（横軸）
            int soukei = 0;

            // 順位をつけるため配列gakkyuuの合計点を求めておく。
            // 同時に総合計点を求めるためsoukeiに合計点を足していく
            // foreach使うってこういうことか？
            foreach (Seito kei in gakkyuu)
            {
                soukei += kei.Goukei();
            }

            // 合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < gakkyuu.Count - 1; i++)
            {
                for (int j = i + 1; j < gakkyuu.Count; j++)
                {
                    if (gakkyuu[i].Goukei() > gakkyuu[j].Goukei()) gakkyuu[j].juni++;
                    if (gakkyuu[i].Goukei() < gakkyuu[j].Goukei()) gakkyuu[i].juni++;
                }
            }
            #endregion

            #region // 配列gakkyuuの表示部分 //
            for (int i = 0; i < gakkyuu.Count; i++)
            {
                Console.Write("{0,-8}", gakkyuu[i].namae);

                // 科目ごとの点数を表示
                Console.Write("{0,6}", gakkyuu[i].kokugo);
                Console.Write("{0,6}", gakkyuu[i].suugaku);
                Console.Write("{0,6}", gakkyuu[i].eigo);
                Console.Write("{0,6}", gakkyuu[i].rika);
                Console.Write("{0,6}", gakkyuu[i].syakai);

                // すでに合計点は求められているのでメソッドではなく、変数の表示をする
                Console.Write("{0,7}", gakkyuu[i].Goukei());

                Console.Write("   {0,0:#.00}", gakkyuu[i].Heikin());

                Console.Write("{0,4}位\n", gakkyuu[i].juni);
            }
            #endregion
            #region // 生徒全員の成績合計（縦軸）//
            Console.Write("{0,-10}", "合計");

            int kokugokei = 0;
            int suugakukei = 0;
            int eigokei = 0;
            int rikakei = 0;
            int syakaikei = 0;

            foreach (Seito kei in gakkyuu)
            {
                kokugokei += kei.kokugo;
                suugakukei += kei.suugaku;
                eigokei += kei.eigo;
                rikakei += kei.rika;
                syakaikei += kei.syakai;
            }
            Console.Write("{0,6}{1,6}{2,6}{3,6}{4,6}", kokugokei, suugakukei, eigokei, rikakei, syakaikei);

            // 総合計点を表示
            Console.Write("{0,7}", soukei);

            decimal souheikin = soukei / 5;
            Console.Write("  {0:#.00}", souheikin);

            // 配列gakkyuuの人数を表示
            Console.WriteLine("{0,4}名", gakkyuu.Count);
            #endregion
        }
    }
}