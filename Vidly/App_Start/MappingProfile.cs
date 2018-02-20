using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.Initialize(map =>
            {

                map.CreateMap<Customer, CustomerDto>();
                map.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
                map.CreateMap<Movie, MovieDto>(); ;
                map.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
                map.CreateMap<MembershipType, MembershipTypeDto>();
                map.CreateMap<MembershipTypeDto, MembershipType>();
                map.CreateMap<Genre, GenreDto>();
                map.CreateMap<GenreDto, Genre>().ForMember(m => m.Id, opt => opt.Ignore()); ;
                map.CreateMap<Rental, NewRentalDto>();
                map.CreateMap<Rental, ReturnRentalDto>();
                map.CreateMap<ReturnRentalDto, Rental>();
            });

            /*********************/
            // Old way below, new way above
            //Mapper.CreateMap<Customer, CustomerDto>();
            //Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<Movie, MovieDto>(); ;
            //Mapper.CreateMap<MovieDto,Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            //Mapper.CreateMap<MembershipTypeDto,MembershipType>();
            //Mapper.CreateMap<Genre,GenreDto>();
            //Mapper.CreateMap<GenreDto, Genre>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            //Mapper.CreateMap<Rental, NewRentalDto>();
            //Mapper.CreateMap<Rental, ReturnRentalDto>();
            //Mapper.CreateMap<ReturnRentalDto,Rental>();
        }
    }
}