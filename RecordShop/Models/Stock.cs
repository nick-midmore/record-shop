﻿namespace RecordShop.Models;

public class Stock
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public int Quantity { get; set; }
    public Album Album { get; set; }
}