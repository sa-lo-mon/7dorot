using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class LanguageType : SpinnerData
    {
        public LanguageType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new LanguageType("1", "�����")},
            {"2",new LanguageType("2", "������")},
            {"3",new LanguageType("3", "������")},
            {"4",new LanguageType("4", "�����")},
            {"5",new LanguageType("5", "������")},

            };
        }
    }
}
