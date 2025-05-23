
using LibraryHub.Business.Core.Contracts;
using LibraryHub.Business.Core.Services;
using LibraryHub.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.UI.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddTransient<IReviewService, ReviewService>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<LibraryHubDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
