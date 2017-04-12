using SelfHostedWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWebApi.Repositories
{
    public interface IProvinceRepo : IDisposable
    {
        void Add(Province item);
        IEnumerable<Province> GetAll();
        Province Find(string rubro);
        Province GetById(int id);
        void Delete(int id);
        void Edit(Province item);
        void SaveChanges();
    }
}
