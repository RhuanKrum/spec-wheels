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
using SpecWheels.Models.Color;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class ColorController : Controller
    {
        //
        // GET: /Color/Register
        [Authorize]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Color/Register
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                ColorDataAccess ColorDataAccess = new ColorDataAccess();
                ColorDataAccess.Create(model);

                return RedirectToAction("List", "Color");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Color/List
        [Authorize]
        public new ActionResult List()
        {
            ColorDataAccess ColorDataAccess = new ColorDataAccess();
            List<ColorModel> ColorList = ColorDataAccess.List();

            return View(ColorList);
        }

        // GET: /Color/View
        [Authorize]
        public new ActionResult View(int id)
        {
            ColorDataAccess ColorDataAccess = new ColorDataAccess();
            ColorModel model = ColorDataAccess.Read(id);

            return View(model);
        }

        // GET: /Color/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            ColorDataAccess ColorDataAccess = new ColorDataAccess();
            ColorModel model = ColorDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Color/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                ColorDataAccess ColorDataAccess = new ColorDataAccess();
                ColorDataAccess.Update(model);
               
                return RedirectToAction("List", "Color");
               
               //AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Color/Delete
        
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            
                ColorDataAccess ColorDataAccess = new ColorDataAccess();
                ColorDataAccess.Delete(id);

                return RedirectToAction("List", "Color");

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