using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Lamanzon.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> productViewModels = _productService.GetAllProducts();
            return View(productViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                ProductViewModel productViewModel = _productService.GetProductById(id.Value);
                return View(productViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }

        public IActionResult CreateProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult CreateProductPost(ProductViewModel productViewModel)
        {
            try
            {
                    _productService.CreateProduct(productViewModel);
                    return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }

        }

        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                ProductViewModel productViewModel = _productService.GetProductForEditing(id.Value);
                return View(productViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }

        }
        [HttpPost]
        public IActionResult EditproductPost(ProductViewModel productViewModel)
        {
            try
            {
                _productService.EditProduct(productViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }

        }

        public IActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                ProductViewModel productDetailsViewModel = _productService.GetProductById(id.Value);
                return View("Delete", productDetailsViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }
        }

        [HttpPost]
        public IActionResult DeleteProductPost(ProductViewModel producViewModel)
        {
            try
            {
                _productService.DeleteProduct(producViewModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }
        }
    }
}
