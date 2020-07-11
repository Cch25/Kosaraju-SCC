using System.Collections.Generic;

namespace Kosaraju_SCC.Models
{
    public class StronglyConnectedModel
    {
        public int Key { get; set; }
        public List<string> Value { get; set; }
        public StronglyConnectedModel()
        {
            Value = new List<string>();
        }
    }
}
