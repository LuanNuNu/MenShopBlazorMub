namespace MenShopBlazor.DTOs.Collection.ViewModel
{
    public class ImageCollectionViewModel
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public string? FullPath { get; set; }
        public int CollectionId { get; set; }
        public CollectionViewModel? Collection { get; set; }
    }
}
