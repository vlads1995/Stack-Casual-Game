using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText;
    private int _bestScore;

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "BEST SCORE: " + _bestScore;
    }     

    public void NewGame()
    {
        UIManager.IsNewGame = true;
        SceneManager.LoadScene("Game");        
    }

    public void ExitGame()
    {
        Application.Quit();
    }     
}
