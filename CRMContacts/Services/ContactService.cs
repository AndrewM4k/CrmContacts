using CRMContacts.Models;
using CRMContacts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CRMContacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext _context;

        public ContactService(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }

        public async Task AddContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContact(Contact contact, Guid id)
        {
            var oldcontact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (oldcontact == null) { new Exception("Wrong Contact Id"); }

            oldcontact.Name = contact.Name;
            oldcontact.MobilePhone = contact.MobilePhone;
            oldcontact.BirthDate = contact.BirthDate;
            oldcontact.JobTitle = contact.JobTitle;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(Guid id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(e => e.Id == id);
            if (contact == null)
            {
                return;
            }
            _context.Remove(contact);

            await _context.SaveChangesAsync();
        }
    }
}
