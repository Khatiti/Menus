using System.Collections.Generic;

namespace TechBrain.Models
{
    public class MenuDto
    {
        public List<MMenu> mainMenus { get; set; }
        public List<MMenu> relatedMenus { get; set; }
    }

    public class MMenu
    {
        public string name { get; set; }
    }
}
