using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Domain.Models;
using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Domain.DTO;
using System.Security.Policy;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        //private SignInManager<ApplicationUser> _signInManager;
        //private UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork unitOfWork;
        //public bool Authenticate_User { get; private set; }
        public AuthService(
            
            IUnitOfWork unitOfWork)
        {
           
            this.unitOfWork = unitOfWork;
            
        }
        //public  ResultDTO GetAllUsers()
        //{
        //    List<ApplicationUser> applicationUsers;
        //    applicationUsers =  _userManager.Users.ToList();
        //    return new ResultDTO() { StatusCode = 400, Data = applicationUsers };
        //}
        public async Task<ResultDTO> Login(LoginDTO loginDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            if (loginDTO != null)
            {
                List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
                string HashPassword = Domain.Constants.Hash.Hash_SHA1(loginDTO.Password);
                applicationUsers = (List<ApplicationUser>)unitOfWork.UserRepository.GetAll();
                ApplicationUser applicationUser = unitOfWork.UserRepository.Get(a=>a.Email ==  loginDTO.Email && a.Password == HashPassword);
                if (applicationUser == null)
                {
                    return new ResultDTO() { StatusCode = 400, Data = "Invalid Data" };
                }
                //    ApplicationUser user = await _userManager.FindByEmailAsync(userDTO.Email);
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = applicationUser,
                    Message = "you loged in successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid Data" };
            }
            //    if (user == null) { return new ResultDTO() { StatusCode = 400, Data = "User Not found" }; }

            //    var result = await _signInManager.CheckPasswordSignInAsync(user, userDTO.Password, false);
            //    if (!result.Succeeded) {

            //        return new ResultDTO() { StatusCode = 400, Data = "Invalid Data" };
            //    }



        }
        public async Task<ResultDTO> Register(UserDTO userDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            if (userDTO != null)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Email = userDTO.Email;
                applicationUser.Name = userDTO.Name;
                applicationUser.Password = Domain.Constants.Hash.Hash_SHA1( userDTO.Password);
                applicationUser.Address = userDTO.Address;
                unitOfWork.UserRepository.Create(applicationUser);
                unitOfWork.commit();
                //        Random rnd = new Random();
                //        applicationUser.Name = $"{"User"}{rnd.Next(1, 1000)}";
                //        IdentityResult result = await _userManager.CreateAsync(applicationUser, userDTO.Password);
                //        if (result.Succeeded)
                //        {
                resultDTO.StatusCode = 200;
                resultDTO.Data = applicationUser;
                resultDTO.Message = "User has been added";
                //            // await userManager.AddToRoleAsync(applicationUser, "User");//insert row UserRole
                return resultDTO;
            }
            else
            {
                resultDTO.StatusCode = 404;

                resultDTO.Data = "null or bad request";
                return resultDTO;
            }

        }
        //resultDTO.StatusCode = 404;
        //        resultDTO.Data = "null or bad request";
        //        return resultDTO;
        //    }

    //public async Task<ResultDTO> Logout( )
    //{
    //    ResultDTO resultDTO = new ResultDTO();
    //      await _signInManager.SignOutAsync();
    //    return new ResultDTO(){
    //        StatusCode = 200,
    //        Data="Signout Is successed"
    //    };
    //} 
    //public async Task<ResultDTO> DeleteUser(string emial )
    //{
    //    if (!string.IsNullOrEmpty(emial))
    //    {
    //      var user = await   _userManager.FindByEmailAsync(emial);
    //        if (user != null)
    //        {
    //            await _userManager.DeleteAsync(user);
    //            return new ResultDTO()
    //            {
    //                StatusCode = 200,
    //                Data = "User Is deleted successfully"
    //            };
    //        }
    //        return new ResultDTO()
    //        {
    //            StatusCode = 400,
    //            Data = "null or bad request"
    //        };
    //    }

    //    return new ResultDTO(){
    //        StatusCode = 400,
    //        Data= "null or bad request"
    //    };
    //}
    //public bool CheckAuthenticateUser(string username, string password)
    //{
    //    //if(unitOfWork.UserRepository.Get(x=> x.UserName == username && x.Password == password) != null)
    //    //{
    //    //    Authenticate_User = true;
    //    return Authenticate_User;

    //    //}else 
    //    //{
    //    //    Authenticate_User = false;
    //    //    return Authenticate_User; 
    //    //}
    //}
    //public void SignOut()
    //{
    //    Authenticate_User = false;            
    //}
}
}
