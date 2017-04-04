using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class EducationType : SpinnerData
    {
        public EducationType()
        {
        }

        public EducationType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new EducationType("1", "�������")},
            {"2",new EducationType("2", "�����")},
            {"3",new EducationType("3", "���� �����")},
            {"4",new EducationType("4", "���� ���")},
            {"5",new EducationType("5", "�������� �����")},
            {"6",new EducationType("6", "������")},
            {"7",new EducationType("7", "�����")},
            {"8",new EducationType("8", "�����")},
            {"9",new EducationType("9", "����� ����")},
            };
        }
    }
}