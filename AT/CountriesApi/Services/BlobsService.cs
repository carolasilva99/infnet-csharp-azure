using AzureBlobs;

namespace CountriesApi.Services
{
    public static class BlobsService
    {
        public static async Task<string> UploadStateFlag(string base64)
        {
            var blob = new StateFlagsBlob();

            return await blob.AddBlobToContainer(base64);
        }
    }
}
