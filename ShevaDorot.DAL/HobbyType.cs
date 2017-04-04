using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HobbyType : SpinnerData
    {
        public HobbyType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new HobbyType("1", "��� ����")},
            {"2", new HobbyType("2", "�����/�����")},
            {"3", new HobbyType("3", "�����")},
            {"4", new HobbyType("4", "�����/����")},
            {"5", new HobbyType("5", "�������")},
            {"6", new HobbyType("6", "�������")},
            {"7", new HobbyType("7", "������ - �����")},
            {"8", new HobbyType("8", "������ �������")},
            {"9", new HobbyType("9", "�����")},
            {"10",new HobbyType("10", "����� �����/�������")},
            {"11",new HobbyType("11", "������ ������")},
            {"12",new HobbyType("12", "�������� ������")},
            {"13",new HobbyType("13", "���� �� �����")},
            {"14",new HobbyType("14", "������")},
            {"15",new HobbyType("15", "������/�������")},
            {"16",new HobbyType("16", "�������")},
            {"17",new HobbyType("17", "�����")},
            {"18",new HobbyType("18", "������ - ����")},
            {"19",new HobbyType("19", "�����/����")},
            {"20",new HobbyType("20", "�������/����� ���")},
            {"21",new HobbyType("21", "��������")},
            {"22",new HobbyType("22", "�������� ���������")},
            };
        }
    }
}
