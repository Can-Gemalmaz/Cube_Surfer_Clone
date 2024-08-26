
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<PlayerCubeManager>
{
    [SerializeField] Button replayButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject gameMenu;

    PlayerCubeManager cubeManager;
    PlayerDiamondManager diamondManager;


    private void Awake()
    {
        replayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameMenu.SetActive(false);

        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }


    private void Start()
    {
        cubeManager = Instance;

        diamondManager = cubeManager.GetComponent<PlayerDiamondManager>();
        cubeManager.OnPlayerDead += OnPlayerDeadEvent;
    }

    private void OnPlayerDeadEvent()
    {
        diamondManager.SavePrefs(diamondManager.GetDiamondCount());
        gameMenu.SetActive(true);
    }
}
