using AutoMapper;
using ColorSoft.Web.Infrastructure.AutoMapper.Extensions;
using ColorSoft.Web.Models.Contact;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.Message
{
    public class MessageProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<MessageViewModel, Data.Models.Message>().
                ForMember(d => d.MessageText, opt => opt.MapFrom(s => s.Message)).
                ForMember(d => d.From, opt => opt.MapFrom(s => s.Email)).
                DoNotSet(d => d.CreatedAt, d => d.Id);

            CreateMap<Data.Models.Message, MessageViewModel>().
                ForMember(d => d.Message,
                          opt => opt.MapFrom(s => s.MessageText)).
                ForMember(d => d.Email, opt => opt.MapFrom(s => s.From)).
                ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt.ToString("dd-MMM-yyyy HH:mm")));
        }
    }
}