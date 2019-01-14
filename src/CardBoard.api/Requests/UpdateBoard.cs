using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardBoard.api.Requests
{
    public class UpdateBoard
    {
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public UpdateBoard(String name,string description)
        {
            Name = name;
            Description = description;
        }
    }
}
