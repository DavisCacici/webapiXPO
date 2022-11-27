using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using webapiXPO.Context;
using webapiXPO.Models;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace webapiXPO.Controllers
{
    public class Contatto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Contatto(string name, string surname, int age, Gender gender) 
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        public Contatto() { }

    } 
    [ApiController]
    [Route("contact")]
    public class ContactControllers : ControllerBase
    {
        private readonly ILogger<ContactControllers> _logger;

        public ContactControllers(ILogger<ContactControllers> logger)
        {
            _logger = logger;
        }

        private UnitOfWork uow = DbContext.Production();
        // GET: ContactControllers

        [HttpGet("list")]
        public ActionResult<List<Contatto>> Index()
        {
            var contacts = uow.Query<Contact>();
            //return contacts.ToList();
            
            List<Contatto> check = new List<Contatto>();
            foreach (Contact c in contacts)
            {
                Contatto contatto = new Contatto(c.Name, c.Surname, c.Age, c.Gender);
       
                check.Add(contatto);
            }
            //string contactsJson = JsonConvert.SerializeObject(check);
            return check;
        }

        // GET: ContactControllers/Details/5
        [HttpGet("{id}")]
        public ActionResult<Contatto> Details(int id)
        {
            Contatto contatto = new Contatto();
            var contacts = uow.Query<Contact>().Where(c => c.Oid == id);
            foreach(Contact c in contacts)
            {
                Console.WriteLine($"{c.Name} {c.Surname} {c.Age} {c.Gender}");
                contatto.Name = c.Name;
                contatto.Surname = c.Surname;
                contatto.Age = c.Age;
                contatto.Gender = c.Gender;
                break;
            }
            return contatto;
        }


        // POST: ContactControllers/Create
        [HttpPost("create")]
        public ActionResult Create(string values)
        {
            Contact contatto = new Contact(uow);
            JsonConvert.PopulateObject(values, contatto);
            uow.CommitChanges();
            return Ok();

        }

       
    }
}
