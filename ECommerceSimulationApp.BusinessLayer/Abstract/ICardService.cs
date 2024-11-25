using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface ICardService
{
    bool AddToCartItemWithCard(CardItem cardItem);
    bool RemoveFromCartItemWithCard(string cardItemId);
    IEnumerable<CardItem> GetAllCartItems();
}
