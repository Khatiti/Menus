using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBrain.Models;

namespace TechBrain.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [Route("menuitems")]
        public MenuDto MenuItems(string name)
        {
            MenuViewModel mvm = new MenuViewModel(name);
            var data = mvm.MenuChildren;
            return data;
        }
    
       
    }
}
