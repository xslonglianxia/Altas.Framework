﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Altas.Framework.AppService;
using Altas.Framework.Common;
using Altas.Framework.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Altas.Framework.Models;

namespace Altas.Framework.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SysMenuAppService _menuApp;

        public HomeController(SysMenuAppService menuApp)
        {
            _menuApp = menuApp;
        }
        public IActionResult Index()
        {
            var user = CookieHelper.GetUserLoginCookie();
            if (user != null)
            {
                var userDto = user.ToObject<LoginUserDto>();
                ViewBag.Id = userDto.Id.ToString();
                ViewBag.AccountName = userDto.AccountName;
                ViewBag.UserName = userDto.RealName;
            }
            return View();
        }
        public async Task<ActionResult> GetRoleMenu()
        {
            var result = new ResultAdaptDto();
            var menu = await _menuApp.GetRoleMenu();
            result.data.Add("menu", menu.Item1);
            result.data.Add("funcs", menu.Item2);
            return Content(result.ToJson());
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
