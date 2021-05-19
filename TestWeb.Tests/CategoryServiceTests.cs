using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Application.Services;
using TestWeb.Persistence.Base;
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
            var categories = new List<Category> { new Category { Description = "Description", Name = "Name" } };

            var repositoryMock = new Mock<ICategoryRepository>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);

            var service = new CategoryService(repositoryMock.Object);

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
            var category = new Category { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<ICategoryRepository>();
            repositoryMock.Setup(x => x.AddAsync(category)).ReturnsAsync(category);

            var service = new CategoryService(repositoryMock.Object);

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
            var category = new Category { Description = "Description1", Name = "Name1" };
           
            var repositoryMock = new Mock<ICategoryRepository>();
            repositoryMock.Setup(x => x.Update(category)).Returns(category);

            var service = new CategoryService(repositoryMock.Object);

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
            var category = new Category { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<ICategoryRepository>();
            repositoryMock.Setup(x => x.RemoveAsync(id)).ReturnsAsync(category);

            var service = new CategoryService(repositoryMock.Object);

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
            var id = 1;

            var repositoryMock = new Mock<ICategoryRepository>();
            repositoryMock.Setup(x => x.GetWithProductsAsync()).ReturnsAsync(categoryEntities);

            var service = new CategoryService(repositoryMock.Object);

            // Act
            var result = await service.GetWithProducts(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, categoryEntities.First().Description);
        }
    }
}
