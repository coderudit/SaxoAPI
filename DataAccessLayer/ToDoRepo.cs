using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class ToDoRepo //: IRespository
    {
        private readonly List<ToDoEntity> _toDoEntityList;
        public ToDoRepo()
        {

            _toDoEntityList = new List<ToDoEntity>
            {
                new ToDoEntity { Id = 1, Description = "Item 1" },
                new ToDoEntity { Id = 2, Description = "Item 2" }
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

        public void PostItem(ToDoEntity item)
        {
            _toDoEntityList.Add(item);
        }

        public void UpdateItem(ToDoEntity item)
        {
            _toDoEntityList.FirstOrDefault(x => x.Id == item.Id).Description = item.Description;
        }

        public void DeleteItem(int id)
        {
            var itemToDelete = _toDoEntityList.FirstOrDefault(x => x.Id == id);
            if (itemToDelete != null)
                _toDoEntityList.Remove(itemToDelete);
        }

    }
}
