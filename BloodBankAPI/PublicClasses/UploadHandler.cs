namespace BloodBankAPI.PublicClasses
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return "File was not valid";
            }
            //File Size
            long size = file.Length;    
            if (size > (5 * 1024 * 1024))
                return "Maximum Size can be 5mb";
            //Name changing
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream fileStream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
