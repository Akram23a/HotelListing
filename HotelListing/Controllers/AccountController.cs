﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Data;
using HotelListing.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public readonly ILogger<AccountController> _logger;
        public readonly IMapper _mapper;
        public readonly UserManager<APIUser> _userManager;
        //public readonly SignInManager<APIUser> _signInManager;

        public AccountController(
          ILogger<AccountController> logger,
          IMapper mapper,
          UserManager<APIUser> userManager
          //  ,
          //SignInManager<APIUser> signInManager
          )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            //_signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<APIUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Internal server error in {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)} {ex.ToString()}", statusCode: 500);
            }

        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        //{
        //    _logger.LogInformation($"Login Attempt for {loginDTO.Email}");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync((string)loginDTO.Email, (string)loginDTO.Password , false, false);
        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(loginDTO);
        //        }
        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Internal server error in {nameof(Register)}");
        //        return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
        //    }

        //}

    }
}
