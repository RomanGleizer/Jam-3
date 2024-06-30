using TMPro;
using UnityEngine;

public class CharacterSpeech : MonoBehaviour
{
    [SerializeField] private string[] phrasesItem;
    [SerializeField] private string[] phrasesDone;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject speech;

    public void SayPhraseDone(int id)
    {
        SpeechOn();
        _text.text = phrasesDone[id - 1];
    }

    public void SayPhraseItem(int id)
    {
        SpeechOn();
        _text.text = phrasesItem[id - 1];
    }

    public void SpeechOn()
    {
        speech.SetActive(true);
        Invoke("SpeechOff", 1f);
    }

    public void SpeechOff()
    {
        speech.SetActive(false);
    }
}
