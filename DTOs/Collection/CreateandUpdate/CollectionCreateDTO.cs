using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Collection.CreateandUpdate
{
    public class CollectionCreateDTO
    {
        [Required(ErrorMessage = "Tên bộ sưu tập không được để trống")]
        public string CollectionName { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]

        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Status { get; set; }
    }
}
