using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Camera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Slot>(out Slot slot)) {
            slot.AddItem(itemImage);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Input.mousePosition;
        }
    }
}
