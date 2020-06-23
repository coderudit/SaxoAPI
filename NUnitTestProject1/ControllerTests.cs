using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SaxoAPI.Controllers;
using SaxoAPI.Models;

namespace NUnitTestProject1
{
    public class ControllerTests
    {
        private Mock<ILogger<ToDoController>> _mockLogger = null;
        private Mock<IRepository<ToDoEntity>> _mockToDoRepo = null;
        private List<ToDoEntity> _toDoList = null;

        [SetUp]
        public void Setup()
        {
            _mockToDoRepo = new Mock<IRepository<ToDoEntity>>();
            _mockLogger = new Mock<ILogger<ToDoController>>();
            _toDoList = SetUpFakeData();
            SetUpFakeData();
        }


        [Test]
        public void GetItemsTest()
        {
            _mockToDoRepo.Setup(x => x.GetItems()).Returns(_toDoList);

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var result = controller.GetItems();
            Assert.NotNull(result);
        }

        [Test]
        public void GetItemTest()
        {
            _mockToDoRepo.Setup(x => x.GetItem(It.IsAny<int>())).Returns(new ToDoEntity { Id = int.MaxValue, Description = string.Empty, Name = string.Empty });

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var item = controller.GetItem(1);

            Assert.NotNull(item);
        }

        [Test]
        public void GetItemThrowsExceptionTest()
        {
            _mockToDoRepo.Setup(x => x.GetItem(It.IsAny<int>())).Returns(new ToDoEntity { Id = int.MaxValue, Description = string.Empty, Name = string.Empty });

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var item = controller.GetItem(1);

            Assert.NotNull(item);
        }

        [Test]
        public void PostItemTest()
        {
            var toDoItem = new ToDoDTO { Id = 3, Description = "Item 3", Name = "Item 3 name" };
            _mockToDoRepo.Setup(x => x.PostItem(It.IsAny<ToDoEntity>())).Returns(1);

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var item = controller.PostItem(toDoItem);

            Assert.NotNull(item);
        }

        [Test]
        public void UpdateItemTest()
        {
            var toDoItem = new ToDoDTO { Id = 2, Description = "Item 2 changed" };
            _mockToDoRepo.Setup(x => x.UpdateItem(It.IsAny<ToDoEntity>())).Returns(1);

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var item = controller.UpdateItem(toDoItem);

            Assert.NotNull(item);
        }

        [Test]
        public void DeleteItemTest()
        {
            _mockToDoRepo.Setup(x => x.DeleteItem(It.IsAny<int>())).Returns(1);

            var controller = new ToDoController(_mockToDoRepo.Object, _mockLogger.Object);
            var item = controller.DeleteItem(1);

            Assert.NotNull(item);
        }

        private List<ToDoEntity> SetUpFakeData()
        {
            return new List<ToDoEntity>
            {
                new ToDoEntity { Id = 1, Description = "Item 1" },
                new ToDoEntity { Id = 2, Description = "Item 2" }
            };
        }
    }
}