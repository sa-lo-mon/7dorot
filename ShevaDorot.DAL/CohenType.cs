using System;
using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class CohenType : SpinnerData
    {
        public CohenType(string id, string name) : base(id, name) { }

        public override Dictionary<string, SpinnerData> GetTypes()
        {
            return new Dictionary<string, SpinnerData>() {
                {"1" ,new CohenType("1", "כן") },
                {"2", new CohenType("2", "לא") }
            };
        }
    }
}
