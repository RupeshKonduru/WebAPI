using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class EmpViewModel
    {      
            public int id { get; set; }
            public string ename { get; set; }
            public Nullable<int> dept_id { get; set; }
       
    }
}