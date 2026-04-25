using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject ItemInfoQuad;

    void Start()
    {
        ItemInfoQuad.SetActive(false); // Hide the item info quad at the start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Icon
    public void OnIconHovered()
    {
        Debug.Log("Icon hovered");
        ItemInfoQuad.SetActive(true); // Show the item info quad when hovered
    }
    public void OnIconHoverExit()
    {
        Debug.Log("Icon hover exited");
        ItemInfoQuad.SetActive(false); // Hide the item info quad when hover exits
    }
    #endregion

    public void OnBuyButtonClicked(){
        Debug.Log("Buy button clicked");
        // Implement purchase logic here
    }
}
