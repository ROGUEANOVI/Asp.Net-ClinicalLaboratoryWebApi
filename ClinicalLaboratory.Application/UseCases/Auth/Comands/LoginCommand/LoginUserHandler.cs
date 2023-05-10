using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Application.DTOs.Auth.Request;
using ClinicalLaboratory.Application.DTOs.Auth.Response;
using ClinicalLaboratory.Application.Interfaces;
using ClinicalLaboratory.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClinicalLaboratory.Application.UseCases.Auth.Comands.LoginCommand
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, BaseResponse<LoginUserResponseDTO>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtHandlerService _jwtHandlerService;

        public LoginUserHandler(UserManager<User> userManager, IJwtHandlerService jwtHandlerService)
        {
            _userManager = userManager;
            _jwtHandlerService = jwtHandlerService;
        }


        public async Task<BaseResponse<LoginUserResponseDTO>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<LoginUserResponseDTO>();

            try
            {
                var userFound = await _userManager.FindByEmailAsync(request.Email!);
                if (userFound == null)
                {
                   
                    response.IsSuccess = false;
                    response.Data = new LoginUserResponseDTO()
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrectos"
                        }
                    };
                }

                else
                {
                    var isCorrectPassword = await _userManager.CheckPasswordAsync(userFound, request.Password!);
                    if (isCorrectPassword)
                    {

                        var userRole = await _userManager.GetRolesAsync(userFound);

                        var parameters = new JwtParameters()
                        {
                            Id = userFound.Id,
                            UserName = userFound.UserName!,
                            PasswordHash = userFound.PasswordHash!,
                            RoleName = userRole.First().ToLower()
                        };

                        var jwtToken = _jwtHandlerService.GenerateJwt(parameters);

                        response.IsSuccess = true;
                        response.Message = "El usuario ha iniciado sesión correctamente";
                        response.Data = new LoginUserResponseDTO()
                        {
                            Login = true,
                            Token = jwtToken,
                            User = userFound.UserName,
                            Role = userRole.First().ToLower()
                        };
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Data = new LoginUserResponseDTO()
                        {
                            Login = false,
                            Errors = new List<string>()
                            {
                                "Usuario o contraseña incorrectos"
                            }
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
