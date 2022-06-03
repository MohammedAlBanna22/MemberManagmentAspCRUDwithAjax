using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using memberManagment.Data;
using memberManagment.Models;

namespace memberManagment.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _acountcontext;
        private readonly IMapper _mapper;
        public AccountRepository(ApplicationDbContext acountcontext, IMapper mapper)
        {
            _acountcontext = acountcontext;

            _mapper = mapper;
        }
        public async Task<Accounts> AddMemeber(AddMemeberModel member)
        {
            Accounts data1 = _mapper.Map<Accounts>(member);
            var country = _acountcontext.Countries.Find(member.Country);
            data1.Country = country.name;
            var city = _acountcontext.Cities.Find(member.City);
            data1.City = city.name;
            await _acountcontext.Accounts.AddAsync(data1);
            await _acountcontext.SaveChangesAsync();
            return data1;
        }
        public async Task<AddMemeberModel> Getuser()
        {
            var users1 = await _acountcontext.Accounts.ToListAsync();
            List<AddMemeberModel> data1 = _mapper.Map<List<AddMemeberModel>>(users1);
            var m1 = data1.Last();
            return m1;
        }

        public async Task<Accounts> delete(int id)
        {
            var user = _acountcontext.Accounts.Find(id);
            _acountcontext.Accounts.Remove(user);
            await _acountcontext.SaveChangesAsync();
            return user;
        }

        public Accounts find(int id)
        {
            var user = _acountcontext.Accounts.Find(id);

            return user;
        }
        public async Task<Accounts> update(AddMemeberModel member)
        {
            Accounts data1 = _mapper.Map<Accounts>(member);
            var country = _acountcontext.Countries.Find(member.Country);
            data1.Country = country.name;
            var city = _acountcontext.Cities.Find(member.City);
            data1.City = city.name;
            _acountcontext.Accounts.Update(data1);
            await _acountcontext.SaveChangesAsync();
            return data1;
        }

        public List<CitiesModel> Cities(int id)
        {
            var obj = _acountcontext.Cities.Where(x => x.countryid == id).ToList();
            return obj;
        }

        public Accounts EditCity(Accounts data, AddMemeberModel member)
        {
            var country = _acountcontext.Countries.Find(member.Country);
            data.Country = country.name;
            var city = _acountcontext.Cities.Find(member.City);
            data.City = city.name;
            return data;
        }


        public List<CountriesModel> countrieslist()
        {
            List<CountriesModel> countries = new List<CountriesModel>()
            {
                new CountriesModel {
                        name = "Palestine " ,
                        cities = new List<CitiesModel>
                        {
                        new CitiesModel {name = "Gaza" },
                        new CitiesModel {name = "Rafah" },
                         new CitiesModel {name = "Jabalya" },
                         }

                },

                new CountriesModel {
                        name = "Egypt" ,
                        cities = new List<CitiesModel>
                        {
                        new CitiesModel {name = "cairo city" },
                        new CitiesModel {name = "october city" },
                        new CitiesModel {name = "Naser city" },
   
                    }

                    },

                

            };

            return countries;


        }
       



    }
}