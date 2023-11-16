using CRMContacts.Models;

namespace CRMContacts.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact, Guid id);
        Task DeleteContact(Guid id);
    }
}
