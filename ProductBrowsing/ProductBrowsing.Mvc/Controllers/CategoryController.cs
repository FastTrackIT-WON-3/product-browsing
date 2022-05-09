using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductBrowsing.Core.Abstractions.Services;
using ProductBrowsing.Core.Models;
using ProductBrowsing.Mvc.Extensions;
using ProductBrowsing.Mvc.Models;

namespace ProductBrowsing.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            List<Category> allCategories = await _categoryService.GetAllAsync();

            List<CategoryViewModel> allViewModels = allCategories
                .Select(c => c.ToViewModel())
                .ToList();

            return View(allViewModels);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetByIdAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            CategoryViewModel viewModel = category.ToViewModel();
            return View(viewModel);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category createdCategory = await _categoryService.CreateAsync(categoryViewModel.Name);
                if (createdCategory is not null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(categoryViewModel);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _categoryService.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            CategoryViewModel viewModel = category.ToViewModel();
            return View(viewModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool updateSucceeded = await _categoryService.UpdateAsync(id, categoryViewModel.Name);
                if (updateSucceeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(categoryViewModel);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _categoryService.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            CategoryViewModel viewModel = category.ToViewModel();
            return View(viewModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleteSucceeded = await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
