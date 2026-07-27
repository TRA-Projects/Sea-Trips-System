using Microsoft.AspNetCore.Mvc;

namespace Sea_Trips_System.Models
{
    [ApiController]
    [Route("Destination")]
    public class DestinationControllers:ControllerBase
    {
        private DestinationService destinationService;

        // Dependency Injection
        public DestinationControllers(DestinationService _destinationService)
        {
            destinationService = _destinationService;
        }


    }
}
