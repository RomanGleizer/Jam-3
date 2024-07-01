using CharactersSystem;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private GameObject _level1;
    [SerializeField] private GameObject _level2;
    [SerializeField] private GameObject _level3;
    [SerializeField] private GameObject _hub;
    [SerializeField] private GameObject _dialogSystem;
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _exit;

    [SerializeField] private Character char1;
    [SerializeField] private Character char2;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] main;

    private bool isHub;
    private bool isStart;

    public int countOfItem = 0;

    private void Awake()
    {
        GoStart();
    }

    private void Update()
    {
        if (countOfItem == 9)
        {
            Invoke("GoExit", 10f);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isHub)
        {
            GoStart();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isStart)
        {
            Application.Quit();
        }
    }

    public void GoLevelOne()
    {
        _hub.SetActive(false);
        _exit.SetActive(false);
        _level1.SetActive(true);
        _dialogSystem.SetActive(true);

        char1.changer.ChangeSprite(1);
        char2.changer.ChangeSprite(1);

        _audioSource.clip = main[1];
        _audioSource.Play();
        isHub = false;
        isStart = false;
    }

    public void GoLevelTwo()
    {
        _hub.SetActive(false);
        _exit.SetActive(false);
        _level2.SetActive(true);
        _dialogSystem.SetActive(true);

        char1.changer.ChangeSprite(2);
        char2.changer.ChangeSprite(2);

        _audioSource.clip = main[2];
        _audioSource.Play();
        isHub = false;
        isStart = false;
    }

    public void GoLevelThree()
    {
        _hub.SetActive(false);
        _exit.SetActive(false);
        _level3.SetActive(true);
        _dialogSystem.SetActive(true);

        char1.changer.ChangeSprite(3);
        char2.changer.ChangeSprite(3);

        _audioSource.clip = main[3];
        _audioSource.Play();
        isHub = false;
        isStart = false;
    }

    public void GoHub()
    {
        _audioSource.clip = main[0];
        _audioSource.Play();

        _hub.SetActive(true);
        _exit.SetActive(false);
        _dialogSystem.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        isHub = true;
        isStart = false;
    }

    public void FirstGoHub()
    {
        _hub.SetActive(true);
        _exit.SetActive(false);
        _dialogSystem.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        _start.SetActive(false);
        isHub = true;
    }

    public void GoStart()
    {
        _start.SetActive(true);
        _exit.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        _dialogSystem.SetActive(false);
        _hub.SetActive(false);

        _audioSource.clip = main[0];
        _audioSource.Play();
        isHub = false;
        isStart = true;
    }

    public void GoExit()
    {
        _exit.SetActive(true);
        _start.SetActive(false);
        _level1.SetActive(false);
        _level2.SetActive(false);
        _level3.SetActive(false);
        _dialogSystem.SetActive(false);
        _hub.SetActive(false);

        _audioSource.Stop();
        isHub = false;
        isStart = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
