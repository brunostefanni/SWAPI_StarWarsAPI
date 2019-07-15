using System;
using System.Collections.Generic;

namespace SWAPI.Domain.Entities
{
    public class BaseModel
    {
        public IEnumerable<string> Films { get; protected set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }

        public BaseModel(){ }
    }
}