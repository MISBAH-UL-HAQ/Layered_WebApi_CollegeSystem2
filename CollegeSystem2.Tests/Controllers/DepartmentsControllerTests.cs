using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;
using CollegeSystem2.Controllers;

namespace CollegeSystem2.Tests.Controllers
{
    public class DepartmentsControllerTests
    {
        private readonly Mock<IDepartmentService> _mockService;
        private readonly DepartmentsController _controller;

        public DepartmentsControllerTests()
        {
            _mockService = new Mock<IDepartmentService>();
            _controller = new DepartmentsController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithListOfDepartments()
        {
            // Arrange
            var departmentList = new List<DepartmentDTO>
        {
            new DepartmentDTO { Id = 1, Name = "Computer Science" },
            new DepartmentDTO { Id = 2, Name = "Mathematics" }
        };

            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(departmentList);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<DepartmentDTO>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<DepartmentDTO>>(okResult.Value);

            Assert.Equal(2, returnValue.Count);
        }

    }
}
