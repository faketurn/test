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
        public int soukei;
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
            return this.kokugo + this.suugaku + this.eigo + this.rika + this.syakai;
        }

        public decimal Heikin()
        {
            // int * int は片方をdecimalにするとキャストで答えがdecimalになる
            return (decimal)(this.kokugo + this.suugaku + this.eigo + this.rika + this.syakai) / 5;
        }
    }

    public class Kamoku
    {
        List<Seito> gakkyuu;
        public int kokugo;
        public int suugaku;
        public int eigo;
        public int rika;
        public int syakai;
        public int soukei;

        public double heikokugo;
        public double heisuugaku;
        public double heieigo;
        public double heirika;
        public double heisyakai;
        public double heisoukei;

        public Kamoku()
        {
            kokugo = 0;
            suugaku = 0;
            eigo = 0;
            rika = 0;
            syakai = 0;
            soukei = 0;

            heikokugo = 0;
            heisuugaku = 0;
            heieigo = 0;
            heirika = 0;
            heisyakai = 0;
        }

        public Kamoku(List<Seito> gakkyuu)
        {
            this.gakkyuu = gakkyuu;
            kokugo = 0;
            suugaku = 0;
            eigo = 0;
            rika = 0;
            syakai = 0;
            soukei = 0;

            heikokugo = 0;
            heisuugaku = 0;
            heieigo = 0;
            heirika = 0;
            heisyakai = 0;
        }

        public void Goukei()
        {
            foreach (Seito item in gakkyuu)
            {
                this.kokugo += item.kokugo;
                this.suugaku += item.suugaku;
                this.eigo += item.eigo;
                this.rika += item.rika;
                this.syakai += item.syakai;
            }
            soukei = kokugo + suugaku + eigo + rika + syakai;
        }

        public void Heikin()
        {
            heikokugo = kokugo / gakkyuu.Count;
            heisuugaku = suugaku / gakkyuu.Count;
            heieigo = eigo / gakkyuu.Count;
            heirika = rika / gakkyuu.Count;
            heisyakai = syakai / gakkyuu.Count;
            heisoukei = soukei / 5;
        }
    }

    public class Seisekihyou
    {
        static void Main()
        {
            // 生徒が増えたらSeitoクラスで、リストgakkyuuに追加（Add）する
            List<Seito> gakkyuu = new List<Seito>();
            gakkyuu.Add(new Seito("ファナ　", 70, 98, 30, 15, 8));
            gakkyuu.Add(new Seito("アルシエ", 98, 30, 23, 10, 5));
            gakkyuu.Add(new Seito("ケスト　", 15, 15, 20, 65, 51));
            gakkyuu.Add(new Seito("パルミラ", 0, 0, 32, 18, 99));
            gakkyuu.Add(new Seito("シャロン", 22, 43, 87, 15, 30));
            gakkyuu.Add(new Seito("セシリス", 18, 3, 99, 20, 11));

            // Kamokuクラスのオブジェクトkeiを引数付きコンストラクタで初期化する
            Kamoku kei = new Kamoku(gakkyuu);

            // オブジェクトkeiを通して合計と平均メソッドを計算し、各インスタンス変数に値を代入
            kei.Goukei();
            kei.Heikin();

            // OrderByDescendingメソッドで降順にgakkyuuの要素を並び替えし、sortedに代入。これ以降、sortedを参照する。
            List<Seito> sorted = gakkyuu.OrderByDescending(u => u.Goukei()).ToList();

            // 順位をつけるため生徒別に合計点を計算
            // 合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[i].Goukei() > sorted[j].Goukei()) sorted[j].juni++;
                    if (sorted[i].Goukei() < sorted[j].Goukei()) sorted[i].juni++;
                }
            }

            // ヘッダー部分
            Console.WriteLine("{0,-8}{1,6}{2,4}{3,4}{4,4}{5,4}{6,4}{7,5}{8,4}", "名前", "重戦", "剣士", "狩人", "僧侶", "魔術", "合計点", "平均点", "順位");

            // 生徒別に項目の値を表示（横軸）
            foreach (Seito i in sorted)
            {
                Console.Write("{0,-8}", i.namae);
                Console.Write("{0,6}", i.kokugo);
                Console.Write("{0,6}", i.suugaku);
                Console.Write("{0,6}", i.eigo);
                Console.Write("{0,6}", i.rika);
                Console.Write("{0,6}", i.syakai);

                Console.Write("{0,7}", i.Goukei());
                Console.Write("   {0,0:#.00}", i.Heikin());
                Console.Write("{0,4}位\n", i.juni);
            }

            // フッター部分
            Console.Write("{0,-10}", "合計");
            Console.Write("{0,6}", kei.kokugo);
            Console.Write("{0,6}", kei.suugaku);
            Console.Write("{0,6}", kei.eigo);
            Console.Write("{0,6}", kei.rika);
            Console.Write("{0,6}", kei.syakai);
            Console.Write("{0,7}", kei.soukei);
            Console.Write("  {0:#.00}", kei.heisoukei);
            Console.WriteLine("{0,4}名", gakkyuu.Count);
        }
    }
}