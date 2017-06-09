using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.SchoolViewModels
{
	public class EditResourcesViewModel
	{
 
		public string Key { get; set; }
		public string Value { get; set; }
		public List<SelectListItem> Cultures { get; set; } = new List<SelectListItem>();
		[Display(Name = "Culture")]
		public int CultureId { get; set; }

		public ResourceType ResourceType { get; set; }
	}
}
