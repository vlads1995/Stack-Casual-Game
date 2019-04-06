using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static bool IsNewGame = false;

    [SerializeField]
    private TMP_Text _currentScoreText;
    [SerializeField]
    private Image _menu;
    [SerializeField]
    private Image _gameOverMenu;
    [SerializeField]
    private TMP_Text _bestScoreText;

    private int _currentScore;
    private int _bestScore;

    public UIManager(Image gameOverMenu, TMP_Text bestScoreText)
    {
        this._gameOverMenu = gameOverMenu;
        this._bestScoreText = bestScoreText;
    }

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);        
    }


    private void Update()
    {
        UpdateScore();        

        if (Floor.IsGameOver == true)
        {
            GameOverActions();           
        }

        if (IsNewGame == true)
        {
            Retry();
            IsNewGame = false;
        }
    }

    public void UpdateScore()
    { 
        _currentScore = Controller.BlockCount;
        if (_bestScore <= _currentScore)
        {
            _bestScore = _currentScore;
        }
        _bestScoreText.text = "BEST: " + _bestScore;
        _currentScoreText.text = "SCORE: " + (Controller.BlockCount);
    }

    public void GameOverActions()
    {
        PlayerPrefs.SetInt("BestScore", _bestScore);
        Time.timeScale = 0;
        _gameOverMenu.gameObject.SetActive(true);
        Floor.IsGameOver = false;
    }

    public void Menu()
    {
        _menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        _gameOverMenu.gameObject.SetActive(false);
        Time.timeScale = 1;         
        Controller.BlockCount = 0;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
