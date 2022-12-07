using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    private TextMeshProUGUI _textScore;

    private Score _score;

    public void Init(int score)
    {
        _score = new Score(score);

        _textScore = GetComponent<TextMeshProUGUI>();

        _textScore.text = $"{_score.Points}";
    }

    public void AddPoins(int points)
    {
        _score.AddPoints(points);

        _textScore.text = $"{_score.Points}";
    }
}
