using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ToraStudingType : SpinnerData
    {
        public ToraStudingType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new ToraStudingType("1", "כל יום")},
            {"2",new ToraStudingType("2", "בערך פעם בשבוע")},
            {"3",new ToraStudingType("3", "לעיתים רחוקות")},
            {"4",new ToraStudingType("4", "לעיתים קרובות")},
            {"5",new ToraStudingType("5", "כמה שעות ביום")},
        };
        }
    }
}