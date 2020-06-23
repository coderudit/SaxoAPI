using System;
using System.Collections.Generic;
using System.Net;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaxoAPI.Converters;
using SaxoAPI.Models;

namespace SaxoAPI.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IRepository<ToDoEntity> _toDoRepo;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IRepository<ToDoEntity> toDoRepo, ILogger<ToDoController> logger)
        {
            _toDoRepo = toDoRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var toDoList = new List<ToDoDTO>();
            try
            {
                foreach (var item in _toDoRepo.GetItems())
                {
                    var toDoItem = ToDoItemConverter.ConvertToDTO(item);
                    toDoList.Add(toDoItem);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"Request failed for { HttpContext.TraceIdentifier } with message: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while fetching.");
            }
            return Ok(toDoList);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoDTO> GetItem(int id)
        {
            ToDoDTO toDoItem;
            try
            {
                toDoItem = ToDoItemConverter.ConvertToDTO(_toDoRepo.GetItem(id));

                if (toDoItem == null)
                    return NotFound();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Request failed for { HttpContext.TraceIdentifier } with message: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while fetching.");
            }
            return Ok(toDoItem);
        }

        [HttpPost]
        public ActionResult<int> PostItem(ToDoDTO item)
        {
            if (item == null)
                return StatusCode((int)HttpStatusCode.BadRequest, "No item to create.");

            int result;
            try
            {
                result = _toDoRepo.PostItem(ToDoItemConverter.ConvertToEntity(item));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Request failed for { HttpContext.TraceIdentifier } with message: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while creating.");
            }
            if (result == 1)
                return CreatedAtAction("PostItem", item);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while creating.");
        }

        [HttpPut]
        public ActionResult<int> UpdateItem(ToDoDTO item)
        {
            if (item == null)
                return StatusCode((int)HttpStatusCode.BadRequest, "No item to update.");
            int result;
            try
            {
                result = _toDoRepo.UpdateItem(ToDoItemConverter.ConvertToEntity(item));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Request failed for { HttpContext.TraceIdentifier } with message: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while updating.");
            }
            if (result == 1)
                return Content("Resource updated successfully.");
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while updating.");

        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteItem(int id)
        {
            int result;
            try
            {
                result = _toDoRepo.DeleteItem(id);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Request failed for { HttpContext.TraceIdentifier } with message: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while deleting.");
            }
            if (result == 1)
                return Content("Resource deleted successfully.");
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed while deleting.");
        }
    }
}
