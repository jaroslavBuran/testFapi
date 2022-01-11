using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using testFapi.Models;

namespace testFapi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult NewOrder()
        {
            List<int> taxRates = new List<int>()
            {
                21,15,10,0
            };

            SelectList rates = new SelectList(taxRates);
            ViewBag.taxRates = rates;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewOrder(OrderViewModel order)
        {
            string url = $"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt";
            var response = CallUrl(url).Result;

            string[] data = response.Split('|');

            decimal kurz = decimal.Parse(data[28].Substring(0, 6).Replace(',','.')); //ne úplně dobré řešení

            order.TotalPrice = order.Price * order.Quantity;

            order.DPH = order.TotalPrice * (order.TaxRate/100m);
            order.FinalPrice = order.TotalPrice + order.DPH;
            order.FinalPriceEuro = order.FinalPrice / kurz;

            if (ModelState.IsValid)
            {
                return View("Recap", order);
            }
            else
            {
                return View(order);
            }
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }
    }
}
