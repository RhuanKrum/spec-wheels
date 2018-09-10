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
using SpecWheels.Models.Suspension;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class SuspensionController : Controller
    {
        public SuspensionController()
        {
        }
        
        
        //
        // GET: /Suspension/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Suspension/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(SuspensionModel model)
        {
            if (ModelState.IsValid)
            {
                SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
                SuspensionDataAccess.Create(model);

                return RedirectToAction("List", "Suspension");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Suspension/List
        [Authorize]
        public new ActionResult List()
        {
            SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
            List<SuspensionModel> SuspensionList = SuspensionDataAccess.List();

            return View(SuspensionList);
        }

        // GET: /Suspension/View
        [Authorize]
        public new ActionResult View(int id)
        {
            SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
            SuspensionModel model = SuspensionDataAccess.Read(id);

            return View(model);
        }

        // GET: /Suspension/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
            SuspensionModel model = SuspensionDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Suspension/Edit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SuspensionModel model)
        {
            if (ModelState.IsValid)
            {
                SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
                SuspensionDataAccess.Update(model);
               
                return RedirectToAction("List", "Suspension");
               
               //AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Suspension/Delete
        
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            
                SuspensionDataAccess SuspensionDataAccess = new SuspensionDataAccess();
                SuspensionDataAccess.Delete(id);

                return RedirectToAction("List", "Suspension");

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