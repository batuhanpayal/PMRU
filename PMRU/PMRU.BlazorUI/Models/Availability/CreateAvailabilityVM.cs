﻿namespace PMRU.BlazorUI.Models.Availability
{
    public class CreateAvailabilityVM
    {
        public int DoctorID { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
