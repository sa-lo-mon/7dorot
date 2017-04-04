using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HeaddressType : SpinnerData
    {

        public HeaddressType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new HeaddressType("1", "כיפה סרוגה")},
            {"2",new HeaddressType("2", "כיפה שחורה")},
            {"3",new HeaddressType("3", "כיפה סרוגה שחורה")},
            {"4",new HeaddressType("4", "כיפה עור")},
            {"5",new HeaddressType("5", "כיפה לבנה")},
            {"6",new HeaddressType("6", "כובע")},
            {"7",new HeaddressType("7", "ללא כיסוי ראש")},

            };
        }
    }
}
