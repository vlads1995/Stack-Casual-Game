using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private Image menu;
    [SerializeField] private Image gameOverMenu;
    [SerializeField] private TMP_Text bestScoreText;
    private int _currentScore;
    private int _bestScore;

    public static bool isNewGame= false;

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);        
    }


    void Update()
    {
        UpdateScore();        

        if (Floor.isGameOver == true)
        {
            GameOverActions();           
        }

        if (isNewGame == true)
        {
            Retry();
            isNewGame = false;
        }
    }

    public void UpdateScore()
    { 
        _currentScore = Controller.blockCount;
        if (_bestScore <= _currentScore)
        {
            _bestScore = _currentScore;
        }
        bestScoreText.text = "BEST: " + _bestScore;
        currentScoreText.text = "SCORE: " + (Controller.blockCount);
    }

    public void GameOverActions()
    {
        PlayerPrefs.SetInt("BestScore", _bestScore);
        Time.timeScale = 0;
        gameOverMenu.gameObject.SetActive(true);
        Floor.isGameOver = false;
    }

    public void Menu()
    {
        menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        gameOverMenu.gameObject.SetActive(false);
        Time.timeScale = 1;         
        Controller.blockCount = 0;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
