namespace BlazorServer.Domain.Mappings
{
    using AutoMapper;
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<DTOs.HotelRoom, Entities.HotelRoom>().ReverseMap();
        }
    }
}
