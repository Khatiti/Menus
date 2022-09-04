using System.Collections.Generic;

namespace TechBrain.Models
{
    public class Categories
    {
        public string name { get; set; }
        public bool IsCleard { get; set; } = false;

        private List<Categories> choices = new List<Categories>();
        public List<Categories> Choices
        {
            get { return choices; }
            set { choices = value; }
        }

        private List<Categories> related = new List<Categories>();
        public List<Categories> Related
        {
            get { return related; }
            set { related = value; }
        }
    }
    
}
