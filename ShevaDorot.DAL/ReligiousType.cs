using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ReligiousType : SpinnerData
    {
        public ReligiousType() { }

        public ReligiousType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ReligiousType("1", "מסורתי/ת")},
            {"2", new ReligiousType("2", "דתי/ה לייט")},
            {"3", new ReligiousType("3", "דתי/ה")},
            {"4", new ReligiousType("4", "דתי/ה לאומי/ת")},
            {"5", new ReligiousType("5", "דתי/ה לאומי/ת תורני/ת")},
            {"6", new ReligiousType("6", "חרדי/ה")},
            {"7", new ReligiousType("7", "חרדי/ה לאומי/ת")},
            {"8", new ReligiousType("8", "חרדי/ה מודרני/ת")},
            {"9", new ReligiousType("9", "ברסלב")},
            {"10",new ReligiousType("10", "חב\"ד")},
            {"11",new ReligiousType("11", "חוזר/ת בתשובה")},
            {"12",new ReligiousType("12", "דתל\"ש/ית")}
            };

        }
    }
}