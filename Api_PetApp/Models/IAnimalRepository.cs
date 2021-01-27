using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_PetApp.Models;

namespace Api_PetApp.Models
{
    public interface IAnimalRepository
    {
        Animal GetAnimal(int Id);
        IEnumerable<Animal> GetAllAnimals();
        IEnumerable<Animal> GetShelterAnimals(int shelterId);
        Animal Add(Animal animal);
        Animal Update(int id, Animal animal);
        Animal Delete(int Id);
        bool AnimalExists(int id);

    }
}
