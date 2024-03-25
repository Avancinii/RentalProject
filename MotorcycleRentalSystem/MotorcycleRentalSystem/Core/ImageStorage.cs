namespace MotorcycleRentalSystem.Core
{
    public class ImageStorage
    {
        public static string SaveImage(byte[] imageData, string directoryPath, string fileName)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            try
            {
                // Salva a imagem no arquivo no diretório especificado
                File.WriteAllBytes(filePath, imageData);
                return filePath; // Retorna o caminho completo do arquivo salvo
            }
            catch (Exception ex)
            {
                // Lidar com qualquer erro de salvamento
                Console.WriteLine($"Erro ao salvar a imagem: {ex.Message}");
                return null;
            }
        }
    }
}
