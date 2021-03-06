﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List <SalesRecord>();

        public Seller()
        {


        }

        public Seller(int id, string nome, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Nome = nome;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddSales(SalesRecord sr)
        {

            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {

            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final )
        {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}
