using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IDataBaseContext _context;

        public OrdersController(IDataBaseContext context) 
            => (_context) = (context);

        public async Task<IActionResult> Add() 
        {
            return Ok();
        }
    }
}