using memberManagment.Data;
using memberManagment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace memberManagment.Repository
{
    public interface IAccountRepository
    {
        Task<Accounts> AddMemeber(AddMemeberModel member);
        List<CitiesModel> Cities(int id);
        List<CountriesModel> countrieslist();
        Task<Accounts> delete(int id);
        Accounts EditCity(Accounts data, AddMemeberModel member);
        Accounts find(int id);
        Task<AddMemeberModel> Getuser();
        Task<Accounts> update(AddMemeberModel member);
    }
}