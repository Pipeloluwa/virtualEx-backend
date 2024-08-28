using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace virtual_ex.ControllerServices
{
    public interface IPictureAndVideoUploadService
    {
        Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave);
        Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes);
        Task DeleteFileAsync(string fileNameToDelete);

    }





    public class PictureAndVideoUploadService: IPictureAndVideoUploadService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<PictureAndVideoUploadService> logger;
        private readonly GoogleCredential googleCredential;



        public PictureAndVideoUploadService(IConfiguration _configuration, ILogger<PictureAndVideoUploadService> _logger)
        {
            configuration = _configuration;
            logger = _logger;

            try
            {
                googleCredential = GoogleCredential.FromFile(configuration["GoogleCloudStorage:GCPStorageAuthFile"]);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }




        public async Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await fileToUpload.CopyToAsync(memoryStream);

                // Creating Storage Client with Google Credential
                using var storageClient = StorageClient.Create(googleCredential);
                logger.LogInformation($"Uploading file: {fileToUpload.FileName}");

                string fileNameToSaveGuid= Guid.NewGuid().ToString() + fileNameToSave;

                var uploadedFile = await storageClient.UploadObjectAsync
                    (
                        configuration["GoogleCloudStorage:GoogleCloudStorageBucket"],
                        fileNameToSaveGuid,
                        fileToUpload.ContentType,
                        memoryStream
                    );

                logger.LogInformation("File Uploaded Successfully");

                return uploadedFile.MediaLink.ToString();
            }


            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }



        public async Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30)
        {
            try
            {
                var serviceAccountCredential = googleCredential.UnderlyingCredential as ServiceAccountCredential;
                var urlSigner= UrlSigner.FromCredential(serviceAccountCredential);

                //limited permission time for 30 minutes
                var signedUrl = await urlSigner.SignAsync
                    (
                        configuration["GoogleCloudStorage:GoogleCloudStorageBucket"],
                        fileNameToRead,
                        TimeSpan.FromMinutes(timeOutInMinutes)
                    );

                logger.LogInformation($"Sign Url Generated Successfully: {signedUrl}!");

                return signedUrl.ToString();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }



        public async Task DeleteFileAsync(string fileNameToDelete)
        {
            try
            {
                using var storageClient = StorageClient.Create(googleCredential);
                await storageClient.DeleteObjectAsync
                    (
                        configuration["GoogleCloudStorage:GoogleCloudStorageBucket"],
                        fileNameToDelete
                    );

                logger.LogInformation($"{fileNameToDelete} deleted successfully!");

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
