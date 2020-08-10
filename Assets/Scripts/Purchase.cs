using UnityEngine;

public class Purchase : MonoBehaviour
{
    public void PurchaseButton()
    {
        IAPManager.instance.BuyNonConsumable();
    }
}
