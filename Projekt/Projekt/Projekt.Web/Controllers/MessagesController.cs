﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.Web.Data;
using Projekt.Web.Models;

namespace Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesRepository ItemRepository;
        private readonly UsersDbContext _dbContext;

        public MessagesController(IMessagesRepository DbMessagesRepository, UsersDbContext usersDbContext)
        {
            ItemRepository = DbMessagesRepository;
            _dbContext = usersDbContext;
        }

        [HttpGet("{id}/{id2}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Messages>> List(int id, int id2)
        {
            return ItemRepository.GetAll(id,id2).ToList();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Messages> Create([FromBody]Messages item)
        {
            try
            {
                ItemRepository.Add(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while adding item");
            }
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Messages item)
        {
            try
            {
                ItemRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while editing item");
            }
            return NoContent();
        }

    }
}
