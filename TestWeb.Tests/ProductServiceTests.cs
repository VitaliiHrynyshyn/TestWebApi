using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Application.Services;
using TestWeb.Persistence.Base;
using Product = TestWeb.Models.Product;

namespace TestWeb.Tests
{
    [TestClass]
    public class CategoryProductServiceTestsServiceTests
    {
        [TestMethod]
        public async Task GetAllAsync()
        {
            // Arrange
            var products = new List<Product> { new Product { Description = "Description1", Name = "Name1" } };

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            var service = new ProductService(repositoryMock.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.First().Description, products.First().Description);
        }

        [TestMethod]
        public async Task AddAsync()
        {
            // Arrange
            var product = new Product() { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(x => x.AddAsync(product)).ReturnsAsync(product);

            var service = new ProductService(repositoryMock.Object);

            // Act
            var result = await service.AddAsync(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, product.Description);
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            // Arrange
            var product = new Product { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(x => x.Update(product)).Returns(product);

            var service = new ProductService(repositoryMock.Object);

            // Act
            var result = await service.UpdateAsync(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, product.Description);
        }

        [TestMethod]
        public async Task RemoveAsync()
        {
            // Arrange
            var product = new Product() { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(x => x.RemoveAsync(id)).ReturnsAsync(product);

            var service = new ProductService(repositoryMock.Object);

            // Act
            var result = await service.RemoveAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, product.Description);
        }

        [TestMethod]
        public async Task GetWithCategories()
        {
            // Arrange
            var product = new List<Product> { new Product() { Description = "Description", Name = "Name" } };
            var id = 1;

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(x => x.GetWithCategoryAsync()).ReturnsAsync(product);

            var service = new ProductService(repositoryMock.Object);

            // Act
            var result = await service.GetWithCategories(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, product.First().Description);
        }
    }
}
