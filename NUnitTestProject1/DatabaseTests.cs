using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Castle.Core.Logging;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SaxoAPI.Controllers;
using SaxoAPI.Converters;
using SaxoAPI.Models;

namespace NUnitTestProject1
{
    public class DatabaseTests
    {
        private Mock<ILogger<ToDoRepo>> _mockLogger = null;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<ToDoRepo>>();
        }


        [Test]
        public void GetItemsTest()
        {
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.GetItems();
            Assert.NotNull(result);
        }

        [Test]
        public void GetItemTest()
        {
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.GetItem(1);
            Assert.NotNull(result);
        }

        [Test]
        public void GetItemNoDataFoundTest()
        {
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.GetItem(5);
            Assert.IsNull(result);
        }

        [Test]
        public void PostItemTest()
        {
            var toDoItem = new ToDoEntity { Id = 3, Description = "Item 3", Name = "Item 3 name" };
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.PostItem(toDoItem);
            Assert.AreEqual(result,1);
        }

        [Test]
        public void UpdateItemTest()
        {
            var toDoItem = new ToDoEntity { Id = 2, Description = "Item 2 changed", Name = "Item 2 name" };
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.UpdateItem(toDoItem);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void UpdateItemNotFoundTest()
        {
            var toDoItem = new ToDoEntity { Id = 4, Description = "Item 4 changed", Name = "Item 4 name" };
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.UpdateItem(toDoItem);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void DeleteItemTest()
        {
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.DeleteItem(1);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void DeleteItemNotFoundTest()
        {
            IRepository<ToDoEntity> repository = new ToDoRepo(_mockLogger.Object);
            var result = repository.DeleteItem(5);
            Assert.AreEqual(result, 0);
        }

    }
}
