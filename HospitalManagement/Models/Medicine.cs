namespace HospitalManagement.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Unit { get; set; }
    public string? UseManual { get; set; }
    public string? ActiveElement { get; set; }
}
