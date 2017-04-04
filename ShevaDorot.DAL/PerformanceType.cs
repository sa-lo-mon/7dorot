using System;
using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class PerformanceType : SpinnerData
    {
        public PerformanceType()
        {
        }

        public PerformanceType(string id, string name) :
            base(id, name)
        {
        }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {

            {"1",new PerformanceType("1", "מצוין")},
            {"2",new PerformanceType("2", "טוב מאוד")},
            {"3",new PerformanceType("3", "יש תמונה...")},
            {"4",new PerformanceType("4", "טוב")},
            {"5",new PerformanceType("5", "בינוני")},
            {"6",new PerformanceType("6", "מתחת למוצע")},
            {"7",new PerformanceType("7", "לא רלבנטי")},

            };
        }

        public static implicit operator PerformanceType(EducationType v)
        {
            throw new NotImplementedException();
        }
    }
}