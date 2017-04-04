using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class EconomicStatusType : SpinnerData
    {
        public EconomicStatusType()
        {
        }

        public EconomicStatusType(string id, string name) : base(id, name) { }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new EconomicStatusType("1", "עשיר")},
            {"2",new EconomicStatusType("2", "אמיד")},
            {"3",new EconomicStatusType("3", "מבוסס")},
            {"4",new EconomicStatusType("4", "ממוצע")},
            {"5",new EconomicStatusType("5", "מתחת לממוצע")},
            {"6",new EconomicStatusType("6", "לא רלבנטי")},
            };
        }
    }
}

