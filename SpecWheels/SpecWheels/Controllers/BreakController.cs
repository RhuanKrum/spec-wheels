using System;
using System.Collections.Generic;
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

                return RedirectToAction("List", "Break");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult List()
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            List<BreakModel> breakList = breakDataAccess.List();

            return View(breakList);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult View(int id)
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            BreakModel model = breakDataAccess.Read(id);

            return View(model);
        }

        // GET: /Account/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            BreakModel model = breakDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BreakModel model)
        {
            if (ModelState.IsValid)
            {
                BreakDataAccess breakDataAccess = new BreakDataAccess();
                breakDataAccess.Update(model);
               
                return RedirectToAction("List", "Break");
               
               //AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Break/Delete
        
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            
                BreakDataAccess breakDataAccess = new BreakDataAccess();
                breakDataAccess.Delete(id);

                return RedirectToAction("List", "Break");

                //AddErrors(result);

            

            // If we got this far, something failed, redisplay form
            
        }


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