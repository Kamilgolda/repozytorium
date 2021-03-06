﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zadApi.Models;
using zadApi.Web.Data;

namespace zadApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IItemRepository ItemRepository;
        private readonly StudentsDbContext _dbContext;


        public StudentsController(IItemRepository DbitemRepository, StudentsDbContext studentsDbContext)
        {
            ItemRepository = DbitemRepository;
            _dbContext = studentsDbContext;
        }


        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return ItemRepository.GetAll().ToList();

        }
        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(string id)
        {
            return ItemRepository.Get(id);
        }
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Student item)
        {
            ItemRepository.Add(item);
        }
        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            ItemRepository.Update(value);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ItemRepository.Remove(id);
        }




    }
}