using AutoMapper;
using CRMContacts.Dtos;
using CRMContacts.Models;
using CRMContacts.Persistance;
using CRMContacts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SportsCompetition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsDbContext> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<AddContactDto> _validator;
        private readonly ContactService _contactService;

        public ContactsController(IMapper mapper, ILogger<ContactsDbContext> logger, ContactService contactService, IValidator<AddContactDto> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _contactService = contactService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetContactDto>>> Get()
        {
            try
            {
                var contactsdto = new List<GetContactDto>();
                var contacts = await _contactService.GetAllContacts();
                contactsdto = _mapper.Map<List<GetContactDto>>(contacts);

                return contactsdto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddContactDto dto)
        {
            var validateresult = await _validator.ValidateAsync(dto);
            if (!validateresult.IsValid)
            {
                return BadRequest(validateresult.Errors);
            }
            var contact = _mapper.Map<Contact>(dto);
            await _contactService.AddContact(contact);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto, Guid id)
        {
            try
            {
                var contact = _mapper.Map<Contact>(dto);
                await _contactService.UpdateContact(contact, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
