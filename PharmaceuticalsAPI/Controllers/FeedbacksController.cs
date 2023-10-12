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
    public class FeedbacksController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public FeedbacksController(PharmaceuticalDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string address, string email, string phone, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * FROM feedbacks WHERE 1=1";
            if (name != null)
            {
                sql += " AND FullName LIKE N'%" + name + "%'";
            }
            if (address != null)
            {
                sql += " AND address LIKE '%" + address + "%'";
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

            return db.Feedbacks.FromSqlRaw(sql).AsEnumerable();
        }

        [HttpGet("{Id}")]
        public Feedback GetById(int Id)
        {
            return db.Feedbacks.Find(Id);
        }

        [HttpPost]
        public IActionResult Post(Feedback user)
        {
            if (ModelState.IsValid)
            {
                //user.Created_date = DateTime.Now;
                db.Feedbacks.Add(user);
                db.SaveChanges();
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Feedback user)
        {
            var find = db.Feedbacks.Where(e => e.FeedbackId == Id);
            if (find != null)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(find);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var find = db.Feedbacks.Find(Id);
            if (find != null)
            {
                db.Feedbacks.Remove(find);
                db.SaveChanges();
                return Ok(find);

            }
            else
            {
                return NotFound();
            }

        }

    }
}
