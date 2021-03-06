﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DbContexts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        readonly WebApiDbContext _context;

        public SetsController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("{matchId}")]
        public IActionResult Get(int matchId)
        {
            var teams = _context.Sets.Where(d => d.MatchId == matchId);
            return Ok(teams);
        }
    }
}
