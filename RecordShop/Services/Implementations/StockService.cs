using RecordShop.Data;
using RecordShop.Models.Entities;
using RecordShop.Services.Interfaces;

namespace RecordShop.Services.Implementations;

public class StockService(StockRepository repo, AlbumRepository albumRepo) : IStockService
{
    private readonly StockRepository _repo = repo;
    private readonly AlbumRepository _albumRepo = albumRepo;

    public List<Stock>? GetStock()
        => _repo.GetStock();

    public Stock? GetStockById(int id)
        => _repo.GetStockById(id);

    public Stock? UpdateStock(int id, int quantity)
    {
        var stock = _repo.GetStockById(id);
        if (stock == null || stock.Quantity + quantity < 0) return null;

        _repo.UpdateStock(id, quantity);
        return stock;
    }
}