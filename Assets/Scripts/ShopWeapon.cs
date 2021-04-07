using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
	public ShopManager shopManager;
	public int itemId;
	public int price;
	public bool unlocked = false;
	public GameObject weapon;
    void Start () {
		button.onClick.AddListener(TaskOnClick);
		Check();
	}

	void TaskOnClick(){
		if(ShopManager.unlocked[itemId] == false)
        {
			if(ShopManager.currentCoins >= price)
            {
				Button PriceButton = this.transform.GetChild(0).gameObject.GetComponent<Button>();
				Text ButtonText = PriceButton.transform.GetChild(0).gameObject.GetComponent<Text>();
				PriceButton.transform.GetChild(1).gameObject.SetActive(false);
				this.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
				ButtonText.text = "EQUIP";
				ShopManager.unlocked[itemId] = true;
				ShopManager.ModifyCoins(price);
			}
		} else
        {
			Button PriceButton = this.transform.GetChild(0).gameObject.GetComponent<Button>();
			Text ButtonText = PriceButton.transform.GetChild(0).gameObject.GetComponent<Text>();
			ButtonText.text = "EQUIPED";
			ShopManager.selectedWeapon = this;
			ShopManager.unlocked[itemId] = true;
		}
	}

	void Check()
    {
		if (ShopManager.unlocked[itemId] == true)
		{
			Button PriceButton = this.transform.GetChild(0).gameObject.GetComponent<Button>();
			Text ButtonText = PriceButton.transform.GetChild(0).gameObject.GetComponent<Text>();
			PriceButton.transform.GetChild(1).gameObject.SetActive(false);
			this.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
			ButtonText.text = "EQUIP";
			ShopManager.unlocked[itemId] = true;
		}

		if (ShopManager.selectedWeapon)
        {
			if (ShopManager.selectedWeapon.itemId == itemId)
			{
				Button PriceButton = this.transform.GetChild(0).gameObject.GetComponent<Button>();
				Text ButtonText = PriceButton.transform.GetChild(0).gameObject.GetComponent<Text>();
				PriceButton.transform.GetChild(1).gameObject.SetActive(false);
				ButtonText.text = "EQUIPED";
			}
		}

    }
}
