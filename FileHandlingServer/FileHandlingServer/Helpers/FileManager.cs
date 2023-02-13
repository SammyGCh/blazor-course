using Microsoft.AspNetCore.Components.Forms;

namespace FileHandlingServer.Helpers
{
    public static class FileManager
    {
        public static async Task<string> SaveImageFile(IBrowserFile image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            SaveImageFileConfiguration configuration = new();

            IBrowserFile resizedImageFile = await image.RequestImageFileAsync(configuration.Format, configuration.MaxWidth, configuration.MaxHeight);

            byte[] buffer = new byte[resizedImageFile.Size];
            string filePath;
            try
            {
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);

                string justFileName = Path.GetFileNameWithoutExtension(image.Name);
                string newFileNameWithoutPath = $"{justFileName}-{DateTime.Now.Ticks}{configuration.Extension}";
                string fileName = $"{Environment.CurrentDirectory}\\files\\{newFileNameWithoutPath}";

                File.WriteAllBytes(fileName, buffer);

                filePath = $"files/{newFileNameWithoutPath}";
            }
            catch (Exception)
            {

                throw;
            }
            
            return filePath;
        }

        public static async Task<string> SaveImageFile(IBrowserFile image, SaveImageFileConfiguration configuration)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            IBrowserFile resizedImageFile = await image.RequestImageFileAsync(configuration.Format, configuration.MaxWidth, configuration.MaxHeight);

            byte[] buffer = new byte[resizedImageFile.Size];
            string filePath;
            try
            {
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);

                string justFileName = Path.GetFileNameWithoutExtension(image.Name);
                string newFileNameWithoutPath = $"{justFileName}-{DateTime.Now.Ticks}{configuration.Extension}";
                string fileName = $"{Environment.CurrentDirectory}\\files\\{newFileNameWithoutPath}";

                File.WriteAllBytes(fileName, buffer);

                filePath = $"files/{newFileNameWithoutPath}";
            }
            catch (Exception)
            {

                throw;
            }

            return filePath;
        }
    }
}
