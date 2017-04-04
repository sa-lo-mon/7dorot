using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class MilitaryNationalServiceType : SpinnerData
    {

        public MilitaryNationalServiceType(string id, string name)
            : base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new MilitaryNationalServiceType("1", "����� �����")},
            {"2",new MilitaryNationalServiceType("2", "����� ���� ���")},
            {"3",new MilitaryNationalServiceType("3", "����")},
            {"4",new MilitaryNationalServiceType("4", "����")},
            {"5",new MilitaryNationalServiceType("5", "�����")},
            {"6",new MilitaryNationalServiceType("6", "����� ������")},
            {"7",new MilitaryNationalServiceType("7", "�� ������")}
            };
        }
    }
}
