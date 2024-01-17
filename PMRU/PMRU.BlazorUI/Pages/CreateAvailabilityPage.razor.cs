using Microsoft.AspNetCore.Components;
using PMRU.BlazorUI.Contracts;
using PMRU.BlazorUI.Models.Availability;

namespace PMRU.BlazorUI.Pages
{
    public partial class CreateAvailabilityPage
    {
       
        [Inject]
        public IAvailabilityService availabilityService { get; set; }
        [Inject]
        public IDoctorService doctorService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        private AvailabilityVM newAvailability = new AvailabilityVM();

        private List<AvailabilityVM> availabilities;
        private int doctorId;


        protected override async Task OnInitializedAsync()
        {
            availabilities = await availabilityService.GetAvailabilities();
        }

        private async Task GetAvailabilitiesByDoctorId()
        {
            availabilities = await availabilityService.GetAvailabilitiesByDoctorId(doctorId);
        }

        private void CreateAvailability(AvailabilityVM availability)
        {
            // Edit i�lemleri i�in burada gerekli kodlar� ekleyin
            // �rne�in, bir modal g�stererek d�zenleme yapabilirsiniz.
        }

    }
}
