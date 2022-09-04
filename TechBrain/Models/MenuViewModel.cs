using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TechBrain.Models
{
    public class MenuViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public MenuViewModel() { }
        public MenuDto menus { get; set; } = new MenuDto();
        public MenuViewModel(string name)
        {
            Name = name;
        }
        //get main menu home page
        public List<Categories> GetRootCategories()
        {
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Categories>>(json);
            }
        }
        
        public List<MMenu> MainMenu
        {
            get
            {
                List<MMenu> menu = new List<MMenu>();
                List<Categories> rootCategories = GetRootCategories();
                foreach (var item in rootCategories)
                {
                    menu.Add(new MMenu { name = item.name });
                }
                return menu;
            }
        }

        

        public MenuDto MenuChildren
        {
            get
            {
               
                List<Categories> rootCategories = GetRootCategories();
                //get filtered
                if (Name != null)
                {
                    SearchItem(rootCategories, Name);
                }
                return menus;
            }
        }

        public void SearchItem(List<Categories> rootCategories, string searchItem)
        {
            MenuDto menu = new MenuDto();
            foreach (var item in rootCategories)
            {
                if (Name == item.name)
                {
                    List<MMenu> x = new List<MMenu>();
                    for (int i = 0; i < item.Choices.Count; i++) { x.Add(new MMenu { name = item.Choices[i].name }); }

                    List<MMenu> y = new List<MMenu>();
                    for (int v = 0; v < item.Related.Count; v++) { y.Add(new MMenu { name = item.Related[v].name }); }
                    menu.mainMenus = x;
                    menu.relatedMenus = y;

                    menus = menu;
                    break;
                }
                else
                {
                    List<Categories> list = new List<Categories>();
                    if (item.Choices != null) list.AddRange(item.Choices);
                    if (item.Related != null) list.AddRange(item.Related);
                    if (list.Count>0)
                    {
                        SearchItem(list, searchItem);
                    }
                    //rootCategories = item.Choices;
                    //rootCategories.AddRange(item.Related);
                }
            }
        }
    }
}
