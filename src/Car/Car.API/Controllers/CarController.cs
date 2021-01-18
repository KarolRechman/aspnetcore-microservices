﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarApi.Data;
using CarApi.Models;
using CarApi.IServices;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ICarService carService { get; }
        public CarController(ICarService _carService)
        {
            carService = _carService;
        }

        /// <summary>
        ///  metoda obsługująca request GET dla api/Car
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Car>> GetCar()
        {
            return await carService.GetCars();
        }

        /// <summary>
        ///  metoda obsługująca request GET dla wybranego Id - api/Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await carService.GetCarByIdAsync(id);
        }

        /// <summary>
        /// metoda obsługująca request PUT dla wybranego Id - api/Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Car PutCar([FromBody]Car car)
        {
            return carService.UpdateCar(car);
        }

        /// <summary>
        ///  metoda obsługująca request POST dla api/Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public async  Task<String> PostCar([FromBody]Car car)
        {
            return await carService.AddCar(car);
        }

        /// <summary>
        ///  metoda obsługująca request DELETE dla wybranego Id - api/Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<String> DeleteCar(int id)
        {
            return await carService.DeleteCar(id);
        }

        /// <summary>
        ///  metoda sprawdzająca czy rekord istnieje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.idCar == id);
        }
    }
}
