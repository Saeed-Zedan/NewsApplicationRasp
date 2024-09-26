using FileWorxObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PhotoQueryService
    {
        public string controllerName { get; private set; } = "PhotoQuery";

        public List<string> Run(PhotoQuery obj)
        {
            var objService = new BaseService();
            objService.ApiUrl += $"/{controllerName}/Run";
            var result = objService.Run(obj);
            return result;
        }
    }
}
