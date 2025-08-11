using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Collection.CreateandUpdate;
using MenShopBlazor.DTOs.Collection.ViewModel;
namespace MenShopBlazor.Services.Collection
{
    public interface ICollectionService
    {
        Task<ApiResponseModel<object>> AddCollection(CollectionCreateDTO dto);
        Task<ApiResponseModel<object>> UpdateCollection(int id, CollectionCreateDTO dto);
        Task<ApiResponseModel<object>> DeleteCollection(int id);

        Task<ApiResponseModel<CollectionViewModel>> GetCurrentCollection();
        Task<ApiResponseModel<List<CollectionViewModel>>> GetAllCollections();
        Task<ApiResponseModel<CollectionViewModel>> GetCollectionById(int id);

        Task<ApiResponseModel<List<CollectionDetailsViewModel>>> GetCollectionDetails(int collectionId);

        Task<ApiResponseModel<object>> AddCollectionDetail(CollectionDetailCreateDTO dto);
        Task<ApiResponseModel<object>> UpdateCollectionDetail(int detailId, CollectionDetailCreateDTO dto);
        Task<ApiResponseModel<object>> DeleteCollectionDetail(int detailId);
        Task<IEnumerable<ImageCollectionViewModel>> GetImageCollectonAsync(int collectionId);
        Task<ApiResponseModel<object>> DeleteImageCollectionAsync(int imageId);
        Task<List<CreateImageResponse>> AddImagesCollectionAsync(int collectionId, List<string> imageUrls);
        Task<ApiResponseModel<object>> UpdateStatus(int id);
    }

}