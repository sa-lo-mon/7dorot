using System.Collections.Generic;

namespace ShevaDorot.DAL
{
    public abstract class SpinnerData
    {
        public string id { get; set; }
        public string name { get; set; }

        public SpinnerData() { }

        public SpinnerData(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public abstract Dictionary<string, SpinnerData> GetTypes();

        protected string GetValueByCode<T>(List<T> items, string code) where T : SpinnerData
        {
            foreach (SpinnerData item in items)
            {
                if (item.id.Equals(code))
                {
                    return item.name;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}