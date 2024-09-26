using FileWorxObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BusinessQueryService
    {
        public string controllerName { get; set; } = "BusinessQuery";

        public List<string> Run(BusinessQuery obj)
        {
            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/Run";
            var result = objService.Run(obj);
            return result;
        }
    }
}
