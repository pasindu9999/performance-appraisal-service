using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Panel : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PanelNumber { get; set; }
        public ICollection<PanelReviwer> PanelReviwers { get; set; }
        public ICollection<Reviwee> Reviwees { get; set; }
    }
}
