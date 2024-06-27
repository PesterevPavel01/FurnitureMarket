using Newtonsoft.Json;
using System.Net.Http;

namespace InterfaceApplication.Services.Api
{
    public class CommonService<T,Id> where T : class,new()
    {
        public readonly HttpConnector _httpConnector = new HttpConnector();

        public string _nameController;

        public CommonService()
        {
        }

        public CommonService(string nameController) 
        {
            _nameController = nameController;
        }

        public async Task<T> CreateAsync(T modelDto)
        {
            T result;

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(modelDto), HttpMethod.Post);

            if (response != null)
            return JsonConvert.DeserializeObject<T>(response);

            return new();

        }

        public Task<T> CreateMultiple(List<T> listModelDto)
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeleteAsync(Id id)
        {

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(id), HttpMethod.Delete);
            
            if (response != null)
                return JsonConvert.DeserializeObject<T>(response);

            return new();
        }

        public async Task<List<T>> GetAllAsync()
        {
            string response = await _httpConnector.GetDataByUrl(_nameController);

            if (response != null)
                return JsonConvert.DeserializeObject<List<T>>(response);

            return new List<T>();
        }

        public Task<T> GetByIdAsync(Id id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T modelDto)
        {
            T result;

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(modelDto), HttpMethod.Patch);

            if (response != null)
                return JsonConvert.DeserializeObject<T>(response);

            return new();
        }
    }
}
