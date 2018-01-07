using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TheSoulOfBreadBakery.Controllers;
using TheSoulOfBreadBakery.Models;
using TheSoulOfBreadBakery.ViewModels;
using TheSoulOfBreadBakeryTestProject.Model;
using Xunit;

namespace TheSoulOfBreadBakeryTestProject
{
    public class BreadManagementControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_ContainsAllBreads()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var mockBreadRepository = RepositoryMocks.GetBreadRepository();

            var breadManagementController = new BreadManagementController(mockBreadRepository.Object, mockCategoryRepository.Object);

            //act
            var result = breadManagementController.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var breads = Assert.IsAssignableFrom<IEnumerable<Bread>>(viewResult.ViewData.Model);
            Assert.Equal(12, breads.Count());
        }

        [Fact]
        public void AddBread_Redirects_ValidBreadViewModel()
        {
            //arrange
            var breadEditViewModel = new BreadEditViewModel();
            var mockBreadRepository = RepositoryMocks.GetBreadRepository();
            var bread = mockBreadRepository.Object.GetBreadById(1);
            breadEditViewModel.Bread = bread;
            breadEditViewModel.CategoryId = 1;

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            var breadManagementController = new BreadManagementController(mockBreadRepository.Object, mockCategoryRepository.Object);

            //act
            var result = breadManagementController.AddBread(breadEditViewModel);

            //assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AddBread_ReturnsViewResultWithViewModel_InvalidBreadViewModel()
        {
            //arrange
            var breadEditViewModel = new BreadEditViewModel();
            var mockBreadRepository = RepositoryMocks.GetBreadRepository();
            var bread = mockBreadRepository.Object.GetBreadById(1);
            bread.IsBreadOfTheWeek = true;
            bread.InStock = false;
            breadEditViewModel.Bread = bread;
            breadEditViewModel.CategoryId = 1;

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            var breadManagementController = new BreadManagementController(mockBreadRepository.Object, mockCategoryRepository.Object);

            //act
            var result = breadManagementController.AddBread(breadEditViewModel);

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName));
        }
    }
}
