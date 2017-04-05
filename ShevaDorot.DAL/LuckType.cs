using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class LuckType : SpinnerData
    {
        public LuckType()
        {
        }

        public LuckType(string id, string name)
            : base(id, name)
        {
        }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"0", new LuckType("0", "בחר...")},
            {"1", new LuckType("1", "אריה")},
            {"2", new LuckType("2", "בתולה")},
            {"3", new LuckType("3", "גדי")},
            {"4", new LuckType("4", "דגים")},
            {"5", new LuckType("5", "דלי")},
            {"6", new LuckType("6", "טלה")},
            {"7", new LuckType("7", "מאזניים")},
            {"8", new LuckType("8", "סרטן")},
            {"9", new LuckType("9", "עקרב")},
            {"10",new LuckType("10", "קשת")},
            {"11",new LuckType("11", "שור")},
            {"12",new LuckType("12", "תאומים")},
            };
        }
    }
}
