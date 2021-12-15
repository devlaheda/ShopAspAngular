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

            services.AddCors(opt =>{
                opt.AddPolicy("CorsPolicy", p => p.AllowAnyHeader().AllowAnyMethod().WithOrigins("https//localhost:4200"));
            });
           return  services ;
        }
    }
}