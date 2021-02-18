using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestWeb.Data.Models;
using TestWeb.Repositories;
using TestWeb.Services;
using TestWeb.Services.Models;

namespace TestWeb.Tests
{
    [TestClass]
    public class CategoryProductServiceTestsServiceTests
    {
        [TestMethod]
        public async Task GetAllAsync()
        {
            // Arrange
            var productEntities = new List<ProductEntity> { new ProductEntity { Description = "Description", Name = "Name" } };
            var products = new List<Product> { new Product { Description = "Description1", Name = "Name1" } };

            var repositoryMock = new Mock<IGenericRepository<ProductEntity>>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(productEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<List<ProductEntity>, List<Product>>(It.IsAny<List<ProductEntity>>())).Returns(products);

            var service = new ProductService(repositoryMock.Object, mapperMock.Object);

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
            var productEntity = new ProductEntity() { Description = "Description", Name = "Name" };
            var product = new Product() { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IGenericRepository<ProductEntity>>();
            repositoryMock.Setup(x => x.AddAsync(productEntity)).ReturnsAsync(productEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<ProductEntity, Product>(It.IsAny<ProductEntity>())).Returns(product);

            var service = new ProductService(repositoryMock.Object, mapperMock.Object);

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
            var productEntity = new ProductEntity() { Description = "Description", Name = "Name" };
            var product = new Product() { Description = "Description1", Name = "Name1" };

            var repositoryMock = new Mock<IGenericRepository<ProductEntity>>();
            repositoryMock.Setup(x => x.Update(productEntity)).Returns(productEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<ProductEntity, Product>(It.IsAny<ProductEntity>())).Returns(product);

            var service = new ProductService(repositoryMock.Object, mapperMock.Object);

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
            var productEntity = new ProductEntity() { Description = "Description", Name = "Name" };
            var product = new Product() { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<ProductEntity>>();
            repositoryMock.Setup(x => x.RemoveAsync(id)).ReturnsAsync(productEntity);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<ProductEntity, Product>(It.IsAny<ProductEntity>())).Returns(product);

            var service = new ProductService(repositoryMock.Object, mapperMock.Object);

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
            var productEntities = new List<ProductEntity> { new ProductEntity() { Description = "Description", Name = "Name" } };
            var product = new Product() { Description = "Description1", Name = "Name1" };
            var id = 1;

            var repositoryMock = new Mock<IGenericRepository<ProductEntity>>();
            repositoryMock.Setup(x => x.GetAsync(p => p.Id == id, null, "Category")).ReturnsAsync(productEntities);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<ProductEntity, Product>(It.IsAny<ProductEntity>())).Returns(product);

            var service = new ProductService(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetWithCategories(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, product.Description);
        }
    }
}
