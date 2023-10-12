using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ManagersController : Controller
    {
        private readonly PharmaceuticalDbContext db;

        public ManagersController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string email)
        {
            string sql = "SELECT * FROM managers WHERE 1=1";
            if (name != null)
            {
                sql += " AND FullName LIKE '%" + name + "%'";
            }
            if (email != null)
            {
                sql += " AND Email LIKE '%" + email + "%'";
            }

            return db.Managers.FromSqlRaw(sql).AsEnumerable();
        }


        [HttpGet("{id}")]
        public Manager GetById(Guid id)
        {
            return db.Managers.SingleOrDefault(m => m.AdminId.Equals(id));
        }

        [HttpGet("Username")]
        public Manager GetByUsername(string username)
        {
            return db.Managers.SingleOrDefault(m => m.Username.Equals(username));
        }

        [HttpPost]
        public IActionResult Post(Manager ma)
        {
            ma.AdminId = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                db.Managers.Add(ma);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return Ok(e.InnerException.Message);
                }

                return Ok(ma);
            }
            return NotFound("Add new failed!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(string id, Manager ma)
        {
            var find = db.Managers.Where(m => m.AdminId.Equals(id));
            if (find != null)
            {
                db.Entry(ma).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return Ok(e.InnerException.Message);
                }

                return Ok(ma);
            }

            return NotFound("Update failed!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var find = db.Managers.Find(Guid.Parse(id));
            if (find != null)
            {
                db.Managers.Remove(find);
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
