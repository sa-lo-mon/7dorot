using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class KosherType : SpinnerData
    {
        public KosherType(string id, string name) : base(id, name) { }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new KosherType("1", "השגחה מיוחדת")},
            {"2",new KosherType("2", "מהדרין")},
            {"3",new KosherType("3", "רבנות")},
            {"4",new KosherType("4", "רבנות ומהדרין")},
            };
        }
    }
}