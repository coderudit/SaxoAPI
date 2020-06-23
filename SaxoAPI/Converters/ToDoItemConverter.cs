using DataAccessLayer.Entities;
using SaxoAPI.Models;

namespace SaxoAPI.Converters
{
    public static class ToDoItemConverter
    {
        public static ToDoDTO ConvertToDTO(ToDoEntity toDoEntity)
        {
            ToDoDTO toDoDTO = new ToDoDTO
            {
                Id = toDoEntity.Id,
                Description = toDoEntity.Description
            };

            return toDoDTO;
        }

        public static ToDoEntity ConvertToEntity(ToDoDTO toDoDTO)
        {
            ToDoEntity toDoEntity = new ToDoEntity
            {
                Id = toDoDTO.Id,
                Description = toDoDTO.Description
            };

            return toDoEntity;
        }
    }
}
