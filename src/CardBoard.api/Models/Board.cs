using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardBoard.api.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Board(int _id ,string _name , string _description)
        {
            Id = _id;
            Name = _name;
            Description = _description;
        }

        
    }
}
