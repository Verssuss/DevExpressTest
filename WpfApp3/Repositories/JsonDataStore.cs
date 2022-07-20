using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WpfApp3.Models;

namespace WpfApp3.Repositories
{
    public class JsonDataStore : IDataStore<Employee>
    {
        private List<Employee> _employees { get; set; }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public JsonDataStore()
        {
            if (File.Exists("NewData1.json"))
                _employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("NewData1.json"), settings) ?? new List<Employee>();
            else
                _employees = new List<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await Task.FromResult(_employees);
        }

        public async Task<bool> Fetch(IEnumerable<Employee> employees)
        {
            var res = JsonConvert.SerializeObject(employees, settings);

            await File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory, "NewData1.json"), res);
            return await Task.FromResult(true);
        }
    }
}