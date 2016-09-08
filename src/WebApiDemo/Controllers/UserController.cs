using System;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Repositories;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepo)
        {
            userRepository = userRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = userRepository.GetAll();
            return new ObjectResult(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = userRepository.GetById(id);
            return new ObjectResult(user);
        }

        #region 其他方法
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // TODO：新增操作
            user.Id = new Random().Next(1, 10);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // TODO: 更新操作
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: 删除操作

        }
        #endregion
    }
}