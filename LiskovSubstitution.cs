namespace EndToEndSamples.SOLID
{
    public class Rectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Square : Rectangle
    {
        
    }

    public class Tester
    {
        public Tester()
        {
            Square s = new Square();
            s.Height = 100;
            s.Width = 200;
        }
    }
}