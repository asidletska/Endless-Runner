using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isGameOver = false;
    // ��'���� �� �� ��������� � ���������
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
        // ���������� ������ ����
        menuPanel.SetActive(false);
        // �������� ������ ���
        gamePanel.SetActive(true);
    }
    public void OnContinueHandler()
    {
        // 
        Time.timeScale = 1f;
        // ���������� ������ �����
        pausePanel.SetActive(false);
        // �������� ������ ���
        gamePanel.SetActive(true);
    }
    public void OnPauseHandler()
    {
        // ������ ����� � ��
        Time.timeScale = 0;
        // ���������� ������ ���
        gamePanel.SetActive(false);
        // �������� ������ �����
        pausePanel.SetActive(true);
    }
    public void OnMenuHandler()
    {
        // ������ ����� � ��
        Time.timeScale = 0;
        // ������������� �����
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        // ��������� ����� LosePanelActive ����� 2 �������
        Invoke(nameof(LosePanelActive), 2f);
    }
    private void LosePanelActive()
    {
        isGameOver = true;
        // ��������� ���
        Time.timeScale = 0;
        // ���������� ������ ���
        gamePanel.SetActive(false);
        // �������� ������� ��������
        losePanel.SetActive(true);
    }
    public void OnRestartHandler()
    {
        // ������������� �����
        SceneManager.LoadScene(0);
    }
    public void OnExitHandler()
    {
        // ����� � ���
        Application.Quit();
    }
}
