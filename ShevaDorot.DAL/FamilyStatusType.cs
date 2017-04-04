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
            {"1",new FamilyStatusType("1", "����/�")},
            {"2",new FamilyStatusType("2", "����/�")},
            {"3",new FamilyStatusType("3", "����/�")},
            {"4",new FamilyStatusType("4", "����/� �� �����")},
            {"5",new FamilyStatusType("5", "����/� �� �����")}
            };
        }
    }
}