using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private TMP_InputField _confirmPasswordInput;
    [SerializeField] private Button _registerButton;
    
    private void Start()
    {
        _registerButton.onClick.AddListener(OnRegisterButtonClicked);
    }
    
    private async void OnRegisterButtonClicked()
    {
        try
        {
            string username = _usernameInput.text;
            string password = _passwordInput.text;
            string confirmPassword = _confirmPasswordInput.text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                Debug.LogError("All fields are required.");
                return;
            }

            if (password != confirmPassword)
            {
                Debug.LogError("Passwords do not match.");
                return;
            }
        
            var handler = new RegisterUserCommandHandler();
            var isConfirmed = await handler.Handle(new RegisterUserCommand(username, password));
        
            if(isConfirmed != null)
                Debug.Log($"Registering user: {username}");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    
    private void OnDestroy()
    {
        _registerButton.onClick.RemoveListener(OnRegisterButtonClicked);
    }
}
