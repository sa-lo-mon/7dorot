using System;
using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class CharacteristicsType : SpinnerData
    {
        public CharacteristicsType()
        {
        }

        public CharacteristicsType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
            {"1", new CharacteristicsType("1", "�����")},
            {"2", new CharacteristicsType("2", "���� ����")},
            {"3", new CharacteristicsType("3", "������")},
            {"4", new CharacteristicsType("4", "�����������")},
            {"5", new CharacteristicsType("5", "������")},
            {"6", new CharacteristicsType("6", "������")},
            {"7", new CharacteristicsType("7", "���")},
            {"8", new CharacteristicsType("8", "���������")},
            {"9", new CharacteristicsType("9", "������")},
            {"10",new CharacteristicsType("10", "�������")},
            {"11",new CharacteristicsType("11", "������")},
            {"12",new CharacteristicsType("12", "����� �����")},
            {"13",new CharacteristicsType("13", "������")},
            {"14",new CharacteristicsType("14", "������")},
            {"15",new CharacteristicsType("15", "����")},
            {"16",new CharacteristicsType("16", "���������")},
            {"17",new CharacteristicsType("17", "������")},
            {"18",new CharacteristicsType("18", "����")},
            {"19",new CharacteristicsType("19", "������")},
            {"20",new CharacteristicsType("20", "������")},
            {"21",new CharacteristicsType("21", "������")},
            {"22",new CharacteristicsType("22", "������")},
            {"23",new CharacteristicsType("23", "��� ��")},
            {"24",new CharacteristicsType("24", "������")},
            };

        }

    }
}