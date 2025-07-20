using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Product;
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Product.UpdateProduct;


namespace MenShopBlazor.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel?> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductDetailViewModel>> GetProductDetailsAsync(int productId);
        Task<IEnumerable<ImageProductViewModel>> GetImageProductDetailsAsync(int productDetailId);
        Task<IEnumerable<ProductViewModel>> GetProductsByCategoryIdAsync(int categoryId);

        Task<ProductResponseDTO?> CreateProductAsync(CreateProductDTO dto);
        Task<CreateProductDetailResponse> AddProductDetailsAsync(AddProductDetailDTO dto);
        Task<List<CreateImageResponse>> AddImagesToDetailAsync(int detailId, List<string> imageUrls);


        Task<ProductResponseDTO?> UpdateProductAsync(int productId, UpdateProductDTO dto);
        Task<ProductDetailResponse> UpdateProductDetailAsync(UpdateProductDetailDTO dto);
        Task<ImageResponse> UpdateProductDetailImagesAsync(int detailId, List<UpdateImageDTO> images);

        Task<ApiResponseModel<object>> ToggleProductStatusAsync(int productId);
        Task<ApiResponseModel<object>> DeleteProductAsync(int productId);
        Task<ApiResponseModel<object>> DeleteProductDetailAsync(int detailId);
        Task<ApiResponseModel<object>> DeleteImageProductDetailAsync(int imageId);

    }
}
