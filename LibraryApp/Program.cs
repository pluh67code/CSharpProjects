bool exited = false;

while (!exited) {
    Console.WriteLine("=== Library ===");
}

class Book {
    public string Name { get; private set; }
    public string Author { get; private set; }
    public int Pages { get; private set; }

    public Book(string name, string author, int pages) {
        Name = name;
        Author = author;
        Pages = pages;
    }
}

class Library {
    private List<Book> books;

    public bool AddBook(Book bookToAdd) {
        foreach (Book book in books) {
            if (bookToAdd.Name == book.Name) {
                return false;
            }
        }
       
        books.Add(bookToAdd);
        return true;
    }



    public void 
}