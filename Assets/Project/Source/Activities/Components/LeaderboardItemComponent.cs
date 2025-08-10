using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeaderboardItemComponent : MonoBehaviour
{
    [SerializeField] private Image _playerImage;
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public void SetData(string playerName, int score, Sprite playerIcon)
    {
        if (_playerImage != null && playerIcon != null)
        {
            _playerImage.sprite = playerIcon;
        }
        
        if (_playerNameText != null && !string.IsNullOrEmpty(playerName))
        {
            _playerNameText.text = "Username: " + playerName;
        }
        
        if (_scoreText != null && score >= 0)
        {
            _scoreText.text = "Exp: " + score;
        }
    }
}
