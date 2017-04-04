using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class AppearanceType : SpinnerData
    {
        public AppearanceType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new AppearanceType("1", "מצוין")},
            {"2",new AppearanceType("2", "טוב מאוד")},
            {"3",new AppearanceType("3", "יש תמונה..")},
            {"4",new AppearanceType("4", "טוב")},
            {"5",new AppearanceType("5", "בינוני")},
            {"6",new AppearanceType("6", "מתחת לממוצע")},
            {"7", new AppearanceType("7", "לא רלבנטי")}
        };
        }
    }
}