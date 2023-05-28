using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Models.DTOs;

namespace WebApplication1.DataBase.Interfaces;

public interface IDataBaseContext
{
    public DbSet<UserDto> Users { get; set; }
    public DbSet<ProductDto> Products { get; set; }
    public DbSet<CategoryDto> Categories { get; set; }
    public DbSet<FavoriteDto> Favorites { get; set; }
    public DbSet<ImageDto> Images { get; set; }
    public DbSet<PaymentMeanDto> PaymentMeans { get; set; }
    public DbSet<ProductAndImageDto> ProductAndImages { get; set; }
    public DbSet<ReviewDto> Reviews { get; set; }
    public DbSet<RoleDto> Roles { get; set; }
    public DbSet<BasketDto> Baskets { get; set; }

    public Task<int> SaveAsync();
}