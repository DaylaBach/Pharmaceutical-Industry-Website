using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PharmaceuticalsAPI.Data;
using PharmaceuticalsAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmaceuticalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public CategoriesController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, int? status, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * FROM categories WHERE 1=1";
            if (name != null)
            {
                sql += " AND CategoryName LIKE '%" + name + "%'";
            }
            if (status != null)
            {
                sql += " AND Status = " + status;
            }
            if (startDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate >= '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (endDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return db.Categories.FromSqlRaw(sql).Include(c => c.Products).AsEnumerable();
        }

        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return db.Categories.Include(c => c.Products).SingleOrDefault(c => c.CategoryId.Equals(id));
        }

        [HttpPost]
        public IActionResult Post(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return Ok(e.InnerException.Message);
                }
                
                return Ok(cat);
            }
            return NotFound("Add new failed!");
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category cat)
        {
            var find = db.Categories.Where(c => c.CategoryId == id);
            if(find != null)
            {
                db.Entry(cat).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return Ok(e.InnerException.Message);
                }

                return Ok(cat);
            }

            return NotFound("Update failed!");
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = db.Categories.Find(id);
            if(find != null)
            {
                db.Categories.Remove(find);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return Ok(e.InnerException.Message);
                }

                return Ok("Delete success!");
            }

            return NotFound("Delete failed!");
        }
    }
}
