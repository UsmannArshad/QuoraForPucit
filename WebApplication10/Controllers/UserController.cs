﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Models;
using Microsoft.Data.SqlClient;

namespace WebApplication10.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignUp(User u)
        {
            bool check = UserRepository.IsUsernameUnique(u.Username);
            if(check==true)
            {
                UserRepository.AddUser(u);
                List<User> users = UserRepository.DisplayAllUsers();
                return View("MainPage", users);
            }
            else
            {
                return View("DeniedSignUp");
            }
        }
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignIn(string username,int password)
        {
            bool check=UserRepository.CheckCredentials(username, password);
            if(check==true)
            {
                List<User> users = UserRepository.DisplayAllUsers();
                return View("MainPage",users);
            }
            else
            {
                return View("DeniedLogin");
            }
        }
    }
}
