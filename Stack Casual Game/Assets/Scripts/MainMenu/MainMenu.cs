using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText;
    private int _bestScore;    

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "BEST SCORE: " + _bestScore;
    }     

    public void NewGame()
    {
        UIManager.isNewGame = true;
        SceneManager.LoadScene("Game");        
    }

    public void ExitGame()
    {
        Application.Quit();
    }     
}
