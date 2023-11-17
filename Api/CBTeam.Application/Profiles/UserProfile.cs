﻿using AutoMapper;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
                //.ForMember(x => x.Propiedad, opt => opt.MapFrom(x => x.firstName)); --> Cuando pierde la convención se puede usar esto con autoMapper
        }
    }
}
