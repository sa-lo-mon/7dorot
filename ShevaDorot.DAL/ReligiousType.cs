using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ReligiousType : SpinnerData
    {
        public ReligiousType() { }

        public ReligiousType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ReligiousType("1", "������/�")},
            {"2", new ReligiousType("2", "���/� ����")},
            {"3", new ReligiousType("3", "���/�")},
            {"4", new ReligiousType("4", "���/� �����/�")},
            {"5", new ReligiousType("5", "���/� �����/� �����/�")},
            {"6", new ReligiousType("6", "����/�")},
            {"7", new ReligiousType("7", "����/� �����/�")},
            {"8", new ReligiousType("8", "����/� ������/�")},
            {"9", new ReligiousType("9", "�����")},
            {"10",new ReligiousType("10", "��\"�")},
            {"11",new ReligiousType("11", "����/� ������")},
            {"12",new ReligiousType("12", "���\"�/��")}
            };

        }
    }
}