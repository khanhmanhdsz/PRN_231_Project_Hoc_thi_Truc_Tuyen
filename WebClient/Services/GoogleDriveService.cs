using WebClient.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WebClient.Services
{
    public class GoogleDriveService
    {
        private string _rootFolderId = "";
        private string _credentialsJson = "";
        private static string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveAppdata };
        private static string applicationName = "Online_Exam";

        private readonly IConfiguration _configuration;

        public GoogleDriveService(IConfiguration configuration)
        {
            _configuration = configuration;
            _credentialsJson = JsonConvert.SerializeObject(_configuration.GetSection("GoogleDriver:Credentials").Get<CredentialsSettings>());
            _rootFolderId = _configuration.GetValue<string>("GoogleDriver:RootFolderId");
        }

        public DriveService GetService()
        {
            try
            {
                GoogleCredential credential = GoogleCredential.FromJson(_credentialsJson).CreateScoped(Scopes);

                // Create the Drive service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName,
                });

                return service;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<string> UploadFile(byte[] fileData, string contentType, string fileName, string folderPath)
        {
            try
            {
                // Create a Drive service using the loaded credentials
                var service = GetService();

                // Split the folderPath into individual folder names
                string[] folderParts = folderPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Declare folder id
                string folderId = String.Empty;

                // Assign the root folder id
                string parentFolderId = _rootFolderId;

                // Iterate through each folder part in the folderPath
                foreach (string folderName in folderParts)
                {
                    // Get or create the folder with the current folderName inside the parentFolderId
                    folderId = await GetFolderIdByNameInFolder(service, folderName, parentFolderId);

                    if (String.IsNullOrEmpty(folderId))
                    {
                        // If the folder doesn't exist, create it inside the parentFolderId
                        folderId = await CreateFolderInsideFolder(service, folderName, parentFolderId);
                    }
                    else
                    {
                        // If the folder already exists, check if it's in the correct parent folder
                        if (!IsFolderInParentFolder(service, parentFolderId, folderId))
                        {
                            // If not, delete it, and recreate it in the correct parent folder
                            bool deleteStatus = DeleteFolderById(service, folderId);
                            folderId = await CreateFolderInsideFolder(service, folderName, parentFolderId);

                            Console.WriteLine($"Delete exist folder status: {deleteStatus}");
                        }
                    }

                    // Set the current folderId as the parentFolderId for the next iteration
                    parentFolderId = folderId;
                }

                // Get the file ID if it exists in the final folder
                string existFileId = await GetFileIdByNameInFolder(service, fileName, folderId);

                if (!String.IsNullOrEmpty(existFileId))
                {
                    // If the file exists, delete it
                    bool deleteStatus = await DeleteFileById(service, existFileId);
                    Console.WriteLine($"Delete exist file status: {deleteStatus}");
                }

                // Create metadata for the file to be uploaded
                Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName, // Use the file name from IFormFile
                    Parents = new List<string> { folderId }, // Set the parent folder
                };

                // Create a stream to read the file data
                using (var stream = new MemoryStream(fileData))
                {
                    // Create a request to upload the file
                    var request = service.Files.Create(fileMetadata, stream, contentType);
                    await request.UploadAsync();

                    // Handle the response
                    var uploadedFile = request.ResponseBody;
                    if (uploadedFile != null)
                    {
                        // File uploaded successfully, get the file ID
                        string fileId = uploadedFile.Id;

                        // Construct the shareable link
                        string shareableLink = $"https://drive.google.com/uc?id={fileId}";

                        Console.WriteLine("ShareableLink: " + shareableLink);
                        // Return the shareable link
                        return shareableLink;
                    }
                    else
                    {
                        throw new Exception("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while uploading file to google driver: " + ex.Message);
                return null;
            }
        }

        public async Task<string> UploadFile(IFormFile file, string fileName, string folderPath)
        {
            try
            {
                // Create a Drive service using the loaded credentials
                var service = GetService();

                // Split the folderPath into individual folder names
                string[] folderParts = folderPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Declare folder id
                string folderId = String.Empty;

                // Assign the root folder id
                string parentFolderId = _rootFolderId;

                // Iterate through each folder part in the folderPath
                foreach (string folderName in folderParts)
                {
                    // Get or create the folder with the current folderName inside the parentFolderId
                    folderId = await GetFolderIdByNameInFolder(service, folderName, parentFolderId);

                    if (String.IsNullOrEmpty(folderId))
                    {
                        // If the folder doesn't exist, create it inside the parentFolderId
                        folderId = await CreateFolderInsideFolder(service, folderName, parentFolderId);
                    }
                    else
                    {
                        // If the folder already exists, check if it's in the correct parent folder
                        if (!IsFolderInParentFolder(service, parentFolderId, folderId))
                        {
                            // If not, delete it, and recreate it in the correct parent folder
                            bool deleteStatus = DeleteFolderById(service, folderId);
                            folderId = await CreateFolderInsideFolder(service, folderName, parentFolderId);

                            Console.WriteLine($"Delete exist folder status: {deleteStatus}");
                        }
                    }

                    // Set the current folderId as the parentFolderId for the next iteration
                    parentFolderId = folderId;
                }

                // Get the file ID if it exists in the final folder
                string existFileId = await GetFileIdByNameInFolder(service, fileName, folderId);

                if (!String.IsNullOrEmpty(existFileId))
                {
                    // If the file exists, delete it
                    bool deleteStatus = await DeleteFileById(service, existFileId);
                    Console.WriteLine($"Delete exist file status: {deleteStatus}");
                }

                // Create metadata for the file to be uploaded
                Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName, // Use the file name from IFormFile
                    Parents = new List<string> { folderId }, // Set the parent folder
                };

                // Create a stream to read the file data
                using (var stream = file.OpenReadStream())
                {
                    // Create a request to upload the file
                    var request = service.Files.Create(fileMetadata, stream, file.ContentType);
                    await request.UploadAsync();

                    // Handle the response
                    var uploadedFile = request.ResponseBody;
                    if (uploadedFile != null)
                    {
                        // File uploaded successfully, get the file ID
                        string fileId = uploadedFile.Id;

                        // Construct the shareable link
                        string shareableLink = $"https://drive.google.com/uc?id={fileId}";

                        Console.WriteLine("ShareableLink: " + shareableLink);
                        // Return the shareable link
                        return shareableLink;
                    }
                    else
                    {
                        throw new Exception("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while uploading file to google driver: " + ex.Message);
                return null;
            }
        }

        public async Task<string> UploadFileToRootFolder(IFormFile file, string fileName)
        {
            try
            {
                // Create a Drive service using the loaded credentials
                var service = GetService();

                // Create metadata for the file to be uploaded
                Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName, // Use the file name from IFormFile
                    Parents = new List<string> { _rootFolderId },
                };

                // Create a stream to read the file data
                using (var stream = file.OpenReadStream())
                {
                    // Create a request to upload the file
                    var request = service.Files.Create(fileMetadata, stream, file.ContentType);
                    await request.UploadAsync();

                    // Handle the response
                    var uploadedFile = request.ResponseBody;
                    if (uploadedFile != null)
                    {
                        // File uploaded successfully, get the file ID
                        string fileId = uploadedFile.Id;

                        // Construct the shareable link
                        string shareableLink = $"https://drive.google.com/uc?id={fileId}";

                        Console.WriteLine("ShareableLink: " + shareableLink);
                        // Return the shareable link
                        return shareableLink;
                    }
                    else
                    {
                        // Handle the error
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<string> GetFileIdsByLinks(List<string> links)
        {
            List<string> fileIds = new List<string>();
            foreach (string link in links)
            {
                fileIds.Add(ExtractFileIdFromUrl(link));
            }

            return fileIds;
        }

        public string GetShareableLinkByFileId(string fileId)
        {
            return $"https://drive.google.com/uc?id={fileId}";
        }



        public static string ExtractFileIdFromUrl(string url)
        {
            try
            {
                // Define a regular expression pattern to match the fileId in the URL
                string pattern = @"https://drive\.google\.com/uc\?id=(?<fileId>[^&]+)";

                // Use regex to match the fileId
                Match match = Regex.Match(url, pattern);

                if (match.Success)
                {
                    // Extract and return the fileId from the matched group
                    string fileId = match.Groups["fileId"].Value;
                    return fileId;
                }
                else
                {
                    // If no match is found, return null or an empty string
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public string GetPreviewLink(string url)
        {
            try
            {
                // Define a regular expression pattern to match the fileId in the URL
                string pattern = @"https://drive\.google\.com/uc\?id=(?<fileId>[^&]+)";

                // Use regex to match the fileId
                Match match = Regex.Match(url, pattern);

                if (match.Success)
                {
                    // Extract and return the fileId from the matched group
                    string fileId = match.Groups["fileId"].Value;

                    return $"https://drive.google.com/file/d/{fileId}/preview";
                }
                else
                {
                    // If no match is found, return null or an empty string
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        public string GetExportFileUrl(string url)
        {
            try
            {
                // Define a regular expression pattern to match the fileId in the URL
                string pattern = @"https://drive\.google\.com/uc\?id=(?<fileId>[^&]+)";

                // Use regex to match the fileId
                Match match = Regex.Match(url, pattern);

                if (match.Success)
                {
                    // Extract and return the fileId from the matched group
                    string fileId = match.Groups["fileId"].Value;

                    return $"https://drive.google.com/uc?export=view&id={fileId}";
                }
                else
                {
                    // If no match is found, return null or an empty string
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public void RemoveFilesByIds(List<string> fileIds)
        {
            try
            {
                DriveService service = GetService();
                foreach (var fileId in fileIds)
                {
                    // Delete the file by its ID
                    FilesResource.DeleteRequest deleteRequest = service.Files.Delete(fileId);
                    deleteRequest.Execute();

                    Console.WriteLine($"File with ID '{fileId}' has been deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<bool> MoveFilesToFolderPath(List<string> fileIds, string folderPath)
        {
            try
            {
                DriveService service = GetService();

                // Split the folder path into individual folder names
                string[] folderNames = folderPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Start with the root folder ID
                string parentFolderId = _rootFolderId;

                foreach (string folderName in folderNames)
                {
                    // Get or create the folder with the current folderName inside the parentFolderId
                    parentFolderId = GetOrCreateFolderIdByNameInFolder(service, folderName, parentFolderId);

                    if (string.IsNullOrEmpty(parentFolderId))
                    {
                        Console.WriteLine($"Folder creation failed for: {folderName}");
                    }
                }

                // Move each file to the final folder (parentFolderId)
                foreach (string fileId in fileIds)
                {

                    var file = await service.Files.Get(fileId).ExecuteAsync();
                    if (file.Parents == null)
                    {
                        file.Parents = new List<string>();
                    }

                    var currentParents = string.Join(",", file.Parents);

                    // Remove the file from its current parents
                    var updateRequest = service.Files.Update(new Google.Apis.Drive.v3.Data.File(), fileId);
                    updateRequest.RemoveParents = currentParents;
                    await updateRequest.ExecuteAsync();

                    // Add the file to the new parent folder
                    updateRequest = service.Files.Update(new Google.Apis.Drive.v3.Data.File(), fileId);
                    updateRequest.AddParents = parentFolderId;
                    await updateRequest.ExecuteAsync();


                    Console.WriteLine($"Move file: {fileId} to new folder successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            return true;
        }

        private string GetOrCreateFolderIdByNameInFolder(DriveService service, string folderName, string parentFolderId)
        {
            try
            {
                // Search for the folder by name within the current parent folder
                var request = service.Files.List();
                request.Q = $"name = '{folderName}' and '{parentFolderId}' in parents and mimeType = 'application/vnd.google-apps.folder'";
                var result = request.Execute();
                var folder = result.Files.FirstOrDefault();

                if (folder != null)
                {
                    return folder.Id; // Folder exists; return its ID
                }
                else
                {
                    // Folder does not exist; create it inside the parentFolderId
                    var newFolder = new Google.Apis.Drive.v3.Data.File
                    {
                        Name = folderName,
                        MimeType = "application/vnd.google-apps.folder",
                        Parents = new List<string> { parentFolderId }
                    };

                    var createRequest = service.Files.Create(newFolder);
                    createRequest.Fields = "id";
                    var createdFolder = createRequest.Execute();

                    return createdFolder.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting/creating folder by name: {ex.Message}");
                return null;
            }
        }

        public async Task<string> CreateFolderInsideFolder(DriveService service, string folderName, string parentFolderId)
        {
            try
            {
                // Create the folder.
                var folder = new Google.Apis.Drive.v3.Data.File
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                    Parents = new List<string> { parentFolderId }
                };

                var request = service.Files.Create(folder);
                request.Fields = "id";

                var folderFile = await request.ExecuteAsync();

                // Share the folder with all users within the organization.
                ShareFolderWithOrganization(service, folderFile.Id, "reader");

                return folderFile.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public void ShareFolderWithOrganization(DriveService service, string folderId, string role)
        {
            try
            {
                // Create the permission object.
                var newPermission = new Permission()
                {
                    Type = "anyone",
                    Role = role, // e.g., "reader", "writer", "commenter", "owner"
                };

                // Insert the new permission.
                var request = service.Permissions.Create(newPermission, folderId);
                request.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<string> GetFolderIdByNameInFolder(DriveService service, string folderName, string parentFolderId)
        {
            try
            {
                // Define the request parameters
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Q = $"name='{folderName}' and '{parentFolderId}' in parents and mimeType='application/vnd.google-apps.folder'";
                listRequest.Fields = "files(id)";

                // Execute the request and get a list of matching folders
                FileList files = await listRequest.ExecuteAsync();

                // Check if any folders were found
                if (files.Files != null && files.Files.Count > 0)
                {
                    // Return the ID of the first matching folder (assuming unique names)
                    return files.Files[0].Id;
                }
                else
                {
                    // Folder not found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> GetFileIdByNameInFolder(DriveService service, string fileName, string folderId)
        {
            try
            {
                // Define the request parameters
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Q = $"name='{fileName}' and '{folderId}' in parents";
                listRequest.Fields = "files(id)";

                // Execute the request and get a list of matching files
                FileList files = await listRequest.ExecuteAsync();

                // Check if any files were found
                if (files.Files != null && files.Files.Count > 0)
                {
                    // Return the ID of the first matching file (assuming unique names)
                    return files.Files[0].Id;
                }
                else
                {
                    // File not found in the specified folder
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteFileById(DriveService service, string fileId)
        {
            try
            {


                // Delete the file
                FilesResource.DeleteRequest deleteRequest = service.Files.Delete(fileId);
                await deleteRequest.ExecuteAsync();

                // If execution reaches here, the file has been successfully deleted
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeleteFolderById(DriveService service, string folderId)
        {
            try
            {
                // Delete the folder by its ID
                service.Files.Delete(folderId).Execute();

                // If execution reaches here, the folder has been successfully deleted
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool IsFolderInParentFolder(DriveService service, string parentFolderId, string folderIdToCheck)
        {
            try
            {
                // List all files and folders within the parent folder (specified by parentFolderId)
                var listRequest = service.Files.List();
                listRequest.Q = $"'{parentFolderId}' in parents";
                listRequest.Fields = "files(id)";
                var files = listRequest.Execute().Files;

                if (files != null)
                {
                    // Check if folderIdToCheck is among the child folder IDs
                    foreach (var file in files)
                    {
                        if (file.Id == folderIdToCheck)
                        {
                            // The folder with folderIdToCheck exists within the parent folder
                            return true;
                        }
                    }
                }

                // The folder with folderIdToCheck does not exist within the parent folder
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

    }
}
