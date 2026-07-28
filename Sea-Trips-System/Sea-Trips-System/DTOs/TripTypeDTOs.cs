
﻿using Sea_Trips_System.Models;
using System.ComponentModel.DataAnnotations;

public class CreateTripDto
{

    // ──  API — The data that the user sends to Input DTO ───────────────


    [Required(ErrorMessage = "Trip Type Name is required.")]
        [StringLength(100, ErrorMessage = "Trip Type Name cannot exceed 100 characters.")]
        public string typeName { get; set; }

        [Required(ErrorMessage = "Base Price is required.")]
        [Range(1, 999, ErrorMessage = "Base Price must be greater than 0.")]
        public decimal basePrice { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string description { get; set; }
    }


// ── —  API The data it returns to Response DTOs─────────────────────────


// Used when displaying all Trip Types
public class TripResponseDto
{
        public int tripTypeId { get; set; }

        public string typeName { get; set; }

        public decimal basePrice { get; set; }

        public string description { get; set; }
    }


    // Used when displaying one Trip Type with its Appointments
    public class TripTypeAllOutputDTO
    {
        public int tripTypeId { get; set; }

        public string typeName { get; set; }

        public decimal basePrice { get; set; }

        public string description { get; set; }

       
    }
