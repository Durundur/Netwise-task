namespace netwise_task.Services
{
    public class FileService
    {
        public async Task AppendToFileAsync(string text, string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException(nameof(text), "Text cannot be null or whitespace.");
                }

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null or whitespace.");
                }

                using (StreamWriter writer = File.AppendText(filePath))
                {
                    await writer.WriteLineAsync(text);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Access denied to file.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing to file.", ex);
            }
        }
    }
}