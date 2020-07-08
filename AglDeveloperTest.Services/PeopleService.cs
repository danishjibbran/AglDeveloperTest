using AglDeveloperTest.Models;
using AglDeveloperTest.Repositories;
using System;
using System.Collections.Generic;

namespace AglDeveloperTest.Services
{
    public interface IPeopleService
    {
        List<People> GetPeople();
    }

    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleService(IPeopleRepository peopleRepository)
        {
            this._peopleRepository = peopleRepository;
        }
        public List<People> GetPeople()
        {
            return this._peopleRepository.GetPeople();
        }
    }
}
