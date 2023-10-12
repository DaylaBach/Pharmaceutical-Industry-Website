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
    public class CandidatesController : ControllerBase
    {
        private readonly PharmaceuticalDbContext db;

        public CandidatesController(PharmaceuticalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable GetAll(string name, string phone, string email, string education, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * FROM candidates WHERE 1=1";

            if (name != null)
            {
                sql += " AND FullName LIKE '%" + name + "%'";
            }
            if (phone != null)
            {
                sql += " AND Phone LIKE '%" + phone + "%'";
            }
            if (email != null)
            {
                sql += " AND Email LIKE '%" + email + "%'";
            }
            if (education != null && education != "")
            {
                sql += " AND Education LIKE '%" + education + "%'";
            }
            if (startDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate >= '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (endDate.CompareTo(new DateTime()) != 0)
            {
                sql += " AND CreatedDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return db.Candidates.FromSqlRaw(sql).AsEnumerable();
        }


        [HttpGet("{id}")]
        public Candidate GetById(int id)
        {
            return db.Candidates.SingleOrDefault(c => c.CandidateId.Equals(id));
        }

        [HttpGet("Login")]
        public Candidate Login(string email, string password)
        {
            return db.Candidates.SingleOrDefault(c => c.Email.Equals(email) && c.Password.Equals(password));
        }


        [HttpPost]
        public IActionResult Post(Candidate can)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(can);
                db.SaveChanges();

                return Ok(can);
            }

            return NotFound("Add new failed!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidate can)
        {
            var find = db.Candidates.Where(c => c.CandidateId == id);
            if (find != null)
            {
                db.Entry(can).State = EntityState.Modified;
                db.SaveChanges();

                return Ok(can);
            }

            return NotFound("Update failed!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = db.Candidates.Find(id);
            if (find != null)
            {
                db.Candidates.Remove(find);
                db.SaveChanges();

                return Ok("Delete success!");
            }

            return NotFound("Delete failed!");
        }
    }
}
