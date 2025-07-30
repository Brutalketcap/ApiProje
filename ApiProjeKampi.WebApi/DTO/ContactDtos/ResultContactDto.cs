namespace ApiProjeKampi.WebApi.DTO.ContactDTO
{
    public class ResultContactDto
    {
        //Dto (Data Transfer Object) sınıfı, veritabanından gelen verileri istemciye göndermek için kullanılır.
        // Bu sınıf, istemciye gönderilecek verilerin yapısını tanımlar.
        // Dto dörttane işlem olur ekleme, güncelleme,ID göre getirme silme işlemi olmaz.
        // ResultContact  listelme için kulllanıcaz.
        // Drek entities üzerinden değilde dto üzerinden köğrü görevi görerek erişim sağlicaz
        public int ContactId { get; set; }
        public string MapLocation { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Emali { get; set; }
        public string OpenHours { get; set; }
    }
}
