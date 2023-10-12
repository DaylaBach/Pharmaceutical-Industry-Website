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
    public class ManufacturersController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public ManufacturersController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string address, string email, string phone, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * FROM manufacturers WHERE 1=1";
            if (name != null)
            {
                sql += " AND ManufacturerName LIKE '%" + name + "%'";
            }
            if (address != null)
            {
                sql += " AND adress LIKE '%" + address + "%'";
            }
            if (email != null)
            {
                sql += " AND email LIKE '%" + email + "%'";
            }
            if (phone != null)
            {
                sql += " AND phone LIKE '%" + phone + "%'";
            }
            if (startDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate >= '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (endDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return db.Manufacturers.FromSqlRaw(sql).Include(m => m.Products).AsEnumerable();
        }


        [HttpGet("{id}")]
        public Manufacturer GetById(int id)
        {
            return db.Manufacturers.Include(m => m.Products).SingleOrDefault(m => m.ManufacturerId.Equals(id));
        }


        [HttpPost]
        public IActionResult Post(Manufacturer man)
        {
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(man);
                db.SaveChanges();

                return Ok(man);
            }

            return NotFound("Add new failed!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Manufacturer man)
        {
            var find = db.Manufacturers.Where(m => m.ManufacturerId == id);
            if (find != null)
            {
                db.Entry(man).State = EntityState.Modified;
                db.SaveChanges();

                return Ok(man);
            }

            return NotFound("Update failed!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = db.Manufacturers.Find(id);
            if (find != null)
            {
                db.Manufacturers.Remove(find);
                db.SaveChanges();

                return Ok("Delete success!");
            }

            return NotFound("Delete failed!");
        }
    }
}
