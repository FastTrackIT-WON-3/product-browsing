using System;
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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService
                ?? throw new ArgumentNullException(nameof(productService));
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            List<Product> allCategories = await _productService.GetAllAsync();

            List<ProductViewModel> allViewModels = allCategories
                .Select(c => c.ToViewModel())
                .ToList();

            return View(allViewModels);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = product.ToViewModel();
            return View(viewModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: take in account category selection
                bool createSucceeded = await _productService.CreateAsync(
                    productViewModel.Category.Id,
                    productViewModel.Name);

                if (createSucceeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productViewModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = product.ToViewModel();
            return View(viewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name")] ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool updateSucceeded = await _productService.UpdateAsync(
                    id,
                    productViewModel.Category.Id,
                    productViewModel.Name);

                if (updateSucceeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = product.ToViewModel();
            return View(viewModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleteSucceeded = await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
