using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        public readonly SellerService _sellerService;
        public readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {

            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); 
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var  viewModel = new SellerFormViewModel { Departments = departments};
            return View(viewModel); // Passando o obj viewModel para a view
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //evitar que minha aplicação sofra ataques CSRF
        public IActionResult Create(Seller seller) // Recebemdo um obj da requisicao, a instacia sera feita automaticamente pelo entityframework
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}