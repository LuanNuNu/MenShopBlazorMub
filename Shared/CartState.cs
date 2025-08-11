
using MenShopBlazor.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;

public class CartState
{
    private List<CartDetailViewModel> _items = new();

    public IReadOnlyList<CartDetailViewModel> Items => _items.AsReadOnly();

    public event Action? OnChange;

    public void SetItems(List<CartDetailViewModel> items)
    {
        _items = items ?? new List<CartDetailViewModel>();
        NotifyStateChanged();
    }

    public void AddItem(CartDetailViewModel item)
    {
        _items.Add(item);
        NotifyStateChanged();
    }

    public void RemoveItem(CartDetailViewModel item)
    {
        _items.Remove(item);
        NotifyStateChanged();
    }

    public void UpdateQuantity(int productDetailId, int newQuantity)
    {
        var item = _items.FirstOrDefault(x => x.DetailId == productDetailId);
        if (item != null)
        {
            item.Quantity = newQuantity;
            NotifyStateChanged();
        }
    }

    public decimal TotalPrice => _items.Sum(x => (x.SellPrice ?? 0) * (x.Quantity ?? 0));
    public int TotalQuantity => _items.Sum(x => x.Quantity ?? 0);

    private void NotifyStateChanged() => OnChange?.Invoke();
}
