using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _statusUI;
    [SerializeField] private GameObject _storeUI; //TODO

    public void OpenInventory()
    {
        _inventoryUI.SetActive(true);
        UIManager.Instance.LoadInventoryUI();
        _buttons.SetActive(false);
    }
    public void CloseInventory()
    {
        _inventoryUI.SetActive(false);
        GameManager.Instance.UnequipAllItems();
        foreach(ItemStats item in GameManager.Instance.inventory)
        {
            if (item.isEquipped)
            {
                GameManager.Instance.EquipItem(item);
            }
        }
        _buttons.SetActive(true);
    }

    public void ChooseItem(int index)
    {
        //TODO ÀåÂøÆË¾÷ ¹× Ã³¸®
        UIManager.Instance.ShowItemPopup(index);
        //bool isEquipped = GameManager.Instance.inventory[0].isEquipped;
        //GameManager.Instance.inventory[0].isEquipped = !isEquipped;
    }

    public void OpenStatus()
    {
        _statusUI.SetActive(true);
        UIManager.Instance.UpdatePlayerStatusUI();
        _buttons.SetActive(false);
    }
    public void CloseStatus()
    {
        _statusUI.SetActive(false);
        _buttons.SetActive(true);
    }

    public void OpenStore()
    {
        _storeUI.SetActive(true);
        _buttons.SetActive(false);
    }

    public void CloseStore()
    {
        _storeUI.SetActive(false);
        _buttons.SetActive(true);
    }

}
