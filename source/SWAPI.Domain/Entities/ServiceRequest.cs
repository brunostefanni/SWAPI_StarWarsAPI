using System;
using System.Collections;
using System.Collections.Generic;

namespace SWAPI.Domain.Entities
{
    public class ServiceRequest
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IList<Starship> Results { get; set; }
    }
}
