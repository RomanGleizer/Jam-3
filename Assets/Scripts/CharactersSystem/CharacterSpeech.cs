using TMPro;
using UnityEngine;

public class CharacterSpeech : MonoBehaviour
{
    [SerializeField] private string[] phrases;
    [SerializeField] private TextMeshProUGUI _text;

    public void SayPhrase(int id)
    {
        _text.text = phrases[id - 1];
    }
}
