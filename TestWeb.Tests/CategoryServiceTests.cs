using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Repositories.Interfaces;
using TestWeb.Services;
using Category = TestWeb.Models.Category;

namespace TestWeb.Tests
{
    [TestClass]
    public class CategoryServiceTests
    {
        [TestMethod]
        public async Task GetAllAsync()
        {
            // Arrange
            var categoryEntities = new List<Category> { new Category { Description = "Description", Name = "Name" } };
            var categories = new List<Services.Models.Category> { new Services.Models.Category { Description = "Description1", Name = "Name1" } };

            var repositoryMock = new Mock<IGenericRepository<Category>>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categoryEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<List<Category>, List<Services.Models.Category>>(It.IsAny<List<Category>>())).Returns(categories);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.First().Description, categories.First().Description);
        }

        [TestMethod]
        public async Task AddAsync()
        {
            // Arrange
            var categoryEntity = new Category { Description = "Description", Name = "Name" };
            var category = new Services.Models.Category { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IGenericRepository<Category>>();
            repositoryMock.Setup(x => x.AddAsync(categoryEntity)).ReturnsAsync(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Category, Services.Models.Category>(It.IsAny<Category>())).Returns(category);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.AddAsync(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, category.Description);
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            // Arrange
            var categoryEntity = new Category { Description = "Description", Name = "Name" };
            var category = new Services.Models.Category { Description = "Description1", Name = "Name1" };
           
            var repositoryMock = new Mock<IGenericRepository<Category>>();
            repositoryMock.Setup(x => x.Update(categoryEntity)).Returns(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Category, Services.Models.Category>(It.IsAny<Category>())).Returns(category);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdateAsync(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, category.Description);
        }

        [TestMethod]
        public async Task RemoveAsync()
        {
            // Arrange
            var categoryEntity = new Category { Description = "Description", Name = "Name" };
            var category = new Services.Models.Category { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<Category>>();
            repositoryMock.Setup(x => x.RemoveAsync(id)).ReturnsAsync(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Category, Services.Models.Category>(It.IsAny<Category>())).Returns(category);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.RemoveAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, category.Description);
        }

        [TestMethod]
        public async Task GetWithProducts()
        {
            // Arrange
            var categoryEntities = new List<Category> { new Category { Description = "Description", Name = "Name" } };
            var categories = new Services.Models.Category { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<Category>>();
            repositoryMock.Setup(x => x.GetAsync(p => p.Id == id, null, "Products")).ReturnsAsync(categoryEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Category, Services.Models.Category>(It.IsAny<Category>())).Returns(categories);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetWithProducts(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, categories.Description);
        }
    }
}
