using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginOrRegister : MonoBehaviour  //inspextorden alacağımız içim monoya iht var.
{


    [SerializeField] InputField _loginusername, _email, _password, _rPassword;
    [SerializeField] Button _loginOrRegisterButton;
    [SerializeField] Text _registerOrLoginButtonText, _ORRegisterLogin;
    PlayerAccount _playerAccount;
    public static bool __isRegisterActive;
    void Awake()
    {

        _playerAccount = new PlayerAccount();
    }

    public void Register()
    {
        _playerAccount.LoginUserName = _loginusername.text;
        _playerAccount.Email = _email.text;
        _playerAccount.Password = _password.text;
        _playerAccount.RepeatPassword = _rPassword.text;
        _playerAccount.DisplayName = _loginusername.text;
        _playerAccount.Register();
    }

    public void Login()
    {
        _playerAccount.LoginUserName = _loginusername.text;
        _playerAccount.Password = _password.text;
        _playerAccount.Login();

    }

    public void RegisterOrLoginPanelControl()
    {
        switch (!_email.gameObject.activeInHierarchy)
        {

            case true:
                RegisterPanel();
                break;
            case false:
                LoginPanel();
                break;
        }
    }
    public void RegisterPanel()
    {
        _email.gameObject.SetActive(true);
        _rPassword.gameObject.SetActive(true);
        _registerOrLoginButtonText.text = "Register";
        _ORRegisterLogin.text = "Or login";
        _loginOrRegisterButton.onClick.RemoveAllListeners();
        _loginOrRegisterButton.onClick.AddListener(Register);
    }

    void LoginPanel()
    {
        _email.gameObject.SetActive(false);
        _rPassword.gameObject.SetActive(false);
        _registerOrLoginButtonText.text = "Login";
        _ORRegisterLogin.text = "Or Register";
        _loginOrRegisterButton.onClick.RemoveAllListeners();
        _loginOrRegisterButton.onClick.AddListener(Login);


    }
}