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

            {"1",new PerformanceType("1", "�����")},
            {"2",new PerformanceType("2", "��� ����")},
            {"3",new PerformanceType("3", "�� �����...")},
            {"4",new PerformanceType("4", "���")},
            {"5",new PerformanceType("5", "������")},
            {"6",new PerformanceType("6", "���� �����")},
            {"7",new PerformanceType("7", "�� ������")},

            };
        }

        public static implicit operator PerformanceType(EducationType v)
        {
            throw new NotImplementedException();
        }
    }
}