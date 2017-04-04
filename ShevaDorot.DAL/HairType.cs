using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HairType : SpinnerData
    {

        public HairType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1", new HairType("1", "שחור")},
            {"2", new HairType("2", "חום")},
            {"3", new HairType("3", "בלונדיני")},
            {"4", new HairType("4", "אדמוני")},
            {"5", new HairType("5", "שטני")},
            {"6", new HairType("6", "ג\'ינג\'י")},
            {"7", new HairType("7", "כסוף")},
            {"8", new HairType("8", "חלק")},
            {"9", new HairType("9", "מתולתל")},
            {"10",new HairType("10", "גלי")},
            {"11",new HairType("11", "קצר")},
            {"12",new HairType("12", "ארוך")},
            {"13",new HairType("13", "בינוני")},
            {"14",new HairType("14", "קרחת")},
            };
        }
    }
}