using SelfHostedWebApi.EF;
using SelfHostedWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWebApi.Repositories
{
    public class ProvinceRepo : IProvinceRepo, IDisposable
    {
        public readonly Context _context;

        public ProvinceRepo(Context context = null)
        {
            if (context == null)
            {
                _context = new Context();
            }
            else
            {
                _context = context;
            }
        }

        public void Add(Province item)
        {
            _context.Provinces.Add(item);
        }

        public Province Find(string item)
        {
            return _context.Provinces
                .Where(e => e.Name.ToLower().Equals(item.ToLower()))
                .SingleOrDefault();
        }

        public Province GetById(int id)
        {
            return _context.Provinces
                .Where(e => e.Id.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<Province> GetAll()
        {
            return _context.Provinces.ToList();
        }

        public void Delete(int id)
        {
            // ToDo - Integrate with EF Core
            var itemToRemove = _context.Provinces.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _context.Provinces.Remove(itemToRemove);
            }

        }

        public void Edit(Province item)
        {
            // ToDo - Integrate with EF Core
            var itemToUpdate = _context.Provinces.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                //_context.Provinces.Update(itemToUpdate);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
