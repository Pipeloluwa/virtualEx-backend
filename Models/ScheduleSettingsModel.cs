using System.ComponentModel.DataAnnotations;

namespace virtual_ex.Models
{
    public class ScheduleSettingsModel
    {
        [Key]
        public Guid SchedulId { get; set; }= Guid.NewGuid();
        public string? NormalScheduledFee { get; set; }
        public string? CustomScheduledFee { get; set; }
        public int MaximumFridayTourSchedule { get; set; }
        public int MaximumSaturdayTourSchedule { get; set; }
    }
}
