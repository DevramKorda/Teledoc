using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teledoc.Models
{
	//главная сущность
	public class Client
	{
		public int Id { get; set; }

		[DisplayName("ИНН")]
		public long Inn { get; set; }

		[DisplayName("Наименование клиента")]
		public string Name { get; set; } = "";

		[DisplayName("Тип клиента")]
		public string Type { get; set; } = "";

		[DisplayName("Дата добавления")]
		public DateTime AddDate { get; set; }

		[DisplayName("Дата обновления")]
		public DateTime UpdateDate { get; set; }
		
		public List<Founder> Founders { get; set; } = null!; //навигационное свойство				
	}
}
