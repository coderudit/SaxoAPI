using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRespository
    {
        List<T> GetItems<T>();

        T GetItem<T>(int id);

        void PostItem<T>(T item);

        void UpdateItem<T>(T item);

        void DeleteItem(int id);

    }
    
}
