using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer
{
    public class ToDoRepo : IRepository<ToDoEntity>
    {
        private readonly List<ToDoEntity> _toDoEntityList;
        private readonly ILogger<ToDoRepo> _logger;
        public ToDoRepo(ILogger<ToDoRepo> logger)
        {
            _logger = logger;
            _toDoEntityList = new List<ToDoEntity>
            {
                new ToDoEntity { Id = 1, Description = "Item 1", Name = "Item 1 name"},
                new ToDoEntity { Id = 2, Description = "Item 2", Name = "Item 2 name" }
            };
        }

        public ToDoEntity GetItem(int id)
        {
            return _toDoEntityList.FirstOrDefault(x => x.Id == id);
        }

        public List<ToDoEntity> GetItems()
        {
            return _toDoEntityList;
        }

        public int PostItem(ToDoEntity item)
        {
            var result = 0;
            try
            {
                _toDoEntityList.Add(item);
                result = 1;
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.Message);
            }
            return result;
        }

        public int UpdateItem(ToDoEntity item)
        {
            var result = 0;
            try
            {
                _toDoEntityList.FirstOrDefault(x => x.Id == item.Id).Description = item.Description;
                result = 1;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
            }
            return result;
        }

        public int DeleteItem(int id)
        {
            var result = 0;
            try
            {
                var itemToDelete = _toDoEntityList.FirstOrDefault(x => x.Id == id);
                if (itemToDelete != null)
                {
                    _toDoEntityList.Remove(itemToDelete);
                    result = 1;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
            }
            return result;
        }

    }
}
