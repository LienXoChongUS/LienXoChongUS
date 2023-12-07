using System.ComponentModel.DataAnnotations;

namespace LienXoChongUS.Models
{
	public class Category
	{

		[Key] //đây là chú thích dữ liệu, nó dùng để xác định khóa chính,
			  //nếu tên là ID thì chương trình tự xác định, còn không thì phải dùng chú thích dữ liệu
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public int DisplayOrder { get; set; }

	}
}
