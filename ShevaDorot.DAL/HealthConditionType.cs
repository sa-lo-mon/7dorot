using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HealthConditionType : SpinnerData
    {
        public HealthConditionType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new HealthConditionType("1", "תקין")},
            {"2",new HealthConditionType("2", "אספר לך בהמשך")},
            };
        }
    }
}