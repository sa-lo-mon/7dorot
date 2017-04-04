using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class PrayerFrequencyType : SpinnerData
    {
        public PrayerFrequencyType()
        {
        }

        public PrayerFrequencyType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1",new PrayerFrequencyType("1", "���� ����� ����")},
            {"2",new PrayerFrequencyType("2", "��� ����")},
            {"3",new PrayerFrequencyType("3", "��� �����")},
            };
        }
    }
}
