namespace ApiProjeKampi.WebApi.DTO.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string VidoeCoverImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
        public string ReservationNumber { get; set; }
    }
}
