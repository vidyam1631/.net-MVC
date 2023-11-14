using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_APIFirstDemo.Data;
using MVC_APIFirstDemo.Models;
using Newtonsoft.Json;

namespace MVC_APIFirstDemo.Controllers
{
    public class MVC_MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        private readonly ILogger<MVC_MovieController> _logger;
        private readonly MVC_APIFirstDemoContext _context;

        public MVC_MovieController(IHttpClientFactory httpClientFactory
            , ILogger<MVC_MovieController> logger, HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<MVC_Movie> movieList = new List<MVC_Movie>();

            using (var response = await _httpClient.GetAsync("https://localhost:44370/api/Movies"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                movieList = JsonConvert.DeserializeObject<List<MVC_Movie>>(apiResponse);
            }
            return View(movieList);
        }

        // GET: MVC_Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            MVC_Movie movie = new MVC_Movie();
            using (var response = await _httpClient.GetAsync("https://localhost:44370/api/Movies" + "/" + id))
            {

                string apiResponse = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<MVC_Movie>(apiResponse);
            }
            return View(movie);
            //if (id == null || _context.MVC_Movie == null)
            //{
            //    return NotFound();
            //}

            //var mVC_Movie = await _context.MVC_Movie
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (mVC_Movie == null)
            //{
            //    return NotFound();
            //}

            //return View(mVC_Movie);
        }

        // GET: MVC_Movie/Create
       
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC_Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MVC_Movie movie)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(movie);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

                _logger.LogInformation($"Sending movie:{data}");
                var response = await _httpClient.PostAsync("https://localhost:44370/api/Movies", stringContent);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View(movie);
            }
            return View();
        }

        // GET: MVC_Movie/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            MVC_Movie movie = new MVC_Movie();

            using (var response = await _httpClient.GetAsync("https://localhost:44370/api/Movies" + "/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<MVC_Movie>(apiResponse);
            }
            return View(movie);

        }

        //POST:  MVC_MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(int id, MVC_Movie movie)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(movie);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

                _logger.LogInformation($"Sending movie:{data}");
                var response = await _httpClient.PutAsync("https://localhost:44370/api/Movies" + "/" + id, stringContent);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View(movie);
            }
            return View();
        }

        //GET: MVC_MovieController/Delete/5

        public async Task<ActionResult> Delete(int id)
        {


            var response = await _httpClient.DeleteAsync("https://localhost:44370/api/Movies" + "/" + id);
            return RedirectToAction("Index");

        }

        //POST:  MVC_MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete(int id, MVC_Movie movie)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ShowViaAPI()
        {
            return View();
        }
    }
}
