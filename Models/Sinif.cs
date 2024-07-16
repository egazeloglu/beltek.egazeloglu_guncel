using System.ComponentModel.DataAnnotations.Schema;

namespace beltek.egazeloglu.Models
{
    [Table("tblSiniflar")]
    public class Sinif
    {
        public int SinifId { get; set; }
        public String SinifAd { get; set; }
        public int Kontenjan { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }

    }
}
