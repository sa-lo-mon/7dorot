using System.Collections.Generic;

namespace ShevaDorot.DAL
{

    public class EtnicityType : SpinnerData
    {
        public EtnicityType()
        {
        }

        public EtnicityType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new EtnicityType("1", "������/�")},
            {"2",new EtnicityType("2", "�����/�")},
            {"3",new EtnicityType("3", "�����/�")},
            {"4",new EtnicityType("4", "�����/�")},
            {"5",new EtnicityType("5", "����/�")},
            {"6",new EtnicityType("6", "������/�")},
            {"7",new EtnicityType("7", "�������/�")},
            {"8",new EtnicityType("8", "�� �������")},
            };
        }
    }
}