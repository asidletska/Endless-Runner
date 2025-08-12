using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;  // текст €кий показуЇ к≥льк≥сть з≥браних монет
    [SerializeField] private TextMeshProUGUI bestScoreText; // текст €кий показуЇ найб≥льшу к≥льк≥сть з≥браних монет
    private int coinsCount;    // зм≥нна, €ка рахуЇ ск≥льки монет було з≥брано 
    private int bestScore;  // зм≥нна, €ка показуЇ найвищу к≥льк≥сть очк≥в

    private void Start()
    {
        // «авантажуЇмо найкращий результат з памТ€т≥
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = bestScore.ToString();
    }
    public void AddCoin()
    {
        coinsCount++;  // додаЇмо монету
        coinText.text = "Score: " + coinsCount.ToString(); // оновлюЇмо текст к≥лькост≥ монет

        // якщо новий результат кращий Ч збер≥гаЇмо його
        if (coinsCount > bestScore)
        {
            bestScore = coinsCount;
            bestScoreText.text = "Best score: " + bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // збер≥гаЇмо зм≥ни
        }
    }
}
