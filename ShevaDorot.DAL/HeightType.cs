
using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public class HeightType : SpinnerData
    {
        public HeightType()
        {
        }

        public HeightType(string id, string name) :
            base(id, name)
        { }



        public override Dictionary<string, SpinnerData> GetTypes()
        {
            Dictionary<string, SpinnerData> heightTypes = new Dictionary<string, SpinnerData>();
            for (int i = 130; i <= 210; i++)
            {
                heightTypes.Add((i - 129).ToString(), new HeightType(i.ToString(), i + " ñ\"î"));
            }

            return heightTypes;
        }
    }
}
