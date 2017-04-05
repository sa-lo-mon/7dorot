using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class OccupationType : SpinnerData
    {
        public OccupationType()
        {
        }

        public OccupationType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"0", new OccupationType("0", "בחר/י")},
            {"1", new OccupationType("1", "אדריכלות")},
            {"2", new OccupationType("2", "אינטרנט/הייטק")},
            {"3", new OccupationType("3", "אמנות/מוזיקה/יצירה")},
            {"4", new OccupationType("4", "ביולוגיה/ביוטכנולוגיה")},
            {"5", new OccupationType("5", "בין עבודות")},
            {"6", new OccupationType("6", "בעל חברה")},
            {"7", new OccupationType("7",  "גרפקה/עיצוב")},
            {"8", new OccupationType("8",  "הוראה/חינוך/הדרכה")},
            {"9", new OccupationType("9",  "הנדסאי")},
            {"10",new OccupationType("10", "חייל")},
            {"11",new OccupationType("11", "חקלאות")},
            {"12",new OccupationType("12", "טייס")},
            {"13",new OccupationType("13", "טכנאי")},
            {"14",new OccupationType("14", "טכנולוגיה/הייטק")},
            {"15",new OccupationType("15", "ייעוץ/קאוצ'ינג")},
            {"16",new OccupationType("16", "כלכלה/יעוץ השקעות")},
            {"17",new OccupationType("17", "לומד/מלמד תורה")},
            {"18",new OccupationType("18", "מהנדס")},
            {"19",new OccupationType("19", "מכירות")},
            {"20",new OccupationType("20", "מסעדנות ובתי קפה")},
            {"21",new OccupationType("21", "משאבי אנוש")},
            {"22",new OccupationType("22", "ניהול/הדרכה")},
            {"23",new OccupationType("23", "ניהול בכיר")},
            {"24",new OccupationType("24", "סטודנט")},
            {"25",new OccupationType("25", "עבודה סוציאלית")},
            {"26",new OccupationType("26", "עורך/סופר/מתרגם")},
            {"27",new OccupationType("27", "עריכת דין")},
            {"28",new OccupationType("28", "פוליטיקה/ארגונים שונים")},
            {"29",new OccupationType("29", "פסיכולוגיה")},
            {"30",new OccupationType("30", "פקידות")},
            {"31",new OccupationType("31", "קבע/קצונה/ביטחון")},
            {"32",new OccupationType("32", "קוסמטיקה")},
            {"33",new OccupationType("33", "ראיית חשבון/פיננסים")},
            {"34",new OccupationType("34", "ריפוי בעיסוק")},
            {"35",new OccupationType("35", "רפואה")},
            {"36",new OccupationType("36", "תחום הטיפול הרפואי")},
            {"37",new OccupationType("37", "קלינאי תקשורת")},
            {"38",new OccupationType("38", "תקשורת/קולנוע")},
            {"39",new OccupationType("39", "אחר")},
            };
        }
    }
}