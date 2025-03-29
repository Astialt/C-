using System;

namespace PhotoAppWithFilters
{
    public interface IImage
    {
        string GetDescription(); 
        IImage Process(); 
    }

    public class BaseImage : IImage
    {
        public string GetDescription()
        {
            return "Оригинальное изображение";
        }

        public IImage Process()
        {
            Console.WriteLine("Обработка оригинального изображения завершена.");
            return this;
        }
    }

    public abstract class ImageDecorator : IImage
    {
        private readonly IImage _image;

        public ImageDecorator(IImage image)
        {
            _image = image;
        }

        public virtual string GetDescription()
        {
            return _image.GetDescription();
        }

        public virtual IImage Process()
        {
            return _image.Process();
        }
    }

    public class BlackWhiteFilterDecorator : ImageDecorator
    {
        public BlackWhiteFilterDecorator(IImage image) : base(image) { }

        public override string GetDescription()
        {
            return base.GetDescription() + " + Черно-белый фильтр";
        }

        public override IImage Process()
        {
            base.Process();
            Console.WriteLine("Применён черно-белый фильтр.");
            return this;
        }
    }

    public class BlurFilterDecorator : ImageDecorator
    {
        public BlurFilterDecorator(IImage image) : base(image) { }

        public override string GetDescription()
        {
            return base.GetDescription() + " + Размытие";
        }

        public override IImage Process()
        {
            base.Process();
            Console.WriteLine("Применено размытие.");
            return this;
        }
    }

    public class SharpenFilterDecorator : ImageDecorator
    {
        public SharpenFilterDecorator(IImage image) : base(image) { }

        public override string GetDescription()
        {
            return base.GetDescription() + " + Резкость";
        }

        public override IImage Process()
        {
            base.Process();
            Console.WriteLine("Применена резкость.");
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IImage baseImage = new BaseImage();

            IImage blackWhiteImage = new BlackWhiteFilterDecorator(baseImage);

            IImage blurredImage = new BlurFilterDecorator(blackWhiteImage);

            IImage finalImage = new SharpenFilterDecorator(blurredImage);

            Console.WriteLine("Описание изображения: " + finalImage.GetDescription());

            Console.WriteLine("\nНачало обработки:");
            finalImage.Process();

            Console.WriteLine("\nОбработка завершена.");
        }
    }
}
