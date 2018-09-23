using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        public readonly SellerService _sellerService;

        public SellersController(SellerService sellerService) {

            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); 
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
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