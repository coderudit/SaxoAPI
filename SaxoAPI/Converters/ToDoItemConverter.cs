using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using SaxoAPI.Models;

namespace SaxoAPI.Converters
{
    public static class ToDoItemConverter
    {
        public static ToDoDTO Convert(ToDoEntity toDoEntity)
        {
            ToDoDTO toDoDTO = new ToDoDTO
            {
                Id = toDoEntity.Id,
                Description = toDoEntity.Description
            };

            return toDoDTO;
        }
    }
}
