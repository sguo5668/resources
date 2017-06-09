using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;

namespace ContosoUniversity.Controllers
{
    public class TestController : Controller
    {
        //     public IActionResult Index()
        //     {
        //         RegisterViewModel vm = new RegisterViewModel();

        //         vm.Coal = new Coal
        //         { Dept = Dept.ENGINEERING, Key = "test" };




        //return View(vm);





        //     }
        public IActionResult Index()
        {
            RegisterViewModel vm = new RegisterViewModel();
            // vm.Dept = Dept.ENGINEERING;
            //vm.Key = "test";

            vm.ResourceType = ResourceType.Command;
            return View(vm);


            //EditResourcesViewModel vm = new EditResourcesViewModel();
            //vm.ResourceType = ResourceType.Command;
            //return View(vm);
        }

    }
}