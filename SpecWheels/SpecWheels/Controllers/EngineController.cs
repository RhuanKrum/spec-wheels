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
using SpecWheels.Models.Engine;
using SpecWheels.Models.User;

namespace SpecWheels.Controllers
{
    [Authorize]
    public class EngineController : Controller
    {
        public EngineController()
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
        public async Task<ActionResult> Register(EngineModel model)
        {
            if (ModelState.IsValid)
            {
                EngineDataAccess engineDataAccess = new EngineDataAccess();
                engineDataAccess.Create(model);

                return RedirectToAction("List", "Engine");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult List()
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            List<EngineModel> engineList = engineDataAccess.List();

            return View(engineList);
        }

        // GET: /Account/View
        [Authorize]
        public new ActionResult View(int id)
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            EngineModel model = engineDataAccess.Read(id);

            return View(model);
        }

        // GET: /Account/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            EngineModel model = engineDataAccess.Read(id);
            return View(model);
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EngineModel model)
        {
            if (ModelState.IsValid)
            {
                EngineDataAccess engineDataAccess = new EngineDataAccess();
                engineDataAccess.Update(model);
               
                return RedirectToAction("List", "Engine");
               
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

            EngineDataAccess engineDataAccess = new EngineDataAccess();
            engineDataAccess.Delete(id);

                return RedirectToAction("List", "Engine");

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