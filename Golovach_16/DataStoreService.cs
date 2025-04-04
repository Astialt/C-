using Newtonsoft.Json;
using OrderManagement.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class DataStoreService
    {
        private readonly string _storeFilePath = "store.json";

        public async Task SaveStoreDataAsync(StoreData data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(_storeFilePath, json);
        }

        public async Task<StoreData> LoadStoreDataAsync()
        {
            if (!File.Exists(_storeFilePath))
                return new StoreData();
            string json = await File.ReadAllTextAsync(_storeFilePath);
            return JsonConvert.DeserializeObject<StoreData>(json) ?? new StoreData();
        }
    }

    public class StoreData
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
        public List<ClientModel> Clients { get; set; } = new List<ClientModel>();
    }
}
