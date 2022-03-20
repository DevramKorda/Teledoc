using System.ComponentModel;

namespace Teledoc.Models
{
	//зависимая сущность
	public class Founder
	{
		public int Id { get; set; }

		[DisplayName("ИНН")]
		public long Inn { get; set; }
		
		[DisplayName("Учредитель")]
		public string Fio { get; set; } = "";

		[DisplayName("Дата добавления")]
		public DateTime AddDate { get; set; }

		[DisplayName("Дата обновления")]
		public DateTime UpdateDate { get; set; }
		
		public int ClientId { get; set; } //внешний ключ		
		public Client Client { get; set; } = null!; //навигационное свойство
	}
}
