using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener //для получения сообщений из Unity Purchasing
{
    [SerializeField] private GameObject panelAds;
    [SerializeField] private GameObject panelAds_Done;

    IStoreController m_StoreController;

    public static string noads = "com.gamesdmurdock.mountainhook.noads"; //одноразовые - nonconsumable
    public static string Coins_1 = "com.gamesdmurdock.mountainhook.coins_1"; //многоразовые - consumable
    public static string Coins_2 = "com.gamesdmurdock.mountainhook.coins_2"; //многоразовые - consumable
    public static string Coins_3 = "com.gamesdmurdock.mountainhook.coins_3"; //многоразовые - consumable

    void Start()
    {
        InitializePurchasing();

        if (PlayerPrefs.HasKey("ads") == true)
        {
            panelAds.SetActive(false);
            panelAds_Done.SetActive(true);
        }
        else
        {
            panelAds.SetActive(true);
            panelAds_Done.SetActive(false);
        }
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Прописываем свои товары для добавления в билдер
        builder.AddProduct(noads, ProductType.NonConsumable);
        builder.AddProduct(Coins_1, ProductType.Consumable);
        builder.AddProduct(Coins_2, ProductType.Consumable);
        builder.AddProduct(Coins_3, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProduct(string productName)
    {
        m_StoreController.InitiatePurchase(productName);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        var product = args.purchasedProduct;

        if (product.definition.id == noads)
        {
            Product_NoAds();
        }

        if (product.definition.id == Coins_1)
        {
            Product_coins_1();
        }

        if (product.definition.id == Coins_2)
        {
            Product_coins_2();
        }

        if (product.definition.id == Coins_3)
        {
            Product_coins_3();
        }

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        return PurchaseProcessingResult.Complete;
    }

    private void Product_NoAds()
    {
        if (PlayerPrefs.HasKey("ads") == false)
        {
            panelAds.SetActive(false);
            panelAds_Done.SetActive(true);

            PlayerPrefs.SetInt("ads", 1);
        }
    }

    private void Product_coins_1()
    {
        PlayerPrefs.SetInt("Coin_b", 500);
    }
    private void Product_coins_2()
    {
        PlayerPrefs.SetInt("Coin_b", 1500);
    }
    private void Product_coins_3()
    {
        PlayerPrefs.SetInt("Coin_b", 5000);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }

}
