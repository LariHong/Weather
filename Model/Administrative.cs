using System.ComponentModel.DataAnnotations;

namespace Weather.Model
{
    //行政區資料
    public class AdministrativeData
    {
        [Required]
        public string Country {  get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Administrative { get; set; }
    }
}
