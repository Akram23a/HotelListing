using System;
using System.Threading.Tasks;
using HotelListing.Data;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> CountriesRepository { get; }
        IGenericRepository<Hotel> HotelsRepository { get; }
        Task Save();

    }
}
