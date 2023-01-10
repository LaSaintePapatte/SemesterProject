using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] items;
    [SerializeField] private CanvasGroup[] invText;

    public void SelectItem(int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (i == -1)
            {
                return; 
            }
            if (i == index)
            {
                items[i].interactable= true;
                items[i].blocksRaycasts = true;
                items[i].alpha = 1f;
            }
            else
            {
                items[i].interactable = false;
                items[i].blocksRaycasts = false;
                items[i].alpha = 0f;
            }
        }
    }
    public void SelectInvText(int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (i == -1)
            {
                return;
            }
            if (i == index)
            {
                invText[i].interactable = true;
                invText[i].blocksRaycasts = true;
                invText[i].alpha = 1f;
            }
            else
            {
                invText[i].interactable = false;
                invText[i].blocksRaycasts = false;
                invText[i].alpha = 0f;
            }
        }
    }

    public void CloseInvText()
    {
        for (int i = 0; i < items.Length; i++)
        {
            Debug.Log("Boloss");
            invText[i].interactable = false;
            invText[i].blocksRaycasts = false;
            invText[i].alpha = 0f;
        }
    }
}
