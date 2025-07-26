namespace ApiProjeKampi.WebApi.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string NameSurname { get; set; }
        public string Emali { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int CountofPeople { get; set; }
        public string Massage { get; set; }
        public string ReservationStatus { get; set; }
    }
}
