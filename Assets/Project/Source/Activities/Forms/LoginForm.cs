using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;


public class LoginForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private Button _registerButton;

    private PlayerStatsModel _playerStatsModel;
    private void Awake()
    {
        _registerButton.onClick.AddListener(OnRegisterButtonClicked);
    }

    [Inject]
    public void Construct(PlayerStatsModel playerStatsModel)
    {
        _playerStatsModel = playerStatsModel;
    }
    
    private async void OnRegisterButtonClicked()
    {
        try
        {
            var login = _usernameInput.text;
            var password = _passwordInput.text;
            
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                Debug.LogError("Username and password cannot be empty.");
                return;
            }
            
            var handler = new LoginUserCommandHandler();
            var playerStats = await handler.Handle(new LoginUserCommand
            {
                Username = login,
                Password = password
            });

            if (playerStats != null)
            {
                Debug.Log($"Login successful for user: {playerStats.UserName}");
                
                _playerStatsModel.UserName = playerStats.UserName;
                _playerStatsModel.UserExp = playerStats.UserExp;
                _playerStatsModel.EnemiesKilled = playerStats.EnemiesKilled;

                SceneManager.LoadScene("GameScene");
            }
            else
                Debug.LogError("Login failed. Please check your credentials.");
         
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void OnDestroy()
    {
        _registerButton.onClick.RemoveListener(OnRegisterButtonClicked);
    }
}
