using System;
using System.Collections.Generic;
using System.Text;

namespace Create_PA.application.Dtos
{
    public class PA_sheet_Dto
    {
        public Guid Id { get; set; }
        public string Department { get; set; }

        public string Dep_Head_Name { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime Due_date { get; set; }


    }
}
