using Api_PetApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_PetApp.Models;

namespace Api_PetApp.Models
{
    public class SQLShelterRepository : IShelterRepository
    {
        private readonly PetAppContext _context;

        public SQLShelterRepository(PetAppContext context) { _context = context; }

        public Shelter AddShelter(Shelter shelter)
        {
            _context.Shelter.Add(shelter);
            _context.SaveChanges();
            return shelter;
        }

        public Shelter DeleteShelter(int Id)
        {
            var toRemove = _context.Shelter.Find(Id);
            if (toRemove != null)
            {
                _context.Shelter.Remove(toRemove);
                _context.SaveChanges();
            }
            return toRemove;
        }

        public Shelter EditShelter(int id, Shelter shelter)
        {
            _context.Entry(shelter).State = EntityState.Modified;
            _context.SaveChanges();
            return shelter;
        }

        public IEnumerable<Shelter> GetShelter()
        {
            return _context.Shelter.Include(s => s.Animals).ToList();
        }

        public Shelter GetShelter(int id)
        {
            return _context.Shelter.Include(s => s.Animals).Where(s => s.Id == id).FirstOrDefault();
        }

        public bool ShelterExists(int id)
        {
            return _context.Shelter.Any(e => e.Id == id);
        }
    }
}
