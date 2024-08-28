using Microsoft.EntityFrameworkCore;
using virtual_ex.Models;

namespace virtual_ex.Data.Seeding
{
    public class SeedScheduleSettings
    {


        private readonly ScheduleSettingsModel scheduleSettingsModel = new ScheduleSettingsModel()
        {
            SchedulId = Guid.NewGuid(),
            NormalScheduledFee = "0",
            CustomScheduledFee = "5000",
            MaximumFridayTourSchedule = 50,
            MaximumSaturdayTourSchedule = 60
        };



        public void SeedScheduleSettingsFunction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleSettingsModel>().HasData
                (
                    scheduleSettingsModel
                );
        }


    }


}
