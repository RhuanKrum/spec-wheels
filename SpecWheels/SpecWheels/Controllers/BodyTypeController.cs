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
using SpecWheels.Models.BodyType;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class BodyTypeController : Controller
    {
        public BodyTypeController()
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
        public async Task<ActionResult> Register(BodyTypeModel model)
        {
            if (ModelState.IsValid)
            {
                BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
                BodyTypeDataAccess.Create(model);

                return RedirectToAction("List", "BodyType");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult List()
        {
            BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
            List<BodyTypeModel> BodyTypeList = BodyTypeDataAccess.List();

            return View(BodyTypeList);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult View(int id)
        {
            BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
            BodyTypeModel model = BodyTypeDataAccess.Read(id);

            return View(model);
        }

        // GET: /Account/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
            BodyTypeModel model = BodyTypeDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BodyTypeModel model)
        {
            if (ModelState.IsValid)
            {
                BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
                BodyTypeDataAccess.Update(model);
               
                return RedirectToAction("List", "BodyType");
               
               //AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /BodyType/Delete
        
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            
                BodyTypeDataAccess BodyTypeDataAccess = new BodyTypeDataAccess();
                BodyTypeDataAccess.Delete(id);

                return RedirectToAction("List", "BodyType");

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