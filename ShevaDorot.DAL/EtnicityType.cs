using System.Collections.Generic;

namespace ShevaDorot.DAL
{

    public class EtnicityType : SpinnerData
    {
        public EtnicityType()
        {
        }

        public EtnicityType(string id, string name) :
            base(id, name)
        { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new EtnicityType("1", "אשכנזי/ה")},
            {"2",new EtnicityType("2", "ספרדי/ה")},
            {"3",new EtnicityType("3", "מעורב/ת")},
            {"4",new EtnicityType("4", "תימני/ה")},
            {"5",new EtnicityType("5", "רוסי/ה")},
            {"6",new EtnicityType("6", "אתיופי/ת")},
            {"7",new EtnicityType("7", "אמריקאי/ת")},
            {"8",new EtnicityType("8", "לא רלוונטי")},
            };
        }
    }
}