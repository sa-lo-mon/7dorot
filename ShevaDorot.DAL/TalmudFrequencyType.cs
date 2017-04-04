using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class TalmudFrequencyType : SpinnerData
    {
        public TalmudFrequencyType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new TalmudFrequencyType("1", "�� ���")},
            {"2",new TalmudFrequencyType("2", "���� ��� �����")},
            {"3",new TalmudFrequencyType("3", "������ ������")},
            {"4",new TalmudFrequencyType("4", "������ ������")},
            {"5",new TalmudFrequencyType("5", "��� ���� ����")},
            };
        }
    }
}