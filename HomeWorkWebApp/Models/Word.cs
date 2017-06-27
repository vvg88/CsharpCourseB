namespace HomeWorkWebApp.Models
{
    public class Word
    {
        public int Id { get; set; }
        public double TermFrequency { get; set; }
        public string Text { get; set; }

        public Word(string text, double tf)
        {
            Text = text;
            TermFrequency = tf;
        }

        public Word()
        {
            Text = string.Empty;
        }
    }
}
