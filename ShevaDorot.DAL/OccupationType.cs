using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class OccupationType : SpinnerData
    {
        public OccupationType()
        {
        }

        public OccupationType(string id, string name)
            : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"0", new OccupationType("0", "���/�")},
            {"1", new OccupationType("1", "��������")},
            {"2", new OccupationType("2", "�������/�����")},
            {"3", new OccupationType("3", "�����/������/�����")},
            {"4", new OccupationType("4", "��������/������������")},
            {"5", new OccupationType("5", "��� ������")},
            {"6", new OccupationType("6", "��� ����")},
            {"7", new OccupationType("7",  "�����/�����")},
            {"8", new OccupationType("8",  "�����/�����/�����")},
            {"9", new OccupationType("9",  "������")},
            {"10",new OccupationType("10", "����")},
            {"11",new OccupationType("11", "������")},
            {"12",new OccupationType("12", "����")},
            {"13",new OccupationType("13", "�����")},
            {"14",new OccupationType("14", "���������/�����")},
            {"15",new OccupationType("15", "�����/����'���")},
            {"16",new OccupationType("16", "�����/���� ������")},
            {"17",new OccupationType("17", "����/���� ����")},
            {"18",new OccupationType("18", "�����")},
            {"19",new OccupationType("19", "������")},
            {"20",new OccupationType("20", "������� ���� ���")},
            {"21",new OccupationType("21", "����� ����")},
            {"22",new OccupationType("22", "�����/�����")},
            {"23",new OccupationType("23", "����� ����")},
            {"24",new OccupationType("24", "������")},
            {"25",new OccupationType("25", "����� ��������")},
            {"26",new OccupationType("26", "����/����/�����")},
            {"27",new OccupationType("27", "����� ���")},
            {"28",new OccupationType("28", "��������/������� �����")},
            {"29",new OccupationType("29", "����������")},
            {"30",new OccupationType("30", "������")},
            {"31",new OccupationType("31", "���/�����/������")},
            {"32",new OccupationType("32", "��������")},
            {"33",new OccupationType("33", "����� �����/�������")},
            {"34",new OccupationType("34", "����� ������")},
            {"35",new OccupationType("35", "�����")},
            {"36",new OccupationType("36", "���� ������ ������")},
            {"37",new OccupationType("37", "������ ������")},
            {"38",new OccupationType("38", "������/������")},
            {"39",new OccupationType("39", "���")},
            };
        }
    }
}