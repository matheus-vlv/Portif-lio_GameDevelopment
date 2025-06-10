using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;

    private TextMeshProUGUI scoreText;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Invoke(nameof(FindScoreText), 0.1f); // Espera um pouco antes de procurar
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    void FindScoreText()
    {
        GameObject obj = GameObject.Find("ScoreText");
        if (obj != null)
        {
            scoreText = obj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("ScoreText não encontrado na cena.");
        }
    }
}
