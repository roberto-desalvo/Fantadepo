using Newtonsoft.Json;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.SearchCriteria.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;
using System.Text;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public class CrudRepository<T> : ICrudRepository<T>
        where T : class
    {
        protected readonly Context _context;
        protected HttpClient client;

        public CrudRepository(Context context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            client = new HttpClient();
        }

        protected string GetCustomPath()
        {            
            if(typeof(T) == typeof(Coach))
            {
                return "api/coaches";
            }
            if(typeof(T) == typeof(Team))
            {
                return "api/teams";
            }
            return string.Empty;
        }

        protected async Task<int> DoPost(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var uri = _context.GetFormedUri(GetCustomPath(), []);
            var response = await client.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return int.Parse(responseString);
        }

        protected async Task<bool> DoDelete(int id)
        {
            var uri = _context.GetFormedUri($"{GetCustomPath()}/{id}", []);
            var response = await client.DeleteAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var responseString = await response.Content.ReadAsStringAsync();
            return bool.Parse(responseString);
        } 

        protected async Task<T?> DoGetItem(int id, Dictionary<string, string> parameters)
        {
            var uri = _context.GetFormedUri($"{GetCustomPath()}/{id}", parameters ?? []);
            var response = await client.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        protected async Task<IEnumerable<T>> DoGetItemList(Dictionary<string, string> parameters)
        {
            var uri = _context.GetFormedUri($"{GetCustomPath()}", parameters ?? []);
            var response = await client.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(responseString) ?? [];
        }

        protected async Task<int> DoPut(int id, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var uri = _context.GetFormedUri($"{GetCustomPath()}/{id}", []);
            var response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return int.Parse(responseString);
        }

        public async Task<int> Create(T obj)
        {
            return await DoPost(obj);
        }

        public async Task<bool> Delete(int id)
        {
            return await DoDelete(id);
        }

        public async Task<T?> Get(int id, ISearchCriteria parameters = null!)
        {
            return await DoGetItem(id, parameters.GetParameters() ?? []);
        }

        public async Task<IEnumerable<T>> Get(ISearchCriteria parameters = null!)
        {
            return await DoGetItemList(parameters.GetParameters() ?? []);
        }

        public async Task<int> Update(int id, T obj)
        {
            return await DoPut(id, obj);
        }
    }
}
