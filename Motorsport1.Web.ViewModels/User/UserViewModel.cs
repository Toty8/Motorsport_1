using AutoMapper;
using Motorsport1.Data.Models;
using Motorsport1.Services.Mapping;

namespace Motorsport1.Web.ViewModels.User
{
    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {

        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(u => u.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(u => u.Id,
                opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
