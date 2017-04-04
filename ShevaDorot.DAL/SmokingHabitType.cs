using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class SmokingHabitType : SpinnerData
    {
        public SmokingHabitType()
        {
        }

        public SmokingHabitType(string id, string name) : base(id, name) { }

         public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>(){
            {"1",new SmokingHabitType("1", "לא מעשן/ת")},
            {"2",new SmokingHabitType("2", "לעיתים רחוקות")},
            {"3",new SmokingHabitType("3", "מנסה להפסיק")},
            {"4",new SmokingHabitType("4", "מעשן")},
            };
        }
    }
}