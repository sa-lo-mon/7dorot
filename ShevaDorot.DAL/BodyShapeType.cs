


using System.Collections.Generic;
/**
* 
*/
namespace ShevaDorot.DAL
{
    public class BodyShapeType : SpinnerData
    {
        public BodyShapeType(string id, string name) : base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new BodyShapeType("1", "ממוצע")},
            {"2",new BodyShapeType("2", "חטוב")},
            {"3",new BodyShapeType("3", "רזה")},
            {"4",new BodyShapeType("4", "רחב")},
            {"5",new BodyShapeType("5", "מלא")},
            {"6",new BodyShapeType("6", "שרירי")},
            {"7",new BodyShapeType("7", "אתלטי")},
            {"8",new BodyShapeType("8", "מרשים")},
            {"9",new BodyShapeType("9", "אצילי")},
            {"10",new BodyShapeType("10", "שמן")},
        };
        }
    }
}