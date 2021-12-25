using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IBasketRepository,BasketRepository>();
            
            services.Configure<ApiBehaviorOptions>(option =>
            {
                
                option.InvalidModelStateResponseFactory = actionContext =>{
                    var errors = actionContext.ModelState
                                .Where(x=> x.Value.Errors.Count > 0 )
                                .SelectMany(x => x.Value.Errors)
                                .Select(x => x.ErrorMessage)
                                .ToArray();
                        var response = new ApiValidationErrorResponse{
                            Errors = errors
                        };
                        return new BadRequestObjectResult(response);
                };
            });
           
           return  services ;
        }
    }
}