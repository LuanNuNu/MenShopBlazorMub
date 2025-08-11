namespace MenShopBlazor.DTOs.AddressDTO
{
    public class AddressDTO
    {
        public class ProvinceDTO
        {
            public int Code { get; set; }
            public string Name { get; set; }
        }

        public class DistrictDTO
        {
            public int Code { get; set; }
            public string Name { get; set; }
        }

        public class WardDTO
        {
            public int Code { get; set; } 
            public string Name { get; set; }
        }

        public class ProvinceDetailDto
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public List<DistrictDTO> Districts { get; set; } = new();
        }

        public class DistrictDetailDto
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public List<WardDTO> Wards { get; set; } = new();
        }

    }
}
