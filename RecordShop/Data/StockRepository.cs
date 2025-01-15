using Microsoft.EntityFrameworkCore;
using RecordShop.Models.Entities;

namespace RecordShop.Data;

public class StockRepository(ShopContext context)
{
    private readonly ShopContext _context = context;
    public List<Stock>? GetStock()
        => _context.Stock
        .Include(s => s.Album)
        .ToList();

    public Stock? GetStockById(int id)
        => GetStock().FirstOrDefault(s => s.Id == id);

    public Stock? UpdateStock(int id, int quantity)
    {
        var stock = GetStockById(id);
        stock.Quantity += quantity;
        _context.SaveChanges();
        return stock;
    }
}