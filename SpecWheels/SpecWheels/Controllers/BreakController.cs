using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SpecWheels.Models.Break;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class BreakController : Controller
    {
        public BreakController()
        {
        }
        
        
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(BreakModel model)
        {
            if (ModelState.IsValid)
            {
                BreakDataAccess breakDataAccess = new BreakDataAccess();
                breakDataAccess.Create(model);

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        

        //
        // GET: /Account/View
        //[Authorize]
        //public new ActionResult View()
        //{
        //    UserModel account = UserManager.FindById(User.Identity.GetUserId());
        //    return View(account);
        //}
        //
        // GET: /Account/Edit
        [AllowAnonymous]
        public ActionResult Edit()
        {
            return View();
        }

        //
        // POST: /Account/Edit
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var currentUser = UserManager.FindByEmail(model.Email);

        //        currentUser.FirstName = model.FirstName;
        //        currentUser.LastName = model.LastName;
        //        currentUser.Nickname = model.Nickname;
        //        currentUser.Password = model.Password;

        //        var result = await UserManager.UpdateAsync(currentUser);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("View", "User");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

      
        //
        //// POST: /Account/Delete
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Inactivate(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var currentUser = UserManager.FindByEmail(model.Email);

        //        currentUser.FirstName = model.FirstName;
        //        currentUser.LastName = model.LastName;
        //        currentUser.Nickname = model.Nickname;
        //        currentUser.Password = model.Password;
        //        currentUser.InactiveDate = DateTime.Now;

        //        var result = await UserManager.UpdateAsync(currentUser);
        //        if (result.Succeeded)
        //        {
        //            // If the inactivated account belongs to the user, log him out
        //            if (User.Identity.GetUserId().Equals(currentUser.Id))
        //            {
        //                Logout();
        //            }
        //            return RedirectToAction("View", "User");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //        }
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}




        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private ActionResult RedirectToLocal()
        {
            return RedirectToAction("Index", "Home");
        }

        
    }
}