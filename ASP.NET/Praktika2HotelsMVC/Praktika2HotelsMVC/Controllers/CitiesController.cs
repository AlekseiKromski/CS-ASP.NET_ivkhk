﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Praktika2HotelsMVC.Models;

namespace Praktika2HotelsMVC.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public ActionResult Index()
        {
            ViewBag.Cities = CitiesCollection.listCities;
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            ViewBag.Cities = CitiesCollection.listCities;
            if(id != 0)
            {
                ViewBag.HotelId = id;
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Cities()
        {
            ViewBag.Cities = CitiesCollection.listCities;
            return View();
        }

        public ActionResult Hotels(int id = 0)
        {
            ViewBag.Cities = CitiesCollection.listCities;
            ViewBag.CityId = id;
            return View();
        }
    }
}