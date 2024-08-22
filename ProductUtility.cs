using JetBrains.Annotations;

namespace BetterPriceSetter;

public class ProductUtility
{
    public static float GetMarketPrice(int productId)
    {
        var product = GetProduct(productId);
        var multiplier = GetInflationMultiplier(productId);
        if (product == null)
            return 0f;

        return product.basePricePerUnit * multiplier;
    }
    
    public static float GetInflationMultiplier(int productId)
    {
        var product = GetProduct(productId);

        if (product == null)
            return 1f;
        
        float inflationMultiplier = ProductListing.Instance.tierInflation[product.productTier];
        return inflationMultiplier;
    }

    public static Data_Product? GetProduct(int productId)
    {
        if (productId < 0 || productId >= ProductListing.Instance.productPrefabs.Length)
        {
            return null;
        }
        
        return ProductListing.Instance.productPrefabs[productId].GetComponent<Data_Product>();
    }

    public static void SetPrice(int productId, float price)
    {
        ProductListing.Instance.CmdUpdateProductPrice(productId, price);
    }
}