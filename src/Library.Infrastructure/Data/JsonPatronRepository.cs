using Library.ApplicationCore;
using Library.ApplicationCore.Entities;

namespace Library.Infrastructure.Data;

public class JsonPatronRepository : IPatronRepository
{
    private readonly JsonData _jsonData;

    public JsonPatronRepository(JsonData jsonData)
    {
        _jsonData = jsonData;
    }

    public async Task<List<Patron>> SearchPatrons(string searchInput)
    {
        await _jsonData.EnsureDataLoaded();

        List<Patron> searchResults = new List<Patron>();
        foreach (Patron patron in _jsonData.Patrons)
        {
            if (patron.Name.Contains(searchInput))
            {
                searchResults.Add(patron);
            }
        }
        searchResults.Sort((p1, p2) => String.Compare(p1.Name, p2.Name));

        searchResults = _jsonData.GetPopulatedPatrons(searchResults);

        return searchResults;
    }

    public async Task<Patron?> GetPatron(int id)
    {
        await _jsonData.EnsureDataLoaded();

        foreach (Patron patron in _jsonData.Patrons!)
        {
            if (patron.Id == id)
            {
                Patron populated = _jsonData.GetPopulatedPatron(patron);
                return populated;
            }
        }
        return null;
    }

    public async Task UpdatePatron(Patron patron)
    {
        await _jsonData.EnsureDataLoaded();
        var patrons = _jsonData.Patrons!;
        Patron existingPatron = null;
        foreach (var p in patrons)
        {
            if (p.Id == patron.Id)
            {
                existingPatron = p;
                break;
            }
        }
        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.ImageName = patron.ImageName;
            existingPatron.MembershipStart = patron.MembershipStart;
            existingPatron.MembershipEnd = patron.MembershipEnd;
            existingPatron.Loans = patron.Loans;
            await _jsonData.SavePatrons(patrons);
            await _jsonData.LoadData();
        }
    }

    public async Task<List<Book>> SearchBooks(string searchInput)
    {
        await _jsonData.EnsureDataLoaded();

        List<Book> searchResults = new List<Book>();
        foreach (Book book in _jsonData.Books)
        {
            if (book.Title.Contains(searchInput, StringComparison.OrdinalIgnoreCase))
            {
                searchResults.Add(book);
            }
        }

        searchResults.Sort((b1, b2) => string.Compare(b1.Title, b2.Title, StringComparison.OrdinalIgnoreCase));

        return searchResults;
    }
}
