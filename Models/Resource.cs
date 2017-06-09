// Copyright (c) .NET Foundation. All rights reserved. 
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{

	//public enum ResourceType
	//{
	//	Label, Validation, Report, Header, Command, Exception
	//}

	public class Resource : BaseEntity
    {
     
        public int CultureID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
		[Required]
		public   Culture Culture { get; set; }

		public ResourceType ResourceType { get; set; }
	}
}
