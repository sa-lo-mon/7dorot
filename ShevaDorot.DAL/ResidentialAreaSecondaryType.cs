using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class ResidentialAreaSecondaryType : SpinnerData
    {
        public ResidentialAreaSecondaryType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new ResidentialAreaSecondaryType("1", "������� �������")},
            {"2", new ResidentialAreaSecondaryType("2", "���� ���� ��")},
            {"3", new ResidentialAreaSecondaryType("3", "����")},
            {"4", new ResidentialAreaSecondaryType("4", "����")},
            {"5", new ResidentialAreaSecondaryType("5", "������")},
            {"6", new ResidentialAreaSecondaryType("6", "�����")},
            {"7", new ResidentialAreaSecondaryType("7", "����� �������")},
            {"8", new ResidentialAreaSecondaryType("8", "���\"�")},
            {"9", new ResidentialAreaSecondaryType("9", "����")},
            {"10",new ResidentialAreaSecondaryType("10", "��\"�/���")},
        };
        }
    }
}