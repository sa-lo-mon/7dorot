using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ResidentialAreaSecondaryType : SpinnerData
    {
        public ResidentialAreaSecondaryType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ResidentialAreaSecondaryType("1", "ירושלים והסביבה")},
            {"2", new ResidentialAreaSecondaryType("2", "מרכז וגוש דן")},
            {"3", new ResidentialAreaSecondaryType("3", "צפון")},
            {"4", new ResidentialAreaSecondaryType("4", "דרום")},
            {"5", new ResidentialAreaSecondaryType("5", "לונדון")},
            {"6", new ResidentialAreaSecondaryType("6", "השרון")},
            {"7", new ResidentialAreaSecondaryType("7", "יהודה ושומרון")},
            {"8", new ResidentialAreaSecondaryType("8", "ארה\"ב")},
            {"9", new ResidentialAreaSecondaryType("9", "צרפת")},
            {"10",new ResidentialAreaSecondaryType("10", "חו\"ל/אחר")},
        };
        }
    }
}