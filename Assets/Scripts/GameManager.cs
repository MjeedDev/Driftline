using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Animator textAnimator;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject HUD;

    public bool isGameStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameStart()
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
            mainMenu.SetActive(false);
            HUD.SetActive(true);
            StartCoroutine(UpdateScore());
        }          
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score++;
            scoreText.text = score.ToString();
            textAnimator.SetTrigger("UpdateScore");
        }
    }
}
