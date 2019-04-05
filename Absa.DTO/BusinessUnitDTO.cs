using System;
using System.ComponentModel.DataAnnotations;

namespace Absa.DTO
{
	public class BusinessUnitDTO
	{
		[Key]
		public int BusinessUnitId { get; set; }
		public string BusinessUnitName { get; set; }
		public bool IsActive { get; set; }
		public DateTime DateLogged { get; set; }
		public int NumberOfApps { get; set; }
		public string Description { get; set; }
		public int UserID { get; set; }
	}
}
