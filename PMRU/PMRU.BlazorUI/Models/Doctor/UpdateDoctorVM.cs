﻿namespace PMRU.BlazorUI.Models.Doctor
{
    public class UpdateDoctorVM
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
