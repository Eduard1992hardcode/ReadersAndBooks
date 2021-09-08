namespace ReadersAndBooks.Dto
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

     }
}
