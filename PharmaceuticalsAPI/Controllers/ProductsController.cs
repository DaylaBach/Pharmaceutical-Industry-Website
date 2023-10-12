using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalsAPI.Data;
using PharmaceuticalsAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public ProductsController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string modelNumber, int? category, int? manufacturer, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * FROM products WHERE 1=1";
            if (name != null)
            {
                sql += " AND ProductName LIKE '%" + name + "%'";
            }
            if (modelNumber != null)
            {
                sql += " AND ModelNumber LIKE '%" + modelNumber + "%'";
            }
            if (category != null && category > 0)
            {
                sql += " AND CategoryId = " + category;
            }
            if (manufacturer != null && manufacturer > 0)
            {
                sql += " AND ManufacturerId = " + manufacturer;
            }
            if (startDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate >= '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (endDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            return db.Products.FromSqlRaw(sql).Include(c => c.Category).Include(m => m.Manufacturer)
                .Include(a => a.Attributes).AsEnumerable();
        }


        [HttpGet("{id}")]
        public Product GetById(string id)
        {
            return db.Products.Include(c => c.Category).Include(m => m.Manufacturer)
                .Include(a => a.Attributes).SingleOrDefault(p => p.ProductId.Equals(id));
        }


        [HttpPost]
        public IActionResult Post(Product pro)
        {
            pro.ProductId = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.Products.Add(pro);
                db.SaveChanges();

                return Ok(pro);
            }

            return NotFound("Add new failed!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(string id, Product pro)
        {
            var find = db.Products.Where(p => p.ProductId.Equals(id));
            if (find != null)
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();

                return Ok(pro);
            }

            return NotFound("Update failed!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var find = db.Products.Find(id);
            if (find != null)
            {
                db.Products.Remove(find);
                db.SaveChanges();

                return Ok("Delete success!");
            }

            return NotFound("Delete failed!");
        }
    }
}
