using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;

namespace OnlineExamCoreApi.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminPanelApiController : ControllerBase
    {
        private readonly IDataAccessRepository<AdminPanel> _dataRepository;
        public AdminPanelApiController(IDataAccessRepository<AdminPanel> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetAdminPanel")]
        public IActionResult GetAdminPanel()
        {
            IEnumerable<AdminPanel> adminPanels = _dataRepository.GetAll();
            return Ok(adminPanels);
        }


        [HttpGet(Name = "GetAdmin")]
        [Route("GetAdminById/{adminId}")]
        public IActionResult GetAdminById(long adminId)
        {
            AdminPanel adminPanel = _dataRepository.Get(adminId);
            if (adminPanel == null)
            {
                return NotFound("Admin record not found !!!");
            }
            return Ok(adminPanel);
        }


        [HttpPost]
        [Route("InsertAdmin")]
        public IActionResult PostAdmin([FromBody] AdminPanel adminPanel)
        {
            if (adminPanel == null)
            {
                return BadRequest("Admin is null !!!");
            }
            _dataRepository.Add(adminPanel);
            return CreatedAtRoute("GetAdmin", new { Id = adminPanel.AdminPanelId }, adminPanel);
        }

        [HttpPut]
        [Route("UpdateAdmin/{adminId}")]
        public IActionResult PutAdmin(long adminId, [FromBody] AdminPanel adminPanel)
        {
            if (adminPanel == null)
            {
                return BadRequest("Admin is null !!!");
            }
            AdminPanel adminToUpdate = _dataRepository.Get(adminId);
            if (adminToUpdate == null)
            {
                return NotFound("Admin record not found !!!");
            }
            _dataRepository.Update(adminToUpdate, adminPanel);
            return CreatedAtRoute("GetAdmin", new { Id = adminPanel.AdminPanelId }, adminPanel);
        }

        [HttpDelete]
        [Route("DeleteAdmin/{adminId}")]
        public IActionResult DeleteAdmin(long adminId)
        {
            AdminPanel adminPanel = _dataRepository.Get(adminId);
            if (adminPanel == null)
            {
                return NotFound("Admin record not found !!!");
            }
            _dataRepository.Delete(adminPanel);
            return GetAdminPanel();
        }
    }
}