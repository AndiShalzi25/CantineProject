using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Domain.Models;
using SuperMarket.Domain.Services;

namespace SuperMarket.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IEnumerable<Category>> GetAllAsync() //return an enumeration of categories and execute the method asynchronously
        {
            var categories = await _categoryService.ListAsync();
            return categories;
        }
    }
}
