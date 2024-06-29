using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _itemImage;

    public void AddItem(Image image)
    {
        _itemImage = image;
        _itemImage.color = new Color(255, 255, 255, 1f);
    }
}
