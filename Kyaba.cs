using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kyaba
{
    /// <summary>
    /// キャスト1人分の給料
    /// </summary>
    public class Cast
    {
        /// <summary>
        /// 順位
        /// </summary>
        public int rank;

        /// <summary>
        /// 名前
        /// </summary>
        public string name;

        /// <summary>
        /// ポイント
        /// </summary>
        public int point;

        /// <summary>
        /// 時給
        /// </summary>
        public int hourly_pay;

        /// <summary>
        /// 働いた総時間
        /// </summary>
        public int working_hours;

        /// <summary>
        /// 月給
        /// </summary>
        public int salary;

        public Cast()
        {
            rank = 1;
            name = "";
            point = 0;
            hourly_pay = 2000;
            working_hours = 0;
            salary = hourly_pay * working_hours;
        }

        public Cast(string name, int point, int working_hours)
        {
            rank = 1;
            this.name = name;
            this.point = point;
            hourly_pay = 2000;
            this.working_hours = working_hours;
            salary = hourly_pay * this.working_hours;
        }

        public void PointToHourly_pay()
        {
            // ±10分の9以下はゼロになる
            hourly_pay = ((point - 1) / 10) * 200 + 2000;
        }
    }

    public class Junituke
    {
        public static void Juni(List<Cast> sorted)
        {
            // 順位をつけるため生徒別に合計点を計算。合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[i].point > sorted[j].point) sorted[j].rank++;
                    if (sorted[i].point < sorted[j].point) sorted[i].rank++;
                }
            }
        }
    }

    public class Entrypoint
    {
        static void Main()
        {
            List<Cast> all_cast = new List<Cast>();
            all_cast.Add(new Cast("ゆい　", 10, 27));
            all_cast.Add(new Cast("ゆみこ", 29, 127));
            all_cast.Add(new Cast("あい　", 11, 229));
            all_cast.Add(new Cast("かおり", 20, 70));
            all_cast.Add(new Cast("れいこ", 118, 232));

            foreach (Cast item in all_cast) item.PointToHourly_pay();

            // ポイント順で並び替え
            List<Cast> sorted = all_cast.OrderByDescending(u => u.point).ToList();
            Junituke.Juni(sorted);

            Console.WriteLine("ポイント順で表示");
            Console.WriteLine("{0,-4}{1,-8}{2,5}{3,7}{4,5}{5,10}",
                "No.",
                "名前",
                "ポイント",
                "時給",
                "時間",
                "給料");

            foreach (Cast item in sorted)
            {
                Console.WriteLine("{0,-4}{1,-10}{2,5}p{3,7}円{4,5}分{5,10}円",
                    item.rank,
                    item.name,
                    item.point,
                    item.hourly_pay,
                    item.working_hours,
                    item.salary);
            }
        }
    }
}
