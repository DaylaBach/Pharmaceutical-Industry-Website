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
using Attribute = PharmaceuticalsAPI.Models.Attribute;

namespace PharmaceuticalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public AttributesController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string product)
        {
            string sql = "SELECT * FROM attributes WHERE 1=1";

            if(name != null)
            {
                sql += " AND AttributeName LIKE '%" + name + "%'";
            }
            if(product != null && product != "")
            {
                sql += " AND ProductId = '" + product + "'";
            }

            return db.Attributes.FromSqlRaw(sql).Include(a => a.Product).AsEnumerable();
        }


        [HttpGet("{id}")]
        public Attribute GetById(int id)
        {
            return db.Attributes.Include(a => a.Product).SingleOrDefault(a => a.AttributeId.Equals(id));
        }


        [HttpPost]
        public IActionResult Post(Attribute att)
        {
            if (ModelState.IsValid)
            {
                db.Attributes.Add(att);
                db.SaveChanges();

                return Ok(att);
            }

            return NotFound("Add new failed!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Attribute att)
        {
            var find = db.Attributes.Where(a => a.AttributeId == id);
            if (find != null)
            {
                db.Entry(att).State = EntityState.Modified;
                db.SaveChanges();

                return Ok(att);
            }

            return NotFound("Update failed!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = db.Attributes.Find(id);
            if (find != null)
            {
                db.Attributes.Remove(find);
                db.SaveChanges();

                return Ok("Delete success!");
            }

            return NotFound("Delete failed!");
        }
    }
}
