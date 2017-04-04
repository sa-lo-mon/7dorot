using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class GenderType : SpinnerData
    {
        public GenderType()
        {
        }

        public GenderType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new GenderType("1", "���")},
            {"2", new GenderType("2", "����")},
            {"3", new HobbyType("3", "�� �����")},
            };
        }
    }
}
