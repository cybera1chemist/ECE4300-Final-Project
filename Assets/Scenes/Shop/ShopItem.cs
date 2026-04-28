using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum ShopItemClass
{
    Sword, Potion, Shield
}

public class ShopItem : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private ShopItemClass itemClass;
    [SerializeField] private float price;

    [Header("References")]
    [SerializeField] private GameObject ItemInfoQuad;
    [SerializeField] private TextMeshPro buttonText;

    private bool bought = false;

    void Start()
    {
        ItemInfoQuad.SetActive(false); // Hide the item info quad at the start
    }

    #region Icon
    public void OnIconHovered()
    {
        if (bought) return;

        ItemInfoQuad.SetActive(true);
    }
    public void OnIconHoverExit()
    {
        ItemInfoQuad.SetActive(false);
    }
    #endregion

    public void OnBuyButtonClicked(){
        if (bought) return;

        Debug.Log("Buy button clicked! Item: " + itemClass);

        if (PlayerStats.Instance.Coins.CompareTo(price) < 0)
        {
            Debug.Log("Player tries to buy " + itemClass + ", but dosent have enough coins,");
            return;
        }

        bought = true;
        buttonText.text = "Sold out!";
        PlayerStats.Instance.SpendCoins(price);
        switch (itemClass)
        {
            case ShopItemClass.Sword:
                PlayerStats.Instance.AddDamage(5);
                break;
            case ShopItemClass.Potion:
                PlayerStats.Instance.AddMaxHP(10);
                break;
            case ShopItemClass.Shield:
                PlayerStats.Instance.AddDefense(2);
                break;
        }

    }
}
