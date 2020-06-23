using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using SaxoAPI.Converters;
using SaxoAPI.Models;

namespace SaxoAPI.Controllers
{
    [ApiController]
    [Route("/todo")]
    public class ToDoController : ControllerBase
    {
        private ToDoRepo _toDoRepo;
        public ToDoController(ToDoRepo toDoRepo)
        {
            _toDoRepo = toDoRepo;
        }

        [HttpGet]
        public IActionResult GetItems()
        {

            return Ok(_toDoRepo.GetItems());
        }

        [HttpGet]
        public IActionResult GetItem(int id)
        {
            var toDoEntity = _toDoRepo.GetItem(id);

            var toDoItem = ToDoItemConverter.Convert(toDoEntity);

            if (toDoItem == null)
                return NotFound();

            return Ok(toDoItem);
        }

        [HttpPost]
        public IActionResult PostItem(ToDoDTO todoContent)
        {
            if (todoContent == null)
                return NoContent();

            //todoContent content update inside db

            return CreatedAtAction("CreateToDo", todoContent);
        }

        [HttpPut]
        public IActionResult UpdateItem(int id)
        {
            if (todoContent == null)
                return NoContent();

            //todoContent content update inside db

            return CreatedAtAction("CreateToDo", todoContent);
        }

        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            IEnumerable<ToDoDTO> todoList = new List<ToDoDTO>(); //Fetched from db
            var todoItem = todoList.FirstOrDefault(x => x.Id == id);

            if (todoItem == null)
                return NotFound();

            return NoContent();
        }
    }
}
