using ClinicalLaboratory.Application.Commons.Bases;
using ClinicalLaboratory.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClinicalLaboratory.Application.UseCases.Auth.Comands.RegisterCommand
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, BaseResponse<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterUserHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var existingUser = await _userManager.FindByEmailAsync(request.Email!);
                if (existingUser != null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ya existe un usuario registrado con este Email";
                }

                User user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.Email
                };

                var isUserCreated = await _userManager.CreateAsync(user, request.Password!);

                var roleExists = await _roleManager.RoleExistsAsync(request.RoleName!);

                if (isUserCreated.Succeeded)
                {
                    if (!roleExists)
                    {
                        var role = new Role()
                        {
                            Name = request.RoleName,
                        };

                        var isRoleCreated = await _roleManager.CreateAsync(role);

                        if (isRoleCreated.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, role.Name!);
                        }
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, request.RoleName!);
                    }

                    response.IsSuccess = true;

                    return response;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors = new List<BaseError>()
                    {
                        new BaseError()
                        {
                            ErrorMessage = isUserCreated.Errors.Select(e => e.Description).ToString()
                        }
                    };
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
