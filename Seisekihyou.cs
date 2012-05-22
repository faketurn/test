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

        // public int goukei;
        // public decimal heikin;
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

            // goukei = 0;
            // heikin = 0;
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

            // goukei = 0;
            // heikin = 0;
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
            // 生徒が増えたらSeitoクラスで、リストgakkyuuに追加（Add）する
            List<Seito> gakkyuu = new List<Seito>();
            gakkyuu.Add(new Seito("ファナ　", 50, 43, 80, 70, 61));
            gakkyuu.Add(new Seito("アルシエ", 80, 60, 33, 70, 35));
            gakkyuu.Add(new Seito("ケスト　", 35, 59, 68, 65, 51));
            gakkyuu.Add(new Seito("パルミラ", 100, 100, 99, 96, 97));
            gakkyuu.Add(new Seito("シャロン", 51, 23, 17, 71, 97));
            gakkyuu.Add(new Seito("セシリス", 75, 88, 98, 81, 95));

            // 生徒全員分の総合計と科目別合計点を入れる変数を宣言（縦軸）
            int soukei = 0;
            int kokugokei = 0;
            int suugakukei = 0;
            int eigokei = 0;
            int rikakei = 0;
            int syakaikei = 0;

            // 生徒全員分の総合計と科目別合計点をを計算
            foreach (Seito item in gakkyuu)
            {
                soukei += item.Goukei();
                kokugokei += item.kokugo;
                suugakukei += item.suugaku;
                eigokei += item.eigo;
                rikakei += item.rika;
                syakaikei += item.syakai;
            }

            // 順位をつけるため生徒別に合計点を計算
            // 合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < gakkyuu.Count - 1; i++)
            {
                for (int j = i + 1; j < gakkyuu.Count; j++)
                {
                    if (gakkyuu[i].Goukei() > gakkyuu[j].Goukei()) gakkyuu[j].juni++;
                    if (gakkyuu[i].Goukei() < gakkyuu[j].Goukei()) gakkyuu[i].juni++;
                }
            }

            // ヘッダー部分
            Console.WriteLine("{0,-8}{1,6}{2,4}{3,4}{4,4}{5,4}{6,4}{7,5}{8,4}", "名前", "国語", "数学", "英語", "理科", "社会", "合計点", "平均点", "順位");

            // 生徒別に科目別点と合計点を表示（横軸）
            foreach (Seito item in gakkyuu)
            {
                Console.Write("{0,-8}", item.namae);
                Console.Write("{0,6}", item.kokugo);
                Console.Write("{0,6}", item.suugaku);
                Console.Write("{0,6}", item.eigo);
                Console.Write("{0,6}", item.rika);
                Console.Write("{0,6}", item.syakai);

                Console.Write("{0,7}", item.Goukei());
                Console.Write("   {0,0:#.00}", item.Heikin());
                Console.Write("{0,4}位\n", item.juni);
            }

            // フッター部分
            Console.Write("{0,-10}", "合計");

            // 総合計点soukeiと各科目keiを表示
            Console.Write("{0,6}", kokugokei);
            Console.Write("{0,6}", suugakukei);
            Console.Write("{0,6}", eigokei);
            Console.Write("{0,6}", rikakei);
            Console.Write("{0,6}", syakaikei);
            Console.Write("{0,7}", soukei);

            // 総平均点を表示
            decimal souheikin = (decimal)soukei / 5;
            Console.Write("  {0:#.00}", souheikin);

            // リストgakkyuuの人数を表示
            Console.WriteLine("{0,4}名", gakkyuu.Count);
        }
    }
}