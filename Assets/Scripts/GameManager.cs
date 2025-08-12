using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;  // ����� ���� ������ ������� ������� �����
    [SerializeField] private TextMeshProUGUI bestScoreText; // ����� ���� ������ �������� ������� ������� �����
    private int coinsCount;    // �����, ��� ���� ������ ����� ���� ������ 
    private int bestScore;  // �����, ��� ������ ������� ������� ����

    private void Start()
    {
        // ����������� ��������� ��������� � �����
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = bestScore.ToString();
    }
    public void AddCoin()
    {
        coinsCount++;  // ������ ������
        coinText.text = "Score: " + coinsCount.ToString(); // ��������� ����� ������� �����

        // ���� ����� ��������� ������ � �������� ����
        if (coinsCount > bestScore)
        {
            bestScore = coinsCount;
            bestScoreText.text = "Best score: " + bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // �������� ����
        }
    }
}
