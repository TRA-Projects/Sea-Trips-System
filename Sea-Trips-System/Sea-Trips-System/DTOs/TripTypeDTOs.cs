public class CreateTripDto
{
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
    public int boatId { get; set; }  
}

public class TripResponseDto
{
    public int tripTypeId { get; set; }
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
    public string status { get; set; }
}

public class TripTypeDetailsDTO
{
    public int tripTypeId { get; set; }
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
    public int appointmentCount { get; set; }
}