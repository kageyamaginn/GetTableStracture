using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OraCore.Models;

namespace OraCore.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class OraObjectController : ControllerBase
    {
        readonly OraDbContext _context;

        public OraObjectController(OraDbContext context)
        {
            _context = context;
            Add();

        }

        private void Add()
        {
            if (_context.Objects.Count() == 0)
            {
                _context.Objects.Add(new OracleObject { Id = 2, Owner = "PLM", ObjectName = "REPORT_JOB" });
                _context.SaveChanges();
            }
        }
        [ActionName("GetOra")]
        [HttpGet("{id}")]
        public ActionResult<OracleObject> Get(int id)
        {
            var items = _context.Objects.Find(id);
            if (items == null)
            {
                return NotFound();
            }

            return items;
        }


        [HttpPost]
        public ActionResult<OracleObject> PostOraObject(OracleObject obj)
            {
            _context.Objects.Add(obj);
            _context.SaveChanges();
            String actionName = nameof(Get);
            return CreatedAtAction("GetOra", new { id = obj.Id }, obj);
}

    }
}