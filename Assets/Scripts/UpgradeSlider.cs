using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    const float upgradeValue = 0.1f;
    public Button increaseButton;
    public string upgradeName;
    public Slider upgradeSlider;
    public Text priceValue;
    void Start()
    {
        increaseButton.onClick.AddListener(TaskOnClick);
        if(name == "Strength")
        {
            upgradeSlider.value = ShopManager.strength;
            priceValue.text = ShopManager.strengthPrice.ToString();
        } else if (name == "Speed")
        {
            upgradeSlider.value = ShopManager.speed;
            priceValue.text = ShopManager.speedPrice.ToString();
        }
        else if(name == "Health")
        {
            upgradeSlider.value = ShopManager.health;
            priceValue.text = ShopManager.healthPrice.ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int coinsToSubtract(string upgrade)
    {
        if(upgrade == "Strength")
        {
            return ShopManager.strengthPrice;
        }
        if (upgrade == "Health")
        {
            return ShopManager.healthPrice;
        }
        if (upgrade == "Speed")
        {
            return ShopManager.speedPrice;
        }
        return 0;
    }

    void TaskOnClick()
    {
        int coins = coinsToSubtract(upgradeName);
        if(ShopManager.currentCoins > coins)
        {
            ShopManager.ModifyCoins(coins);
            if (name == "Strength")
            {
                ShopManager.strength += upgradeValue;
                ShopManager.strengthPrice += coins;
                priceValue.text = ShopManager.strengthPrice.ToString();
                upgradeSlider.value = ShopManager.strength;
            }
            else if (name == "Speed")
            {
                ShopManager.speed += upgradeValue;
                ShopManager.speedPrice += coins;
                priceValue.text = ShopManager.speedPrice.ToString();
                upgradeSlider.value = ShopManager.speed;
            }
            else if (name == "Health")
            {
                ShopManager.health += upgradeValue;
                ShopManager.healthPrice += coins;
                priceValue.text = ShopManager.healthPrice.ToString();
                upgradeSlider.value = ShopManager.health;

            }
        } else
        {
            Debug.Log("Not enough money!");
        }
    }
}
