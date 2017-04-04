using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HobbyType : SpinnerData
    {
        public HobbyType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new HobbyType("1", "ערב בבית")},
            {"2", new HobbyType("2", "קריאה/כתיבה")},
            {"3", new HobbyType("3", "בישול")},
            {"4", new HobbyType("4", "אמנות/ציור")},
            {"5", new HobbyType("5", "תיאטרון")},
            {"6", new HobbyType("6", "ומופעים")},
            {"7", new HobbyType("7", "מוזיקה - האזנה")},
            {"8", new HobbyType("8", "הרצאות תורניות")},
            {"9", new HobbyType("9", "קניות")},
            {"10",new HobbyType("10", "צמיחה אישית/רוחניות")},
            {"11",new HobbyType("11", "קורסים להעשרה")},
            {"12",new HobbyType("12", "קונצרטים ואופרה")},
            {"13",new HobbyType("13", "שהיה עם חברים")},
            {"14",new HobbyType("14", "טיולים")},
            {"15",new HobbyType("15", "מסיבות/ריקודים")},
            {"16",new HobbyType("16", "אינטרנט")},
            {"17",new HobbyType("17", "סרטים")},
            {"18",new HobbyType("18", "מוזיקה - שירה")},
            {"19",new HobbyType("19", "ספורט/כושר")},
            {"20",new HobbyType("20", "לימודים/העשרת ידע")},
            {"21",new HobbyType("21", "טלוויזיה")},
            {"22",new HobbyType("22", "פוליטיקה ואקטואליה")},
            };
        }
    }
}
