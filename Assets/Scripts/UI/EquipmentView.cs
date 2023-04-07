using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private GameObject[] equipmentIcons;
    [SerializeField] private GameObject slingshotUI;

    public void HighlightIcon(int index) {
        if (index >= equipmentIcons.Length) {
            Debug.Log("Too high equipment icon index");
            return;
        }

        foreach(GameObject equipmentIcon in equipmentIcons) {
            equipmentIcon.GetComponent<Image>().color = Color.white;
        }

        equipmentIcons[index].GetComponent<Image>().color = Color.blue;
    }

    public void ShowSlingshotUI(bool show) {
        slingshotUI.SetActive(show);
    }
}
