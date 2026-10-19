using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumeBee.Tests.Controllers
{
    public class CenterControllerTests
    {
        private readonly Mock<ICenterRepository> _mockRepo;
        private readonly CenterController _controller;

        public CenterControllerTests()
        {
            _mockRepo = new Mock<ICenterRepository>();

            _controller = new CenterController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllActive_ShouldReturnOkResult_WithListOfCenters()
        {
            // Arrange
            var centers = new List<CenterModel>
            {
                new CenterModel
                {
                    Id = 1,
                    Code = "CTR001",
                    Name = "BlumeBee Noida Center",
                    AddressLine1 = "Sector 62",
                    City = "Noida",
                    State = "Uttar Pradesh",
                    Country = "India",
                    Pincode = "201309",
                    Phone = "9876543210",
                    Email = "noida@blumebee.com",
                    IsActive = true
                }
            };

            _mockRepo.Setup(r => r.GetAllActive()).Returns(centers);

            // Act
            var result = _controller.GetAllActive();

            // Assert
            //var okResult = Assert.IsType<OkObjectResult>(result);

            //var data = Assert.IsAssignableFrom<IEnumerable<CenterModel>>(okResult.Value);

            //Assert.Single(data);

            //Assert.Equal("BlumeBee Noida Center", data.First().Name);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsAssignableFrom<IEnumerable<CenterModel>>(okResult.Value);

            var center = Assert.Single(data);

            Assert.Equal(1, center.Id);
            Assert.Equal("CTR001", center.Code);
            Assert.Equal("BlumeBee Noida Center", center.Name);
            Assert.Equal("Sector 62", center.AddressLine1);
            Assert.Equal("Noida", center.City);
            Assert.Equal("Uttar Pradesh", center.State);
            Assert.Equal("India", center.Country);
            Assert.Equal("201309", center.Pincode);
            Assert.Equal("9876543210", center.Phone);
            Assert.Equal("noida@blumebee.com", center.Email);
            Assert.True(center.IsActive);
        }


        [Fact]
        public void GetAllActive_ShouldReturnOkResult_WithListOfThreeCenters()
        {
            // just testing with three centers to see if the controller returns all of them correctly
            // Arrange
            var expectedCenters = new List<CenterModel>
            {
                    new CenterModel
                    {
                        Id = 1,
                        Code = "CTR001",
                        Name = "BlumeBee Noida Center",
                        AddressLine1 = "Sector 62",
                        City = "Noida",
                        State = "Uttar Pradesh",
                        Country = "India",
                        Pincode = "201309",
                        Phone = "9876543210",
                        Email = "noida@blumebee.com",
                        IsActive = true
                    },
                    new CenterModel
                    {
                        Id = 2,
                        Code = "CTR002",
                        Name = "BlumeBee Greater Noida Center",
                        AddressLine1 = "Alpha 1",
                        City = "Greater Noida",
                        State = "Uttar Pradesh",
                        Country = "India",
                        Pincode = "201310",
                        Phone = "9876543211",
                        Email = "greaternoida@blumebee.com",
                        IsActive = true
                    },
                    new CenterModel
                    {
                        Id = 3,
                        Code = "CTR003",
                        Name = "BlumeBee Delhi Center",
                        AddressLine1 = "Dwarka",
                        City = "New Delhi",
                        State = "Delhi",
                        Country = "India",
                        Pincode = "110075",
                        Phone = "9876543212",
                        Email = "delhi@blumebee.com",
                        IsActive = true
                    }
            };

            _mockRepo.Setup(r => r.GetAllActive())
                     .Returns(expectedCenters);

            // Act
            var result = _controller.GetAllActive();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var actualCenters = Assert.IsAssignableFrom<IEnumerable<CenterModel>>(okResult.Value).ToList();

            Assert.Equal(expectedCenters.Count, actualCenters.Count);

            for (int i = 0; i < expectedCenters.Count; i++)
            {
                Assert.Equal(expectedCenters[i].Id, actualCenters[i].Id);
                Assert.Equal(expectedCenters[i].Code, actualCenters[i].Code);
                Assert.Equal(expectedCenters[i].Name, actualCenters[i].Name);
                Assert.Equal(expectedCenters[i].AddressLine1, actualCenters[i].AddressLine1);
                Assert.Equal(expectedCenters[i].City, actualCenters[i].City);
                Assert.Equal(expectedCenters[i].State, actualCenters[i].State);
                Assert.Equal(expectedCenters[i].Country, actualCenters[i].Country);
                Assert.Equal(expectedCenters[i].Pincode, actualCenters[i].Pincode);
                Assert.Equal(expectedCenters[i].Phone, actualCenters[i].Phone);
                Assert.Equal(expectedCenters[i].Email, actualCenters[i].Email);
                Assert.Equal(expectedCenters[i].IsActive, actualCenters[i].IsActive);
            }
        }

        [Fact]
        public void GetAllNonActive_ShouldReturnOkResult_WithListOfNonActiveCenters()
        {
            // Arrange
            var expectedCenters = new List<CenterModel>
            {
                new CenterModel
                {
                    Id = 1,
                    Code = "CTR001",
                    Name = "BlumeBee Noida Center",
                    AddressLine1 = "Sector 62",
                    City = "Noida",
                    State = "Uttar Pradesh",
                    Country = "India",
                    Pincode = "201309",
                    Phone = "9876543210",
                    Email = "noida@blumebee.com",
                    IsActive = false
                },
                new CenterModel
                {
                    Id = 2,
                    Code = "CTR002",
                    Name = "BlumeBee Greater Noida Center",
                    AddressLine1 = "Alpha 1",
                    City = "Greater Noida",
                    State = "Uttar Pradesh",
                    Country = "India",
                    Pincode = "201310",
                    Phone = "9876543211",
                    Email = "greaternoida@blumebee.com",
                    IsActive = false
                },
                new CenterModel
                {
                    Id = 3,
                    Code = "CTR003",
                    Name = "BlumeBee Delhi Center",
                    AddressLine1 = "Dwarka",
                    City = "New Delhi",
                    State = "Delhi",
                    Country = "India",
                    Pincode = "110075",
                    Phone = "9876543212",
                    Email = "delhi@blumebee.com",
                    IsActive = false
                }
            };

            _mockRepo.Setup(r => r.GetAllNonActive())
                     .Returns(expectedCenters);

            // Act
            var result = _controller.GetAllNonActive();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var actualCenters = Assert.IsAssignableFrom<IEnumerable<CenterModel>>(okResult.Value).ToList();

            Assert.Equal(expectedCenters.Count, actualCenters.Count);

            for (int i = 0; i < expectedCenters.Count; i++)
            {
                Assert.Equal(expectedCenters[i].Id, actualCenters[i].Id);
                Assert.Equal(expectedCenters[i].Code, actualCenters[i].Code);
                Assert.Equal(expectedCenters[i].Name, actualCenters[i].Name);
                Assert.Equal(expectedCenters[i].AddressLine1, actualCenters[i].AddressLine1);
                Assert.Equal(expectedCenters[i].City, actualCenters[i].City);
                Assert.Equal(expectedCenters[i].State, actualCenters[i].State);
                Assert.Equal(expectedCenters[i].Country, actualCenters[i].Country);
                Assert.Equal(expectedCenters[i].Pincode, actualCenters[i].Pincode);
                Assert.Equal(expectedCenters[i].Phone, actualCenters[i].Phone);
                Assert.Equal(expectedCenters[i].Email, actualCenters[i].Email);
                Assert.Equal(expectedCenters[i].IsActive, actualCenters[i].IsActive);

                // Extra verification: every returned center should be inactive
                Assert.False(actualCenters[i].IsActive);
            }

            // Verify the repository method was called exactly once
            _mockRepo.Verify(r => r.GetAllNonActive(), Times.Once);
        }


        [Fact]
        public void GetById_ShouldReturnOk_WhenCenterExists()
        {
            var center = new CenterModel { Id = 5, Code = "CTR005", Name = "C5", IsActive = true };

            _mockRepo.Setup(r => r.GetById(5)).Returns(center);

            var result = _controller.GetById(5);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returned = Assert.IsType<CenterModel>(okResult.Value);

            Assert.Equal(5, returned.Id);
            _mockRepo.Verify(r => r.GetById(5), Times.Once);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenCenterDoesNotExist()
        {
            _mockRepo.Setup(r => r.GetById(It.IsAny<int>())).Returns((CenterModel?)null);

            var result = _controller.GetById(42);

            Assert.IsType<NotFoundResult>(result);
            _mockRepo.Verify(r => r.GetById(42), Times.Once);
        }

        [Fact]
        public void Create_ShouldReturnOk_WithCreatedId()
        {
            var model = new CenterRequestDto { Code = "NEW", Name = "New Center" };

            _mockRepo.Setup(r => r.Create(It.Is<CenterModel>(x =>
                x.Code == "NEW" && x.Name == "New Center"))).Returns(123);

            var result = _controller.Create(model);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var createdId = Assert.IsType<int>(okResult.Value);

            Assert.Equal(123, createdId);
            _mockRepo.Verify(r => r.Create(It.Is<CenterModel>(x =>
                x.Code == "NEW" && x.Name == "New Center")), Times.Once);
        }

        [Fact]
        public void Update_ShouldReturnOk_WithUpdateResult()
        {
            var model = new CenterRequestDto { Id = 9, Code = "CTR009", Name = "Updated Center" };

            _mockRepo.Setup(r => r.Update(It.Is<CenterModel>(x =>
                x.Id == 9 && x.Code == "CTR009" && x.Name == "Updated Center"))).Returns(1);

            var result = _controller.Update(model);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var updateResult = Assert.IsType<int>(okResult.Value);

            Assert.Equal(1, updateResult);
            _mockRepo.Verify(r => r.Update(It.Is<CenterModel>(x =>
                x.Id == 9 && x.Code == "CTR009" && x.Name == "Updated Center")), Times.Once);
        }

        [Fact]
        public void Delete_ShouldReturnOk_WithDeleteResult()
        {
            _mockRepo.Setup(r => r.Delete(7)).Returns(1);

            var result = _controller.Delete(7);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var deleteResult = Assert.IsType<int>(okResult.Value);

            Assert.Equal(1, deleteResult);
            _mockRepo.Verify(r => r.Delete(7), Times.Once);
        }

    }
}
