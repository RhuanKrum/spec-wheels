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
using SpecWheels.Models.Wheel;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class WheelController : Controller
    {
        public WheelController()
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
        public async Task<ActionResult> Register(WheelModel model)
        {
            if (ModelState.IsValid)
            {
                WheelDataAccess WheelDataAccess = new WheelDataAccess();
                WheelDataAccess.Create(model);

                return RedirectToAction("List", "Wheel");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult List()
        {
            WheelDataAccess WheelDataAccess = new WheelDataAccess();
            List<WheelModel> WheelList = WheelDataAccess.List();

            return View(WheelList);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult View(int id)
        {
            WheelDataAccess WheelDataAccess = new WheelDataAccess();
            WheelModel model = WheelDataAccess.Read(id);

            return View(model);
        }

        // GET: /Account/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            WheelDataAccess WheelDataAccess = new WheelDataAccess();
            WheelModel model = WheelDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(WheelModel model)
        {
            if (ModelState.IsValid)
            {
                WheelDataAccess WheelDataAccess = new WheelDataAccess();
                WheelDataAccess.Update(model);
               
                return RedirectToAction("List", "Wheel");
               
               //AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Wheel/Delete
        
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            
                WheelDataAccess WheelDataAccess = new WheelDataAccess();
                WheelDataAccess.Delete(id);

                return RedirectToAction("List", "Wheel");

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