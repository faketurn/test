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

        /// <summary>
        /// 本指名回数
        /// </summary>
        public int entry_call;

        /// <summary>
        /// 場内指名回数
        /// </summary>
        public int hall_call;

        /// <summary>
        /// 21時までの同伴入店人数
        /// </summary>
        public int with21;

        /// <summary>
        /// 22時までの同伴入店人数
        /// </summary>
        public int with22;

        public Cast()
        {
            rank = 1;
            name = "";
            point = 0;
            hourly_pay = 2000;
            working_hours = 0;
            salary = hourly_pay * working_hours;
            entry_call = 0;
            hall_call = 0;
            with21 = 0;
            with22 = 0;
        }

        public Cast(string name, int point, int working_hours, int entry_call, int hall_call, int with21, int with22)
        {
            rank = 1;
            this.name = name;
            this.point = point + entry_call + (int)(hall_call * 0.5) + (with21 * 2) + with22;
            hourly_pay = 2000;
            this.working_hours = working_hours;
            salary = hourly_pay * this.working_hours;
            this.entry_call = entry_call;
            this.hall_call = hall_call;
            this.with21 = with21;
            this.with22 = with22;
        }

        public void PointToHourly_pay()
        {
            // ±10分の9以下はゼロになる
            hourly_pay = ((point - 1) / 10) * 200 + 2000;
        }
    }

    public class Junituke
    {
        public static void Juni_point(List<Cast> sorted)
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

        public static void Juni_salary(List<Cast> sorted)
        {
            // 順位をつけるため生徒別に合計点を計算。合計点を総当りで比較し、低い点の方の順位を1ずつ下げる
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[i].salary > sorted[j].salary) sorted[j].rank++;
                    if (sorted[i].salary < sorted[j].salary) sorted[i].rank++;
                }
            }
        }
    }

    public class Entrypoint
    {
        static void Main()
        {
            List<Cast> all_cast = new List<Cast>();
            all_cast.Add(new Cast("ゆい　", 10, 427, 3, 7, 1, 0));
            all_cast.Add(new Cast("ゆみこ", 29, 326, 5, 9, 2, 1));
            all_cast.Add(new Cast("あい　", 11, 229, 11, 6, 7, 0));
            all_cast.Add(new Cast("かおり", 20, 370, 18, 19, 1, 3));
            all_cast.Add(new Cast("れいこ", 33, 23, 1, 23, 1, 0));

            foreach (Cast item in all_cast) item.PointToHourly_pay();

            // ポイント順で並び替え
            List<Cast> sorted_point = all_cast.OrderByDescending(u => u.point).ToList();
            Junituke.Juni_point(sorted_point);

            Console.WriteLine("ポイント順で表示");
            Console.WriteLine("{0,-4}{1,-7}{2,5}{3,7}{4,5}{5,9} |{6,5}{7,5}{8,6}{9,6}",
                "No.",
                "名前",
                "ポイント",
                "時給",
                "時間",
                "給料",
                "本指",
                "場内",
                "同21",
                "同22");

            foreach (Cast item in sorted_point)
            {
                Console.WriteLine("{0,-4}{1,-9}{2,5}p{3,7}円{4,5}分{5,9}円 |{6,5}回{7,5}回{8,5}名{9,5}名",
                    item.rank,
                    item.name,
                    item.point,
                    item.hourly_pay,
                    item.working_hours,
                    item.salary,
                    item.entry_call,
                    item.hall_call,
                    item.with21,
                    item.with22);
            }

            // 給料順で並び替え
            List<Cast> sorted_salary = all_cast.OrderByDescending(u => u.salary).ToList();
            for (int i = 0; i < sorted_salary.Count; i++)
            {
                sorted_salary[i].rank = 1;
            }
            Junituke.Juni_salary(sorted_salary);

            Console.WriteLine("\n給料順で表示");
            Console.WriteLine("{0,-4}{1,-7}{2,5}{3,7}{4,5}{5,9} |{6,5}{7,5}{8,6}{9,6}",
                "No.",
                "名前",
                "ポイント",
                "時給",
                "時間",
                "給料",
                "本指",
                "場内",
                "同21",
                "同22");

            foreach (Cast item in sorted_salary)
            {
                Console.WriteLine("{0,-4}{1,-9}{2,5}p{3,7}円{4,5}分{5,9}円 |{6,5}回{7,5}回{8,5}名{9,5}名",
                    item.rank,
                    item.name,
                    item.point,
                    item.hourly_pay,
                    item.working_hours,
                    item.salary,
                    item.entry_call,
                    item.hall_call,
                    item.with21,
                    item.with22);
            }
        }
    }
}
