namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Card
{
    public string CardID { get; set; } = Guid.NewGuid().ToString();
    public List<CardItem> CardItems { get; set; } = new List<CardItem>();

    //public void AddCardItem(CardItem cardItem)
    //{
    //    var hasCardItem = CardItems.FirstOrDefault(c => c.ProductID == cardItem.ProductID);
    //    if (hasCardItem.Quantity > cardItem.)
    //    {

    //    }
    //    if (hasCardItem is not null)
    //    {
    //        hasCardItem.Quantity += cardItem.Quantity;
    //    }
    //    else
    //    {
    //        CardItems.Add(cardItem);
    //    }
    //}

    //public void RemoveCardItem(string cardItemId)
    //{
    //    var hasCardItem = CardItems.FirstOrDefault(c => c.CardItemID.Equals(cardItemId));
    //    if (hasCardItem is not null)
    //    {
    //        if (hasCardItem.Quantity > 1)
    //        {
    //            hasCardItem.Quantity -= 1;
    //        }
    //        else
    //        {
    //            CardItems.Remove(hasCardItem);
    //        }
    //    }
    //}

    //public double TotalAmounth()
    //{
    //    return CardItems.Sum(c => c.TotalPrice);
    //}

    //public void ClearCard()
    //{
    //    CardItems.Clear();
    //}
    //public List<CardItem> GetAll()
    //{
    //    return CardItems;
    //}
}
