namespace MenShopBlazor.Services.UploadImage
{
    public interface IUpImg
    {
        Task<string> UploadImage(MultipartFormDataContent content);
    }
}
