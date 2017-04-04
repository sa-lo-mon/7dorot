using System;
using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class CharacteristicsType : SpinnerData
    {
        public CharacteristicsType()
        {
        }

        public CharacteristicsType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new CharacteristicsType("1", "חוכמה")},
            {"2", new CharacteristicsType("2", "שמחת חיים")},
            {"3", new CharacteristicsType("3", "זריזות")},
            {"4", new CharacteristicsType("4", "פרפקציוניזם")},
            {"5", new CharacteristicsType("5", "לבביות")},
            {"6", new CharacteristicsType("6", "תמימות")},
            {"7", new CharacteristicsType("7", "חסד")},
            {"8", new CharacteristicsType("8", "כריזמטיות")},
            {"9", new CharacteristicsType("9", "אמינות")},
            {"10",new CharacteristicsType("10", "חייכנות")},
            {"11",new CharacteristicsType("11", "חריצות")},
            {"12",new CharacteristicsType("12", "משמעת עצמית")},
            {"13",new CharacteristicsType("13", "עקשנות")},
            {"14",new CharacteristicsType("14", "שנינות")},
            {"15",new CharacteristicsType("15", "כנות")},
            {"16",new CharacteristicsType("16", "אופטימיות")},
            {"17",new CharacteristicsType("17", "חפרנות")},
            {"18",new CharacteristicsType("18", "אומץ")},
            {"19",new CharacteristicsType("19", "ותרנות")},
            {"20",new CharacteristicsType("20", "נדיבות")},
            {"21",new CharacteristicsType("21", "בררנות")},
            {"22",new CharacteristicsType("22", "חמימות")},
            {"23",new CharacteristicsType("23", "טוב לב")},
            {"24",new CharacteristicsType("24", "נחישות")},
            };

        }

    }
}