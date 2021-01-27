using Api_PetApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_PetApp.Models;

namespace Api_PetApp.Models
{
    public class SQLAnimalRepository : IAnimalRepository
    {
        private readonly PetAppContext _context;

        public SQLAnimalRepository(PetAppContext context)
        {
            _context = context;
        }
        public Animal Add(Animal animal)
        {
            _context.Animal.Add(animal);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimalExists(animal.Id))
                {
                    return animal;
                }
                else
                {
                    throw;
                }
            }

            return animal;
        }

        public Animal Delete(int Id)
        {
            Animal toDelete = _context.Animal.Find(Id);
            if (toDelete != null) { _context.Animal.Remove(toDelete);_context.SaveChangesAsync(); }
            return toDelete;
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return _context.Animal.ToList();
        }

        public Animal GetAnimal(int Id)
        {
            return _context.Animal.Where(a => a.Id == Id).Where(a => a.IsAdopted != true).FirstOrDefault();
        }

        public IEnumerable<Animal> GetShelterAnimals(int shelterId)
        {
            var animals = _context.Shelter.Where(s => s.Id == shelterId).Include(s => s.Animals).FirstOrDefault()?.Animals;
            return animals.Where(a => a.IsAdopted != true).ToList();
        }

        public Animal Update(int id, Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
            return animal;
        }

        public bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }

    }

}
