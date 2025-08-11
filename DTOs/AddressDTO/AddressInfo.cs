namespace MenShopBlazor.DTOs.AddressDTO
{
    public class AddressInfo
    {
        public int? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }

        public int? WardId { get; set; }
        public string? WardName { get; set; }

        public string? Street { get; set; }

        public string FullAddress =>
            $"{Street ?? ""}, {WardName ?? ""}, {DistrictName ?? ""}, {ProvinceName ?? ""}".Trim(' ', ',');
    }

}
