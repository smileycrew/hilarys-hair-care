using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentTime { get; set; }
    public bool IsCancelled { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required]

    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public List<AppointmentDetail> AppointmentDetails { get; set; }
    public decimal TotalCost
    {
        get
        {
            decimal total = 0M;
            foreach (AppointmentDetail AppointmentDetail in AppointmentDetails)
            {
                total += AppointmentDetail.Service.Price;
            }
            return total;
        }
    }
}