using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private GameObject _level1;
    [SerializeField] private GameObject _level2;
    [SerializeField] private GameObject _level3;
    [SerializeField] private GameObject _hub;
    [SerializeField] private GameObject _dialogSystem;
    [SerializeField] private GameObject _start;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip main;

    private void Awake()
    {
        _start.SetActive(true);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        _dialogSystem.SetActive(false);
        _hub.SetActive(false);

        _audioSource.clip = main;
        _audioSource.Play();
    }
    public void GoLevelOne()
    {
        _hub.SetActive(false);
        _level1.SetActive(true);
        _dialogSystem.SetActive(true);
    }

    public void GoLevelTwo()
    {
        _hub.SetActive(false);
        _level2.SetActive(true);
        _dialogSystem.SetActive(true);
    }

    public void GoLevelThree()
    {
        _hub.SetActive(false);
        _level3.SetActive(true);
        _dialogSystem.SetActive(true);
    }

    public void GoHub()
    {
        _audioSource.clip = main;
        _audioSource.Play();

        _hub.SetActive(true);
        _dialogSystem.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
    }

    public void FirstGoHub()
    {
        _hub.SetActive(true);
        _dialogSystem.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        _start.SetActive(false);
    }
}
