using System;
using System.Threading.Tasks;
using HotelListing.DTOs;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userLoginDTO);
        Task<string> CreateToken();

    }
}
