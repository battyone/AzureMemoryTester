using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMemoryTester.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureMemoryTester.Controllers
{
    public class HomeController : Controller
    {
        private readonly MemoryService _memoryService;

        public HomeController(MemoryService memoryService)
        {
            _memoryService = memoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeModel
            {
                Allocated = _memoryService.Allocated,
                Allocations = _memoryService.Allocations,
                ProcessWS = _memoryService.GetProcessWS(),
                ProcessPM = _memoryService.GetProcessPM(),
                GCMem = _memoryService.GetGCMem(),
                EnvWS = _memoryService.GetEnvWS(),
                Is64Bit = _memoryService.Is64Bit()

            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeModel model)
        {
            _memoryService.Allocate(100);
            return RedirectToAction();
        }

    }
}
