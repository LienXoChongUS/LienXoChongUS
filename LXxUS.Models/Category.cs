using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LXxUS.Models
{
    public class Category
    {

        [Key] //đây là chú thích dữ liệu, nó dùng để xác định khóa chính,
              //nếu tên là ID thì chương trình tự xác định, còn không thì phải dùng chú thích dữ liệu
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
