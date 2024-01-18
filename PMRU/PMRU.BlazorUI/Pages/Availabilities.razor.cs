using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using PMRU.BlazorUI.Contracts;
using PMRU.BlazorUI.Models;
using PMRU.BlazorUI.Models.Availability;
using PMRU.BlazorUI.Models.Doctor;
using PMRU.BlazorUI.Services;
using PMRU.BlazorUI.Services.Base;
using PMRU.Domain.Entities;

namespace PMRU.BlazorUI.Pages
{
    public partial class Availabilities
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IAvailabilityService availabilityService { get; set; }
        [Inject]
        public IDoctorService doctorService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Inject]
        AuthenticationStateProvider authenticationStateProvider { get; set; }


        public List<DoctorVM> doctors { get; set; }
        public List<AvailabilityVM> availabilities { get; set; }
        public EmployeeVM Employee { get; private set; } = new EmployeeVM();

        private AuthenticationState authenticationState;

        private int doctorId;
        private int selectedDoctorId;
        public string registrationNumber { get; set; } = "";
        private List<DoctorVM> doctorsInCurrentUserLocation;


        protected override async Task OnInitializedAsync()
        {
            authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            if (authenticationState.User?.Claims != null)
            {
                var registrationNumberClaim = authenticationState.User.Claims.FirstOrDefault(c=>c.Type=="RegistrationNumber");
                if (registrationNumberClaim != null)
                {
                    var employee = await EmployeeService.GetEmployeeByRegistrationNumber(registrationNumberClaim.Value);

                    if (employee != null)
                    {
                        var location = employee.Location;
                        doctorsInCurrentUserLocation = await doctorService.GetDoctorsByLocation(location.Id);
                    }
                    else
                    {
                        doctorsInCurrentUserLocation=new List<DoctorVM>();
                    }
                }
            }
        }

        private async Task GetAvailabilitiesByDoctorId()
        {
            availabilities = await availabilityService.GetAvailabilitiesByDoctorId(selectedDoctorId);
        }

        private async void DeleteAvailability(AvailabilityVM availability)
        {

                var deleteAvailabilityVM = new DeleteAvailabilityVM { Id = availability.Id };
                await availabilityService.DeleteAvailability(deleteAvailabilityVM);

                selectedDoctorId = GetSelectedDoctorId();

                availabilities = await availabilityService.GetAvailabilitiesByDoctorId(selectedDoctorId);
            
        }
        private int GetSelectedDoctorId()
        {
            return selectedDoctorId;
        }


        private void NavigateToCreateAvailability()
        {
            NavigationManager.NavigateTo("/create-availability");
        }

        private void NavigateToEditAvailability()
        {
            NavigationManager.NavigateTo("/edit-availability");
        }
    }
}