using AutoMapper;
using Books.DTO;
using Books.IRepository;
using Books.Migrations;
using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("/Register")]

        public async Task<IActionResult> Register([FromBody] UserRegisterDTO obj)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var useridentity = _mapper.Map<UserRegisterDTO, User>(obj);
            useridentity.UserName = obj.Email;
            var result = await _unitOfWork._userManager.CreateAsync(useridentity, obj.Password);
            if (result.Succeeded) return Ok("Registration Finished Succesfully");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Ok(ModelState);

        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork._signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
                if (result.Succeeded) return Ok();
                else
                {
                    ModelState.AddModelError("", "Invalid Input fields");
                }

            }
            return BadRequest(ModelState);


        }

        [HttpPost]
        [Route("/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _unitOfWork._signInManager.SignOutAsync();
            return Ok("You are not authroised anymore");
        }

        [HttpPost]
        [Route("/Role")]
        public async Task<IActionResult> CreateRole(RoleDTO obj)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = obj.RoleName };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) return Ok("Role Created");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }


        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var query = _roleManager.Roles;
            return Ok(query);
        }

        [HttpPost]
        [Route("/Addtorole")]
        public async Task<IActionResult> AddToRole(string email, string rolename)
        {
            var role = await _roleManager.FindByNameAsync(rolename);
            var user = await _unitOfWork._userManager.FindByNameAsync(email);

            if ( user is not null && role is not null)
            {
                await _unitOfWork._userManager.AddToRoleAsync(user, role.Name);
                return Ok("Added");
            }
            return BadRequest("Such role or user does not exist");
        }


    }

        

}
