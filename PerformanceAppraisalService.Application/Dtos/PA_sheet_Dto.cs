using System;
using System.Collections.Generic;
using System.Text;

namespace Create_PA.application.Dtos
{
    public class PA_sheet_Dto
    {
        public Guid Id { get; set; }
        public string Employee_Name { get; set; }
        public string Designation { get; set; }
        public string Dep_Head_Name { get; set; }
        public DateTime Due_date { get; set; }


    }
}
