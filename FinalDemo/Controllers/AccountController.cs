using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalDemo.Models;
using FinalDemo.Services;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly SessionService _sessionService;

        public AccountController(AccountService accountService, SessionService sessionService)
        {
            _accountService = accountService;
            _sessionService = sessionService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult PostAccount(AccountRequest body)
        {
            try
            {
                _accountService.Create(body.Username, body.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AccountRequest body)
        {
            try
            {
                var account = _accountService.FindByUsernameAndPassword(body.Username, body.Password);
                if (account == null)
                {
                    throw new Exception("Login is invalid");
                }

                var session = _sessionService.Create(account.Id);

                return Ok(session);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}