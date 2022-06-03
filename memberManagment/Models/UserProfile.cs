using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using memberManagment.Data;

namespace memberManagment.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Accounts, AddMemeberModel>().ReverseMap();
        }
    }
}
