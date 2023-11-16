using AutoMapper;
using CRMContacts.Dtos;
using CRMContacts.Models;

namespace CRMContacts.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, GetContactDto>();
            CreateMap<GetContactDto, Contact>();
            CreateMap<AddContactDto, Contact>();
            CreateMap<Contact, AddContactDto>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, UpdateContactDto>();
        }
    }
}
