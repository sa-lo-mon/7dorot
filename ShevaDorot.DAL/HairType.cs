using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HairType : SpinnerData
    {

        public HairType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1", new HairType("1", "����")},
            {"2", new HairType("2", "���")},
            {"3", new HairType("3", "��������")},
            {"4", new HairType("4", "������")},
            {"5", new HairType("5", "����")},
            {"6", new HairType("6", "�\'���\'�")},
            {"7", new HairType("7", "����")},
            {"8", new HairType("8", "���")},
            {"9", new HairType("9", "������")},
            {"10",new HairType("10", "���")},
            {"11",new HairType("11", "���")},
            {"12",new HairType("12", "����")},
            {"13",new HairType("13", "������")},
            {"14",new HairType("14", "����")},
            };
        }
    }
}