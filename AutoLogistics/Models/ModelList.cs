using System.Collections;
using System.Collections.Generic;

namespace AutoLogistics.Models
{
    public class ModelList : List<Model>
    {
        public ModelList Search(string searchTerm)
        {
            var matches = new ModelList();
            foreach (var model in this)
            {
                if (model.ToString().Contains(searchTerm)) matches.Add(model);
            }
            return matches;
        }
    }
}