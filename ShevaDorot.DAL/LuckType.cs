using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class LuckType : SpinnerData
    {
        public LuckType()
        {
        }

        public LuckType(string id, string name)
            : base(id, name)
        {
        }
        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"0", new LuckType("0", "���...")},
            {"1", new LuckType("1", "����")},
            {"2", new LuckType("2", "�����")},
            {"3", new LuckType("3", "���")},
            {"4", new LuckType("4", "����")},
            {"5", new LuckType("5", "���")},
            {"6", new LuckType("6", "���")},
            {"7", new LuckType("7", "�������")},
            {"8", new LuckType("8", "����")},
            {"9", new LuckType("9", "����")},
            {"10",new LuckType("10", "���")},
            {"11",new LuckType("11", "���")},
            {"12",new LuckType("12", "������")},
            };
        }
    }
}
