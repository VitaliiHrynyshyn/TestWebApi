using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Data.Models;
using TestWeb.Repositories;
using TestWeb.Services;
using TestWeb.Services.Models;

namespace TestWeb.Tests
{
    [TestClass]
    public class CategoryServiceTests
    {
        [TestMethod]
        public async Task GetAllAsync()
        {
            // Arrange
            var categoryEntities = new List<CategoryEntity> { new CategoryEntity { Description = "Description", Name = "Name" } };
            var categories = new List<Category> { new Category { Description = "Description1", Name = "Name1" } };

            var repositoryMock = new Mock<IGenericRepository<CategoryEntity>>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categoryEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<List<CategoryEntity>, List<Category>>(It.IsAny<List<CategoryEntity>>())).Returns(categories);

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
            var categoryEntity = new CategoryEntity { Description = "Description", Name = "Name" };
            var category = new Category { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IGenericRepository<CategoryEntity>>();
            repositoryMock.Setup(x => x.AddAsync(categoryEntity)).ReturnsAsync(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<CategoryEntity, Category>(It.IsAny<CategoryEntity>())).Returns(category);

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
            var categoryEntity = new CategoryEntity { Description = "Description", Name = "Name" };
            var category = new Category { Description = "Description1", Name = "Name1" };
           
            var repositoryMock = new Mock<IGenericRepository<CategoryEntity>>();
            repositoryMock.Setup(x => x.Update(categoryEntity)).Returns(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<CategoryEntity, Category>(It.IsAny<CategoryEntity>())).Returns(category);

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
            var categoryEntity = new CategoryEntity { Description = "Description", Name = "Name" };
            var category = new Category { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<CategoryEntity>>();
            repositoryMock.Setup(x => x.RemoveAsync(id)).ReturnsAsync(categoryEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<CategoryEntity, Category>(It.IsAny<CategoryEntity>())).Returns(category);

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
            var categoryEntities = new List<CategoryEntity> { new CategoryEntity { Description = "Description", Name = "Name" } };
            var categories = new Category { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<CategoryEntity>>();
            repositoryMock.Setup(x => x.GetAsync(p => p.Id == id, null, "Products")).ReturnsAsync(categoryEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<CategoryEntity, Category>(It.IsAny<CategoryEntity>())).Returns(categories);

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetWithProducts(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, categories.Description);
        }
    }
}
