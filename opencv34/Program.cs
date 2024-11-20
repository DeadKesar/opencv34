using System;
using Tesseract;

class Program
{
    static void Main(string[] args)
    {
        
        string tesseractDataPath = @"D:\Program Files\Tesseract-OCR\tessdata"; // Папка с языковыми файлами
        string imagePath = @"D:\4\5.jpg"; // Путь к изображению

        // Убедитесь, что языковые файлы (например, eng.traineddata) находятся в tessdata
        Console.WriteLine("Начинаем распознавание текста...");

        try
        {
            using (var engine = new TesseractEngine(tesseractDataPath, "rus", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        Console.WriteLine("Распознанный текст:");
                        Console.WriteLine("--------------------");
                        Console.WriteLine(text);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
