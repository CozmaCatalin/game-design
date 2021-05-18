using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopMap : MonoBehaviour
{
    // Start is called before the first frame update
    public bool unlocked;
    public int price;
    public int itemId;
    public string MapName;
    public Button button;
    public Text buttonText;
    public GameObject coinImage;
    public GameObject lockIcon;
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        Check();
    }

    void TaskOnClick()
    {
        if(ShopManager.unlockedMaps[itemId] == true)
        {
            ShopManager.selectedMap = this;
            buttonText.text = "Selected";
        } else
        {
            if(ShopManager.currentCoins >= price)
            {
                lockIcon.SetActive(false);
                buttonText.text = "Select";
                coinImage.SetActive(false);
                ShopManager.unlockedMaps[itemId] = true;
                ShopManager.ModifyCoins(price);
            }
        }
    }

    void Check()
    {
        if(ShopManager.unlockedMaps[itemId] == true)
        {
            lockIcon.SetActive(false);
            buttonText.text = "Select";
            coinImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
