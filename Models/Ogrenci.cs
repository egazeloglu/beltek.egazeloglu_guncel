using System.ComponentModel.DataAnnotations.Schema;

namespace beltek.egazeloglu.Models
{
    [Table("tblOgrenciler")]
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public int OgrenciNumara { get; set; }
 
        public Sinif Sinif { get; set; }
        public int SinifId { get; set; }

    }
}
