using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ResultDTO> Register(UserDTO userDTO);
        Task<ResultDTO> Login(LoginDTO userDTO);
        //Task<ResultDTO> Logout( );
        //ResultDTO GetAllUsers();
        //Task<ResultDTO> DeleteUser(string emial);
        //bool Authenticate_User {  get; }
        //bool CheckAuthenticateUser(string username, string password);
        //void SignOut();
    }
}
