using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumeBee.Tests.Controllers
{
    public class AcademicSessionControllerTests
    {
        private readonly Mock<IAcademicSessionRepository> _mockRepo;
        private readonly AcademicSessionController _controller;

        public AcademicSessionControllerTests()
        {
            _mockRepo = new Mock<IAcademicSessionRepository>();

            _controller = new AcademicSessionController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllActive_ShouldReturnOkResult_WithListOfSessions()
        {
            // Arrange
            var sessions = new List<AcademicSessionModel>
            {
                new AcademicSessionModel
                {
                    Id = 1,
                    Name = "2025-26",
                    StartDate = new DateTime(2025,4,1),
                    EndDate = new DateTime(2026,3,31),
                    IsActive = true
                }
            };

            _mockRepo.Setup(r => r.GetAllActive())
                     .Returns(sessions);

            // Act
            var result = _controller.GetAllActive();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsAssignableFrom<IEnumerable<AcademicSessionModel>>(okResult.Value);

            Assert.Single(data);

            Assert.Equal("2025-26", data.First().Name);
        }

        [Fact]
        public void GetAllNonActive_ShouldReturnOkResult_WithListOfSessions()
        {
            // Arrange
            var sessions = new List<AcademicSessionModel>
    {
        new AcademicSessionModel
        {
            Id = 2,
            Name = "2024-25",
            IsActive = false
        }
    };

            _mockRepo.Setup(r => r.GetAllNonActive())
                     .Returns(sessions);

            // Act
            var result = _controller.GetAllNonActive();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsAssignableFrom<IEnumerable<AcademicSessionModel>>(okResult.Value);

            Assert.Single(data);

            Assert.Equal("2024-25", data.First().Name);

            _mockRepo.Verify(r => r.GetAllNonActive(), Times.Once);
        }

        [Fact]
        public void GetById_WhenSessionExists_ShouldReturnOkResult()
        {
            // Arrange
            var session = new AcademicSessionModel
            {
                Id = 1,
                Name = "2025-26",
                IsActive = true
            };

            _mockRepo.Setup(r => r.GetById(1))
                     .Returns(session);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsType<AcademicSessionModel>(okResult.Value);

            Assert.Equal(1, data.Id);
            Assert.Equal("2025-26", data.Name);

            _mockRepo.Verify(r => r.GetById(1), Times.Once);
        }

        [Fact]
        public void GetById_WhenSessionDoesNotExist_ShouldReturnNotFound()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetById(10))
                     .Returns((AcademicSessionModel)null);

            // Act
            var result = _controller.GetById(10);

            // Assert
            Assert.IsType<NotFoundResult>(result);

            _mockRepo.Verify(r => r.GetById(10), Times.Once);
        }

        [Fact]
        public void Create_ShouldReturnOkResult()
        {
            // Arrange
            var model = new AcademicSessionRequestDto
            {
                Name = "2026-27",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddYears(1),
                IsActive = true
            };

            _mockRepo.Setup(r => r.Create(It.Is<AcademicSessionModel>(x =>
                    x.Name == "2026-27" &&
                    x.StartDate == model.StartDate &&
                    x.EndDate == model.EndDate &&
                    x.IsActive)))
                     .Returns(1);

            // Act
            var result = _controller.Create(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(1, okResult.Value);

            _mockRepo.Verify(r => r.Create(It.Is<AcademicSessionModel>(x =>
                x.Name == "2026-27" && x.StartDate == model.StartDate && x.EndDate == model.EndDate)), Times.Once);
        }

        [Fact]
        public void Update_ShouldReturnOkResult()
        {
            // Arrange
            var model = new AcademicSessionRequestDto
            {
                Id = 1,
                Name = "2025-26 Updated"
            };

            _mockRepo.Setup(r => r.Update(It.Is<AcademicSessionModel>(x =>
                    x.Id == 1 && x.Name == "2025-26 Updated")))
                     .Returns(1);

            // Act
            var result = _controller.Update(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(1, okResult.Value);

            _mockRepo.Verify(r => r.Update(It.Is<AcademicSessionModel>(x =>
                x.Id == 1 && x.Name == "2025-26 Updated")), Times.Once);
        }

        [Fact]
        public void Delete_ShouldReturnOkResult()
        {
            // Arrange
            _mockRepo.Setup(r => r.Delete(1))
                     .Returns(1);

            // Act
            var result = _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(1, okResult.Value);

            _mockRepo.Verify(r => r.Delete(1), Times.Once);
        }
    }
}
