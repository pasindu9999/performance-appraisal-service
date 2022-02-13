namespace PerformanceAppraisalService.Domain.Entities
{
    public class Organization: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegistationNumber { get; set; }
    }
}