using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class FamilyReligiousType : SpinnerData
    {
        public FamilyReligiousType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new FamilyReligiousType("1", "משפחה דתית")},
            {"2",new FamilyReligiousType("2", "מפחה חרדית")},
            {"3",new FamilyReligiousType("3", "משפחה מסורתית")},
            {"4",new FamilyReligiousType("4", "משפחה חילונית")},
            };
        }
    }
}