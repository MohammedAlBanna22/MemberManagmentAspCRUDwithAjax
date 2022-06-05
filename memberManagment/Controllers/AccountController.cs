using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using memberManagment.Data;
using memberManagment.Models;
using memberManagment.Repository;
using Microsoft.AspNetCore.Authorization;

namespace memberManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository account , IWebHostEnvironment webHostEnvironment, ApplicationDbContext context, IMapper mapper)
        {
            _account = account;
            _webHostEnvironment = webHostEnvironment;
            this.context = context;
            _mapper = mapper;
        }
   
        public ActionResult Addmember(bool isSuccess=false)
        {
            var countrydata = context.Countries.Where(x => x.name == "palestine" || x.name == "cario").FirstOrDefault();

            if (countrydata==null)
            {
                context.Countries.AddRange(_account.countrieslist());
                context.SaveChanges();
            }

            return View();
        }
        [HttpPost]
        public async Task <ActionResult >Addmember(AddMemeberModel memeberModel)
        {
                if (ModelState.IsValid)
                {
                    if (memeberModel.image != null)
                    {
                        string folder = "pic/profile";
                        folder += Guid.NewGuid().ToString() + "_" + memeberModel.image.FileName;
                        memeberModel.imageurl = "/" + folder;
                        string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        await memeberModel.image.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                    }
                    if (memeberModel.id == 0)
                    {
                         var data = await _account.AddMemeber(memeberModel);
                        return Json(new { IsValid = true, Test = "The Model Add Succssfully", data = data });
                    }
                    else
                    {
                    var data= await _account.update(memeberModel);
                    return Json(new { IsValid = true, Test = "The Model Update Succssfully", data = data });
                    }  
                }

                return Json(new { IsValid = false, Errors = ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage)).SelectMany(x => x) });

        }
        [Authorize]
         public async  Task<ActionResult> GetUser()
        {
            return View(await context.Accounts.ToListAsync());
        }
        public ActionResult viewuser( )
        {
            var countrydata = context.Countries.Where(x => x.name == "palestine" || x.name == "cario").FirstOrDefault();

            if (countrydata == null)
            {
                context.Countries.AddRange(_account.countrieslist());
                context.SaveChanges();
            }

            var obj = context.Countries.ToList();
            SelectList countries = new SelectList(obj, "id", "name");
            ViewBag.countries = countries;


            return PartialView("Addmember");

        }

        public ActionResult Edit(int id)
        {
            var user =  _account.find(id);
            //var userviewmodel = _account.ViewMember(user);
            var obj = context.Countries.ToList();
            SelectList countries = new SelectList(obj, "id", "name");
            ViewBag.countries = countries;
            return  PartialView("update",user );

        }
      

        public async Task <ActionResult> del (int id)
        {
            var user =await _account.delete(id);
            return Json("delete succesful");
           
        }


      public  ActionResult cities(int id)
        {
            var obj =  _account.Cities(id);
            return  Json(new SelectList(_account.Cities(id), "id", "name"));
        }
      

    }
}
