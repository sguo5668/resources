using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
 
	}
}
