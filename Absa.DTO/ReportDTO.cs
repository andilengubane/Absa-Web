using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Absa.DTO
{
	public class ReportDTO
	{
		[Key]
		public int ID { get; set; }
		public string BusinessUnit { get; set; }
		public int BusinessUnitId { get; set; }
		public IEnumerable<SelectListItem> BusinessUnitList { get; set; }
	}
}
