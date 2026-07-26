public class TripTypeInputDTO
{
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
}

public class TripTypeOutputDTO
{
    public int tripTypeId { get; set; }
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
}

public class TripTypeDetailsDTO
{
    public int tripTypeId { get; set; }
    public string typeName { get; set; }
    public decimal basePrice { get; set; }
    public string description { get; set; }
    public int appointmentCount { get; set; }
}