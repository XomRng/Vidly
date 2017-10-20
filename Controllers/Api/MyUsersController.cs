using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MyUsersController : ApiController
    {
        private ApplicationDbContext _context;

        public MyUsersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/MyUsers
        public IEnumerable<MyUserDto> GetMyUsers()
        {
            return _context.MyUsers.ToList().Select(Mapper.Map<MyUser,MyUserDto>);
        }

        //Get /api/MyUsers/1

        public IHttpActionResult GetMyUser(int id)
        {
            var myUser = _context.MyUsers.SingleOrDefault(u => u.Id == id);
            if (myUser == null)
                return NotFound();
            
            return Ok(Mapper.Map<MyUser, MyUserDto>(myUser));
        }

        //Post /api/MyUsers
        [HttpPost]
        public IHttpActionResult CreateMyUser(MyUserDto myUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var myUser = Mapper.Map<MyUserDto, MyUser>(myUserDto);

            _context.MyUsers.Add(myUser);
            _context.SaveChanges();

            myUserDto.Id = myUser.Id;

            return Created(new Uri(Request.RequestUri + "/" + myUser.Id), myUserDto);

        }

        //Put /api/MyUsers/1
        [HttpPut]
        public IHttpActionResult UpdateMyUser(int id, MyUserDto myUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var myUserInDb = _context.MyUsers.SingleOrDefault(u => u.Id == id);

            if (myUserInDb == null)
                return NotFound();

            Mapper.Map(myUserDto, myUserInDb);
            _context.SaveChanges();

            return Ok();
        }

        //Delete /api/MyUsers/1
        [HttpDelete]
        public IHttpActionResult DeleteMyUser(int id)
        {
            var myUserInDb = _context.MyUsers.SingleOrDefault(u => u.Id == id);

            if (myUserInDb == null)
                return NotFound();

            _context.MyUsers.Remove(myUserInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
