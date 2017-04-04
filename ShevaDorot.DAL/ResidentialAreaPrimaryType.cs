using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ResidentialAreaPrimaryType : SpinnerData
    {
        public ResidentialAreaPrimaryType()
        {
        }

        public ResidentialAreaPrimaryType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ResidentialAreaPrimaryType("1", "������� �������")},
            {"2", new ResidentialAreaPrimaryType("2", "���� ���� ��")},
            {"3", new ResidentialAreaPrimaryType("3", "����")},
            {"4", new ResidentialAreaPrimaryType("4", "����")},
            {"5", new ResidentialAreaPrimaryType("5", "������")},
            {"6", new ResidentialAreaPrimaryType("6", "�����")},
            {"7", new ResidentialAreaPrimaryType("7", "����� �������")},
            {"8", new ResidentialAreaPrimaryType("8", "���\"�")},
            {"9", new ResidentialAreaPrimaryType("9", "����")},
            {"10",new ResidentialAreaPrimaryType("10", "��\"�/���")},
        };
        }
    }
}