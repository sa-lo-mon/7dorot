using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class EyesColorType : SpinnerData
    {

        public EyesColorType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new EyesColorType("1", "שחור")},
            {"2",new EyesColorType("2", "כחול")},
            {"3",new EyesColorType("3", "ירוק")},
            {"4",new EyesColorType("4", "חום")},
            {"5",new EyesColorType("5", "אפור")},
            {"6",new EyesColorType("6", "דבש")},
            };
        }
    }
}