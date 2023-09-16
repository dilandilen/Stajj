using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	
	public class Admin
	{
		public int AdminID { get; set; }
		public string UserName { get;set; }
		public string Password { get; set; }
		public string Authority { get; set; }	
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
