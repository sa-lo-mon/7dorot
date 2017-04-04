using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class EducationType : SpinnerData
    {
        public EducationType()
        {
        }

        public EducationType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new EducationType("1", "תיכונית")},
            {"2",new EducationType("2", "תעודה")},
            {"3",new EducationType("3", "תואר ראשון")},
            {"4",new EducationType("4", "תואר שני")},
            {"5",new EducationType("5", "דוקטוקרט ומעלה")},
            {"6",new EducationType("6", "תורנית")},
            {"7",new EducationType("7", "מכינה")},
            {"8",new EducationType("8", "מדרשה")},
            {"9",new EducationType("9", "ישיבת הסדר")},
            };
        }
    }
}