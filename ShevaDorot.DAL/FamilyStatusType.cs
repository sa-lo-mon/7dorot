using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class FamilyStatusType : SpinnerData
    {
        public FamilyStatusType()
        {
        }

        public FamilyStatusType(string id, string name) : base(id, name) { }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new FamilyStatusType("1", "רווק/ה")},
            {"2",new FamilyStatusType("2", "גרוש/ה")},
            {"3",new FamilyStatusType("3", "אלמן/ה")},
            {"4",new FamilyStatusType("4", "גרוש/ה עם ילדים")},
            {"5",new FamilyStatusType("5", "אלמן/ה עם ילדים")}
            };
        }
    }
}