using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class AppearanceType : SpinnerData
    {
        public AppearanceType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new AppearanceType("1", "�����")},
            {"2",new AppearanceType("2", "��� ����")},
            {"3",new AppearanceType("3", "�� �����..")},
            {"4",new AppearanceType("4", "���")},
            {"5",new AppearanceType("5", "������")},
            {"6",new AppearanceType("6", "���� ������")},
            {"7", new AppearanceType("7", "�� ������")}
        };
        }
    }
}