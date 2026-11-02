using SphinxConnector.FluentApi;

IFulltextStore fulltextStore;

SetupFulltextStore();
InsertDocument();
ExecuteQuery();

return;

void SetupFulltextStore()
{
    //No further setup is required for this example
    //We're using the default conventions and SphinxConnector.NET will connect to Sphinx on localhost if no connection string is given
    fulltextStore = new FulltextStore().Initialize();
}

void InsertDocument()
{
    Console.WriteLine("Inserting document...");
    
    using var session = fulltextStore.StartSession();
    session.Save(new Book
                 {
                     Id = 1,
                     Author = "George R.R. Martin",
                     Title = "A Game of Thrones: A Song of Ice and Fire: Book One",
                     EbookAvailable = true,
                     Categories = [1, 2],
                     Price = 5.60m,
                     ReleaseDate = new DateTime(1997, 8, 4)
                 });

    session.FlushChanges();
}

void ExecuteQuery()
{
    Console.WriteLine("Executing query...");
    
    using var session = fulltextStore.StartSession();
    var results = session.Query<Book>().
                          Match("@author Martin @* A Song of Ice and Fire").
                          Where(x => x.EbookAvailable).
                          OrderBy(x => x.Price).
                          Select(x => new { x.Title, x.Price }).
                          ToList();

    foreach (var result in results)
    {
        Console.WriteLine("{0}\t{1}", result.Title, result.Price);
    }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public bool EbookAvailable { get; set; }
    public DateTime ReleaseDate { get; set; }

    public int[] Categories { get; set; }
    public int Weight { get; set; }
}
