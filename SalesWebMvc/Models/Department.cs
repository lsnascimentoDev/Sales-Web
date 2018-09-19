﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, int nome)
        {
            Id = id;
            Nome = nome;
        }


        public void AddSeller(Seller seller)
        {

            Sellers.Add(seller);
        }


        public double TotalSales(DateTime initial, DateTime final)
        {

            return Sellers.Sum(sellers => sellers.TotalSales(initial, final));

        }
    }

    
    
}
