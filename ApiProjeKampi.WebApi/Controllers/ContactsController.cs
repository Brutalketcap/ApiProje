using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.DTO.ContactDTO;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            return Ok(_context.Contacts.ToList());
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Emali = createContactDto.Emali;
            contact.Adress = createContactDto.Adress;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            contact.Phone = createContactDto.Phone;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Eklem işlemi Başarılı");

            // Buna maplame denir. burad bütün parametreleri aldık ama sadece bir veya iki tane almamzı gerekirse öğle yapılır.
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi Başarılı");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto  updateContactDto) 
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.Emali = updateContactDto.Emali;
            contact.Adress = updateContactDto.Adress;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.Phone = updateContactDto.Phone;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Başarılı bir şekide güncellendi");
        }

    }

}
