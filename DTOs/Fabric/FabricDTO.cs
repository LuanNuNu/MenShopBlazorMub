using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Fabric
{
    public class FabricDTO
    {
        public int FabricId { get; set; }
        [Required(ErrorMessage = "Tên chất liệu không được để trống")]
        public string? Name { get; set; }
    }
}
