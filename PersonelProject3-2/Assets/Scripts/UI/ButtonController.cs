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
        _buttons.SetActive(false);
    }
    public void CloseInventory()
    {
        _inventoryUI.SetActive(false);
        _buttons.SetActive(true);
    }


    public void OpenStatus()
    {
        _statusUI.SetActive(true);
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
