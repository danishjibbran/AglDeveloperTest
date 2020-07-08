using System;
using System.Collections.Generic;

namespace AglDeveloperTest.Models
{
    public class People
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
