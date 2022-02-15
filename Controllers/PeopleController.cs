using Day6.Data;
using Day6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day6.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(RookiesData.People);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            RookiesData.People.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int personID)
        {
            var item = RookiesData.People.Where(person => person.ID == personID).SingleOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel model)
        {
            var item = RookiesData.People.Where(person => person.ID == model.ID).FirstOrDefault();
            if (item != null)
            {
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Gender = model.Gender;
                item.DateOfBirth = model.DateOfBirth;
                item.PhoneNumber = model.PhoneNumber;
                item.BirthPlace = model.BirthPlace;
                item.IsGraduated = model.IsGraduated;
                return RedirectToAction("Index");
            }
            else return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int personID)
        {
            var item = RookiesData.People.FirstOrDefault(person => person.ID == personID);
            if (item != null)
            {
                RookiesData.People.Remove(item);
                return RedirectToAction("Index");
            }
            else return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}