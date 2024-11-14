using static System.Net.Mime.MediaTypeNames;

namespace ImageGenerationAPI.Class
{
    public class SavedImage
    {
        private string ImageCode;
        public SavedImage(string image)
        { 
            ImageCode = image;
        }
        public void Save()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ "\\Image.jpeg";
            byte[] imageBytes = Convert.FromBase64String(ImageCode);
            using (var imageFile = new FileStream(path, FileMode.OpenOrCreate))
            {
                imageFile.Write(imageBytes, 0, imageBytes.Length);
                imageFile.Flush();
            }
        }
    }
}
