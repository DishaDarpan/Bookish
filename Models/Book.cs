namespace bookish
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public string ImageUrl { get; set; }

    }
}
