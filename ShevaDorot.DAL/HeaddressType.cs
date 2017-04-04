using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HeaddressType : SpinnerData
    {

        public HeaddressType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new HeaddressType("1", "���� �����")},
            {"2",new HeaddressType("2", "���� �����")},
            {"3",new HeaddressType("3", "���� ����� �����")},
            {"4",new HeaddressType("4", "���� ���")},
            {"5",new HeaddressType("5", "���� ����")},
            {"6",new HeaddressType("6", "����")},
            {"7",new HeaddressType("7", "��� ����� ���")},

            };
        }
    }
}
