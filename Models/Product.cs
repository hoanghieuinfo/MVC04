using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC04.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên mặt hàng không được để trống")]
        [StringLength(200, ErrorMessage = "Tên mặt hàng không quá 200 ký tự")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "URL ảnh không được để trống")]
        [RegularExpression(@"^.+\.(png|PNG)$", ErrorMessage = "Ảnh đại diện phải có định dạng PNG")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả không quá 1000 ký tự")]
        public string Description { get; set; }
    }
}