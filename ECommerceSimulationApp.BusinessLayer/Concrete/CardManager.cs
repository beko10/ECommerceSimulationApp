using ECommerceSimulationApp.BusinessLayer.Abstract;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Concrete;

public class CardManager : Card, ICardService
{
    public bool AddToCartItemWithCard(CardItem cardItem)
    {
        var hasExistingCardItem = CardItems.FirstOrDefault(c => c.ProductID == cardItem.ProductID);
        if (hasExistingCardItem is null)
        {
            CardItems.Add(cardItem);
            return true;
        }
        
        if(cardItem.Quantity + hasExistingCardItem.Quantity > cardItem.ProductStock)
        {
            return false;
        }

        hasExistingCardItem.Quantity += cardItem.Quantity;
        return true;
    }

    public IEnumerable<CardItem> GetAllCartItems()
    {
        return CardItems;
    }

    public bool RemoveFromCartItemWithCard(string cardItemId)
    {
        var hasCardItem = CardItems.FirstOrDefault(c => c.CardItemID == cardItemId);
        if (hasCardItem is null)
        {
            return false;
        }
        hasCardItem.Quantity -= 1;
        if (hasCardItem.Quantity  <= 0)
        {
            CardItems.Remove(hasCardItem);
        }
        return true;
    }
}
