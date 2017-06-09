// Copyright (c) .NET Foundation. All rights reserved. 
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Culture : BaseEntity
    {
   
        public string Name { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
