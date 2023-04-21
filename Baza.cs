using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace WinFormsApp1
{
    public class temperatura
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string avg { get; set; }
        public override string ToString()
        {
        }
    }
    public class heat : DbContext
    {
        public virtual DbSet<temperatura> tablica { get; set; }
         
        public heat() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=baza_danych.db");
    }
    }
