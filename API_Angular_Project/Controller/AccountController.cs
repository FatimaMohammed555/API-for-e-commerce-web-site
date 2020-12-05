using API_Angular_Project.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_Angular_Project.Controller
{
 
    public class AccountController : ApiController
    {
        //Account/postUser
        public async Task<IHttpActionResult> postUser(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //Usermanager
            ApplicationDbContext dbcontext = new ApplicationDbContext();
            UserStore<IdentityUser> userstore = new UserStore<IdentityUser>(dbcontext);
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userstore);
            //Map from UserModel to IdentityUser
            IdentityUser user = new IdentityUser();
            user.UserName = customer.Name;
            user.PasswordHash = customer.Password;
            

            //create 
            IdentityResult result = await manager.CreateAsync(user, customer.Password);
            //ok
            if (result.Succeeded)
                return Created("", "User Added");
            return BadRequest(result.Errors.ToList()[0]);


        

        
        }
    }
}
