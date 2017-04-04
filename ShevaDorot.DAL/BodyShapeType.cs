


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
            {"1",new BodyShapeType("1", "�����")},
            {"2",new BodyShapeType("2", "����")},
            {"3",new BodyShapeType("3", "���")},
            {"4",new BodyShapeType("4", "���")},
            {"5",new BodyShapeType("5", "���")},
            {"6",new BodyShapeType("6", "�����")},
            {"7",new BodyShapeType("7", "�����")},
            {"8",new BodyShapeType("8", "�����")},
            {"9",new BodyShapeType("9", "�����")},
            {"10",new BodyShapeType("10", "���")},
        };
        }
    }
}