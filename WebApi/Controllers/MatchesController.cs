﻿using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DbContexts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        readonly WebApiDbContext _context;

        public MatchesController(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post([FromBody]Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Matches.Add(match);
                await _context.SaveChangesAsync();

                return Ok("Матч создан.");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
