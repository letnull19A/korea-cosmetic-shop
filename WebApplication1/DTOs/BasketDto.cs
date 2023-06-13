using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOs
{
    [Table("basket")]
    public sealed class BasketDto
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("count")]
        public int Count { get; set; } = 1;
    }
}
