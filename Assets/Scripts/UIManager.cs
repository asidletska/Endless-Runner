using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isGameOver = false;
    // об'єкти які ми назначаєио в інспекторі
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject pauseButton;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void OnPlayHandler()
    {
        //
        Time.timeScale = 1f;
        // деактивуємо панель меню
        menuPanel.SetActive(false);
        // активуємо панель гри
        gamePanel.SetActive(true);
    }
    public void OnContinueHandler()
    {
        // 
        Time.timeScale = 1f;
        // деактивуємо панель паузи
        pausePanel.SetActive(false);
        // активуємо панель гри
        gamePanel.SetActive(true);
    }
    public void OnPauseHandler()
    {
        // робимо паузу в грі
        Time.timeScale = 0;
        // деактивуємо панель гри
        gamePanel.SetActive(false);
        // активуємо панель паузи
        pausePanel.SetActive(true);
    }
    public void OnMenuHandler()
    {
        // робимо паузу в грі
        Time.timeScale = 0;
        // перезапускаємо сцену
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        // викликаємо метод LosePanelActive через 2 секунди
        Invoke(nameof(LosePanelActive), 2f);
    }
    private void LosePanelActive()
    {
        isGameOver = true;
        // зупиняємо гру
        Time.timeScale = 0;
        // деактивуємо панель гри
        gamePanel.SetActive(false);
        // активуємо панелль програшу
        losePanel.SetActive(true);
    }
    public void OnRestartHandler()
    {
        // перезапускаємо сцену
        SceneManager.LoadScene(0);
    }
    public void OnExitHandler()
    {
        // Вихід з гри
        Application.Quit();
    }
}
