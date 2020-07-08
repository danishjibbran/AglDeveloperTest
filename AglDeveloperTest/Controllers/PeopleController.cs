using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AglDeveloperTest.Models;
using AglDeveloperTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AglDeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }

        [HttpGet]
        public IEnumerable<People> Get()
        {
            return this._peopleService.GetPeople();
        }
    }
}
