using AutoMapper;
using ELDocClinic.Areas.Accounts.ViewModels;
using ELDocClinic.Models;

namespace ELDocClinic.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<RegisterVM, ApplicationUser>();
        }
    }
}
