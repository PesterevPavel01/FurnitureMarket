using InterfaceApplication.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApplication.Services.Api
{
    public class BascketService: CommonService<BascketDto, int>
    {
        public BascketService(string nameController) : base(nameController) { }
        public async Task<int> DeleteEmployeeEntitys(short id)
        {

            string response = await _httpConnector.DoActionWithDataByUrl("User", JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<int>(response);

            return new();
        }

    }
}
