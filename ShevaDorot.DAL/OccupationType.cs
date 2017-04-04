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
            {"1", new OccupationType("1", "אדריכלות")},
            {"2", new OccupationType("2", "אדריכלות")},
            {"3", new OccupationType("3", "בחר/י")},
            {"4", new OccupationType("4", "אדריכלות")},
            {"5", new OccupationType("5", "אינטרנט/הייטק")},
            {"6", new OccupationType("6", "אמנות/מוזיקה/יצירה")},
            {"7", new OccupationType("7", "ביולוגיה/ביוטכנולוגיה")},
            {"8", new OccupationType("8", "בין עבודות")},
            {"9", new OccupationType("9", "בעל חברה")},
            {"10",new OccupationType("10", "גרפקה/עיצוב")},
            {"11",new OccupationType("11", "הוראה/חינוך/הדרכה")},
            {"12",new OccupationType("12", "הנדסאי")},
            {"13",new OccupationType("13", "חייל")},
            {"14",new OccupationType("14", "חקלאות")},
            {"15",new OccupationType("15", "טייס")},
            {"16",new OccupationType("16", "טכנאי")},
            {"17",new OccupationType("17", "טכנולוגיה/הייטק")},
            {"18",new OccupationType("18", "ייעוץ/קאוצ'ינג")},
            {"19",new OccupationType("19", "כלכלה/יעוץ השקעות")},
            {"20",new OccupationType("20", "לומד/מלמד תורה")},
            {"21",new OccupationType("21", "מהנדס")},
            {"22",new OccupationType("22", "מכירות")},
            {"23",new OccupationType("23", "מסעדנות ובתי קפה")},
            {"24",new OccupationType("24", "משאבי אנוש")},
            {"25",new OccupationType("25", "ניהול/הדרכה")},
            {"26",new OccupationType("26", "ניהול בכיר")},
            {"27",new OccupationType("27", "סטודנט")},
            {"28",new OccupationType("28", "עבודה סוציאלית")},
            {"29",new OccupationType("29", "עורך/סופר/מתרגם")},
            {"30",new OccupationType("30", "עריכת דין")},
            {"31",new OccupationType("31", "פוליטיקה/ארגונים שונים")},
            {"32",new OccupationType("32", "פסיכולוגיה")},
            {"33",new OccupationType("33", "פקידות")},
            {"34",new OccupationType("34", "קבע/קצונה/ביטחון")},
            {"35",new OccupationType("35", "קוסמטיקה")},
            {"36",new OccupationType("36", "ראיית חשבון/פיננסים")},
            {"37",new OccupationType("37", "ריפוי בעיסוק")},
            {"38",new OccupationType("38", "רפואה")},
            {"39",new OccupationType("39", "תחום הטיפול הרפואי")},
            {"40",new OccupationType("40", "קלינאי תקשורת")},
            {"41",new OccupationType("41", "תקשורת/קולנוע")},
            {"42",new OccupationType("42", "אחר")},
            };
        }
    }
}