using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>(); ;
            Mapper.CreateMap<MovieDto,Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto,MembershipType>();
            Mapper.CreateMap<Genre,GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<Rental, ReturnRentalDto>();
            Mapper.CreateMap<ReturnRentalDto,Rental>();
        }
    }
}