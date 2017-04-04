using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ResidentialAreaPrimaryType : SpinnerData
    {
        public ResidentialAreaPrimaryType()
        {
        }

        public ResidentialAreaPrimaryType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ResidentialAreaPrimaryType("1", "ירושלים והסביבה")},
            {"2", new ResidentialAreaPrimaryType("2", "מרכז וגוש דן")},
            {"3", new ResidentialAreaPrimaryType("3", "צפון")},
            {"4", new ResidentialAreaPrimaryType("4", "דרום")},
            {"5", new ResidentialAreaPrimaryType("5", "לונדון")},
            {"6", new ResidentialAreaPrimaryType("6", "השרון")},
            {"7", new ResidentialAreaPrimaryType("7", "יהודה ושומרון")},
            {"8", new ResidentialAreaPrimaryType("8", "ארה\"ב")},
            {"9", new ResidentialAreaPrimaryType("9", "צרפת")},
            {"10",new ResidentialAreaPrimaryType("10", "חו\"ל/אחר")},
        };
        }
    }
}