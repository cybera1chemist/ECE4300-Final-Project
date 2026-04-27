using UnityEngine;

public class ExitShopButton : MonoBehaviour
{
    public void OnClick()
    {
        AreaManager.Instance.ExitShop();
    }
}
