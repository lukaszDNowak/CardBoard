using CardBoard.api.Models;
using CardBoard.api.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardBoard.api.Controllers
{
    [Route("boards")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        //public IActionResult Get()
        //{
        //}

        //public ActionResult Get()
        //{
        //}
        private static List<Board> _boards = new List<Board>
        {
            new Board(1,"Bo","Opis1"),
            new Board(2,"Ao","Opis2"),
            new Board(3,"Zo","Opis3")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Board>> Get() // z parametrem sprzydaje sie do dokumentacji
        {
            return _boards;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Board>> Get(string name) // z parametrem sprzydaje sie do dokumentacji
        {
            var boards = _boards.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                boards = boards.Where(b => b.Name.Contains(name));
            }
            return Ok(boards);
        }

        [HttpGet("{id:int}")] // Walidacja po : tutaj po int
        public ActionResult<Board> Get(int id) // z parametrem sprzydaje sie do dokumentacji
        {
            var board = _boards.SingleOrDefault(b => b.Id == id);
            if (board is null)
            {
                return NotFound();
            }
            return board;
        }
        [HttpPost]
        public ActionResult Post(CreateBoard request)
        {
            var id = _boards.Max(b => b.Id) + 1;
            var board = new Board(id, request.Name, request.Description);
            _boards.Add(board);

            //return Created($"http://localhost:5000/boards/{id}",null);

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(UpdateBoard request,int id)
        {
        var board = _boards.SingleOrDefault(b => b.Id == id);
            if (board is null)
            {
                return NotFound();
            }
            board.Name = request.Name;
            board.Description = request.Description;

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var board = _boards.SingleOrDefault(b => b.Id == id);
            if (board is null)
            {
                return NotFound();
            }
            _boards.Remove(board);

            return NoContent();
        }
    }
}
