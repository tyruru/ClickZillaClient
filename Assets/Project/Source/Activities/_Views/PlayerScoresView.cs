using TMPro;
using UnityEngine;

public class PlayerScoresView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public void UpdateScoreView(int value)
    {
        _scoreText.text = $"Score: {value}";
    }
}
