using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seisekihyou
{
    #region // 生徒個人クラス
    /// <summary>
    /// 生徒個人クラス
    /// </summary>
    public class Seito
    {
        /// <summary>
        /// 生徒個人の名前
        /// </summary>
        public string namae;

        /// <summary>
        /// 生徒個人の国語の点
        /// </summary>
        public int kokugo;

        /// <summary>
        /// 生徒個人の数学の点
        /// </summary>
        public int suugaku;

        /// <summary>
        /// 生徒個人の英語の点
        /// </summary>
        public int eigo;

        /// <summary>
        /// 生徒個人の理科の点
        /// </summary>
        public int rika;

        /// <summary>
        /// 生徒個人の社会の点
        /// </summary>
        public int syakai;

        /// <summary>
        /// 生徒個人の順位
        /// </summary>
        public int juni;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Seito()
        {
            this.namae = "";
            this.kokugo = 0;
            this.suugaku = 0;
            this.eigo = 0;
            this.rika = 0;
            this.syakai = 0;
            juni = 1;
        }

        /// <summary>
        ///  引数つきのコンストラクタ（オーバーロードで2種類目のコンストラクタの作り方を示している）
        /// </summary>
        /// <param name="namae">生徒個人の名前</param>
        /// <param name="kokugo">生徒個人の国語の点</param>
        /// <param name="suugaku">生徒個人の数学の点</param>
        /// <param name="eigo">生徒個人の英語の点</param>
        /// <param name="rika">生徒個人の理科の点</param>
        /// <param name="syakai">生徒個人の社会の点</param>
        public Seito(string namae, int kokugo, int suugaku, int eigo, int rika, int syakai)
        {
            this.namae = namae;
            this.kokugo = kokugo;
            this.suugaku = suugaku;
            this.eigo = eigo;
            this.rika = rika;
            this.syakai = syakai;
            juni = 1;
        }

        /// <summary>
        /// 生徒個人の五教科の合計点
        /// </summary>
        /// <returns>変数なしの実行結果を返す</returns>
        public int Goukei()
        {
            return this.kokugo + this.suugaku + this.eigo + this.rika + this.syakai;
        }

        /// <summary>
        /// 生徒個人の五教科の合計点の教科あたりの平均点
        /// </summary>
        /// <returns>変数なしの実行結果を返す</returns>
        public decimal Heikin()
        {
            // int * int は片方をdecimalにするとキャストで答えがdecimalになる
            return (decimal)(this.kokugo + this.suugaku + this.eigo + this.rika + this.syakai) / 5;
        }
    }
    #endregion

    #region // 科目集計クラス
    /// <summary>
    /// 科目集計クラス
    /// </summary>
    public class Kamoku
    {
        /// <summary>
        /// 生徒の成績の一覧
        /// </summary>
        List<Seito> gakkyuu;

        #region // 五教科の合計点数のインスタンス変数群 //
        /// <summary>
        /// 国語の総計点
        /// </summary>
        public int soukei_kokugo;

        /// <summary>
        /// 数学の総計点
        /// </summary>
        public int soukei_suugaku;

        /// <summary>
        /// 英語の総計点
        /// </summary>
        public int soukei_eigo;

        /// <summary>
        /// 理科の総計点
        /// </summary>
        public int soukei_rika;

        /// <summary>
        /// 社会の総計点
        /// </summary>
        public int soukei_syakai;

        /// <summary>
        /// 科目すべての総計点
        /// </summary>
        public int soukei;
        #endregion

        #region // 五教科の平均点数のインスタンス変数群 //
        /// <summary>
        /// 国語の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heikokugo;

        /// <summary>
        /// 数学の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heisuugaku;

        /// <summary>
        /// 英語の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heieigo;

        /// <summary>
        /// 理科の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heirika;

        /// <summary>
        /// 社会の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heisyakai;

        /// <summary>
        /// 平均の総計点の生徒ごとの平均点
        /// </summary>
        public decimal heisoukei;

        /// <summary>
        /// 平均の平均の平均
        /// </summary>
        public decimal heiheikei;

        /// <summary>
        /// 平均の合計の平均
        /// </summary>
        public decimal heigouheikei;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Kamoku()
        {
            gakkyuu = new List<Seito>();
            soukei_kokugo = 0;
            soukei_suugaku = 0;
            soukei_eigo = 0;
            soukei_rika = 0;
            soukei_syakai = 0;
            soukei = 0;

            heikokugo = 0;
            heisuugaku = 0;
            heieigo = 0;
            heirika = 0;
            heisyakai = 0;
            heiheikei = 0;
            heigouheikei = 0;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gakkyuu">生徒の成績の一覧</param>
        public Kamoku(List<Seito> gakkyuu)
        {
            this.gakkyuu = gakkyuu;
            soukei_kokugo = 0;
            soukei_suugaku = 0;
            soukei_eigo = 0;
            soukei_rika = 0;
            soukei_syakai = 0;
            soukei = 0;

            heikokugo = 0;
            heisuugaku = 0;
            heieigo = 0;
            heirika = 0;
            heisyakai = 0;
            heiheikei = 0;
            heigouheikei = 0;
        }

        /// <summary>
        /// 科目ごとの合計
        /// </summary>
        public void Goukei()
        {
            foreach (Seito item in gakkyuu)
            {
                this.soukei_kokugo += item.kokugo;
                this.soukei_suugaku += item.suugaku;
                this.soukei_eigo += item.eigo;
                this.soukei_rika += item.rika;
                this.soukei_syakai += item.syakai;
            }
        }

        /// <summary>
        /// 科目ごとの平均
        /// </summary>
        public void Heikin()
        {
            if (gakkyuu.Count != 0)
            {
                heikokugo = (decimal)soukei_kokugo / gakkyuu.Count;
                heisuugaku = (decimal)soukei_suugaku / gakkyuu.Count;
                heieigo = (decimal)soukei_eigo / gakkyuu.Count;
                heirika = (decimal)soukei_rika / gakkyuu.Count;
                heisyakai = (decimal)soukei_syakai / gakkyuu.Count;
            }
        }

        /// <summary>
        /// 合計値をまとめた総合計
        /// </summary>
        public void Soukei()
        {
            soukei = soukei_kokugo + soukei_suugaku + soukei_eigo + soukei_rika + soukei_syakai;
        }

        /// <summary>
        /// 総合計値を教科数で割った平均
        /// </summary>
        public void Soukei_heikin()
        {
            if (gakkyuu.Count != 0)
            {
                heisoukei = (decimal)soukei / 5;
            }
        }

        /// <summary>
        /// 総合計の平均と総平均の平均
        /// </summary>
        public void Heikin_goukei()
        {
            heiheikei = heikokugo + heisuugaku + heieigo + heirika + heisyakai;
            heigouheikei = heiheikei / gakkyuu.Count;
        }
    }
    #endregion

    #region // 順位付けをクラス
    /// <summary>
    /// 順位付けをクラス
    /// </summary>
    public class Junituke
    {
        /// <summary>
        /// 生徒の順位
        /// </summary>
        public int juni;

        /// <summary>
        /// ソート済みのSeitoクラスのリスト配列を引数にもらう枠としてのリスト配列
        /// </summary>
        public List<Seito> sorted;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Junituke()
        {
            juni = 1;
            sorted = new List<Seito>();
        }

        /// <summary>
        /// Seitoクラスのリスト配列を引数に持つコンストラクタ
        /// </summary>
        /// <param name="sorted">Seitoクラスのリスト配列</param>
        public Junituke(List<Seito> sorted)
        {
            juni = 1;
            this.sorted = sorted;
        }

        /// <summary>
        /// 順位付けアルゴリズムを利用
        /// </summary>
        public void Juni()
        {
            // 順位をつけるため生徒別に合計点を計算。合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            // 分からんなら「順位付け　アルゴリズム」でググレ
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[i].Goukei() > sorted[j].Goukei()) sorted[j].juni++;
                    if (sorted[i].Goukei() < sorted[j].Goukei()) sorted[i].juni++;
                }
            }
        }
    }
    #endregion

    #region // メインメソッドを擁するクラス
    /// <summary>
    /// メインメソッドを擁するクラス
    /// </summary>
    public class Seisekihyou
    {
        static void Main()
        {
            #region // ここから入力部分
            // 生徒が増えたらSeitoクラスで、リストgakkyuuに追加（Add）する
            List<Seito> gakkyuu = new List<Seito>();
            gakkyuu.Add(new Seito("ファナ　", 70, 98, 30, 15, 8));
            gakkyuu.Add(new Seito("アルシエ", 98, 30, 23, 10, 5));
            gakkyuu.Add(new Seito("ケスト　", 15, 15, 20, 65, 51));
            gakkyuu.Add(new Seito("パルミラ", 0, 0, 32, 18, 99));
            gakkyuu.Add(new Seito("シャロン", 22, 43, 87, 15, 30));
            gakkyuu.Add(new Seito("セシリス", 18, 3, 99, 20, 11));
            #endregion // 入力部分終わり

            #region // ここから計算部分
            // オブジェクトkamoku_gotoを通して合計と平均メソッドを計算し、各インスタンス変数に値を代入
            Kamoku kamoku_goto = new Kamoku(gakkyuu);
            kamoku_goto.Goukei();
            kamoku_goto.Heikin();
            kamoku_goto.Soukei();
            kamoku_goto.Soukei_heikin();
            kamoku_goto.Heikin_goukei();

            // OrderByDescendingメソッドで降順にgakkyuuの要素を並び替えし、sortedに代入。以降、sortedを参照する。
            List<Seito> sorted = gakkyuu.OrderByDescending(u => u.Goukei()).ToList();

            // sortedに対し、順位を付けるメソッドを実行
            Junituke jun = new Junituke(sorted);
            jun.Juni();
            #endregion // 計算部分終わり

            #region // ここから表示部分
            Console.WriteLine(
                "{0,-8}{1,6}{2,4}{3,4}{4,4}{5,4}{6,4}{7,5}{8,4}",
                "名前",
                "重戦",
                "剣士",
                "狩人",
                "僧侶",
                "魔術",
                "合計点",
                "平均点",
                "順位");

            // 生徒別に表示
            foreach (Seito hitori in sorted)
            {
                Console.Write(
                    "{0,-8}{1,6}{2,6}{3,6}{4,6}{5,6}{6,7}   {7,0:#.00}{8,4}位\n",
                    hitori.namae,
                    hitori.kokugo,
                    hitori.suugaku,
                    hitori.eigo,
                    hitori.rika,
                    hitori.syakai,
                    hitori.Goukei(),
                    hitori.Heikin(),
                    hitori.juni);
            }

            // フッター合計
            Console.Write(
                "{0,-10}{1,6}{2,6}{3,6}{4,6}{5,6}{6,7}  {7,0:#.00}  \n",
                "合計",
                kamoku_goto.soukei_kokugo,
                kamoku_goto.soukei_suugaku,
                kamoku_goto.soukei_eigo,
                kamoku_goto.soukei_rika,
                kamoku_goto.soukei_syakai,
                kamoku_goto.soukei,
                kamoku_goto.heisoukei);

            // フッター平均
            Console.Write(
                "{0,-10} {1,0:#.00} {2,0:#.00} {3,0:#.00} {4,0:#.00} {5,0:#.00} {6,0:#.00}   {7,0:#.00}{8,4}名\n",
                "平均",
                kamoku_goto.heikokugo,
                kamoku_goto.heisuugaku,
                kamoku_goto.heieigo,
                kamoku_goto.heirika,
                kamoku_goto.heisyakai,
                kamoku_goto.heiheikei,
                kamoku_goto.heigouheikei,
                gakkyuu.Count);
            #endregion // 表示部分終わり
        }
    }
    #endregion
}