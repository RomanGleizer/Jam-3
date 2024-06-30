using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image imageSource;

    public void ChangeSprite(int levelNumber)
    {
        imageSource.sprite = sprites[levelNumber - 1];
    }
}
