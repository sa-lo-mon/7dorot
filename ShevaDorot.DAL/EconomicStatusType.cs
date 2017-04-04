using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class EconomicStatusType : SpinnerData
    {
        public EconomicStatusType()
        {
        }

        public EconomicStatusType(string id, string name) : base(id, name) { }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new EconomicStatusType("1", "����")},
            {"2",new EconomicStatusType("2", "����")},
            {"3",new EconomicStatusType("3", "�����")},
            {"4",new EconomicStatusType("4", "�����")},
            {"5",new EconomicStatusType("5", "���� ������")},
            {"6",new EconomicStatusType("6", "�� ������")},
            };
        }
    }
}

