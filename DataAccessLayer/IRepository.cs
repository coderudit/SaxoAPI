using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        List<T> GetItems();

        T GetItem(int id);

        int PostItem(T item);

        int UpdateItem(T item);

        int DeleteItem(int id);

    }
    
}
