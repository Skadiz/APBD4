using System;
using CW4.Models;
using CW4.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CW4.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public AnimalsController(IDbService iDbService)
        {
            _dbService = iDbService;
        }


        [HttpGet]
        public IActionResult GetAnimal()
        {
            return Ok(_dbService.GetAnimals());
        }


        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            if (_dbService.GetAnimal(id) != null)
            {
                return Ok(_dbService.GetAnimal(id));
            }
            else
            {
                return NotFound("Nie znaleziono zwierzeta o tym id");
            }
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            animal.IdAnimal = $"{new Random().Next(1, 20000)}";
            return Ok(animal);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id)
        {
            if (_dbService.GetAnimal(id) != null)
            {
                return Ok("Aktualizacja zakończona");
            }
            else
            {
                return NotFound("Nie znaleziono zwierzeta o tym id");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            if (_dbService.GetAnimal(id) != null)
            {
                return Ok("Usuwanie zakończone");
            }
            else
            {
                return NotFound("Nie znaleziono zwierzeta o tym id");
            }
        }


    }
}