using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Parsers
{
    public class TempoVisorPrefectureHelper
    {
        private static readonly string[] ACCEPTED_PREFECTURES =
        {
            "北海道",
            "青森県",
            "秋田県",
            "岩手県",
            "山形県",
            "宮城県",
            "福島県",
            "新潟県",
            "茨城県",
            "栃木県",
            "群馬県",
            "千葉県",
            "埼玉県",
            "東京都",
            "山梨県",
            "静岡県",
            "富山県",
            "石川県",
            "長野県",
            "愛知県",
            "岐阜県",
            "三重県",
            "奈良県",
            "滋賀県",
            "福井県",
            "大阪府",
            "京都府",
            "兵庫県",
            "島根県",
            "鳥取県",
            "岡山県",
            "広島県",
            "山口県",
            "徳島県",
            "香川県",
            "高知県",
            "愛媛県",
            "福岡県",
            "佐賀県",
            "長崎県",
            "熊本県",
            "大分県",
            "宮崎県",
            "沖縄県",
        };

        private static readonly Dictionary<string, string> CONVERTABLE_PREFECTURES =
            new Dictionary<string,string>
        {
            { "神奈川",　"神奈川県" },
            { "和歌山",　"和歌山県" },
            { "鹿児島",　"鹿児島県" }
        };

        public static string GetPrefecture(string pref)
        {
            pref = string.Join(string.Empty, pref.Take(3));

            if (ACCEPTED_PREFECTURES.Contains(pref)) return pref;

            if (CONVERTABLE_PREFECTURES.ContainsKey(pref))
                return CONVERTABLE_PREFECTURES[pref];

            return null;
        }
    }
}
