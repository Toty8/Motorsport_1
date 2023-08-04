namespace Motorsport1.Web.ViewModels.Comment
{
    using Motorsport1.Services.Mapping;
    using Data.Models;
    using AutoMapper;
    using System.Globalization;

    public class CommentDetailViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public string PublishedDateTime { get; set; } = null!;

        public string PublisherId { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentDetailViewModel>()
                .ForMember(c => c.PublishedDateTime, 
                    opt => opt.MapFrom(src => src.PublishedDateTime.ToString("HH:mm dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
