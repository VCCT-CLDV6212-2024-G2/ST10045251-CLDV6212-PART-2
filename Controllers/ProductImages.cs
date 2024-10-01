using Microsoft.AspNetCore.Mvc;

namespace ST10045251_CLDV6212_POE.Controllers
{
    public class ProductImages : Controller
    {
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=st10045251cldstorage;AccountKey=QW4sgPQj7eDfXPnPQ4PquCVW7h4SeZj9q2iMfA02b/w4kZG/9sfcbqedrMTt23HE1SIQ4DO5ghfw+ASthvgcWw==;EndpointSuffix=core.windows.net";
            var blobService = new BlobService(storageConnectionString, "product-images");

            await blobService.UploadImageAsync(file, file.FileName);

            return RedirectToAction("Index");
        }
    }
}
