using FileWorxObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsQueryService
    {
        public string controllerName { get; private set; } = "NewsQuery";

        public List<string> Run(NewsQuery obj)
        {
            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/Run";
            var result = objService.Run(obj);
            return result;
        }
    }
}
