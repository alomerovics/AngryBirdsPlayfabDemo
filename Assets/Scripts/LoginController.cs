using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField] InputField _usernameInput, _emailInput, _passwordInput;
    [SerializeField] Text _titleText, _orLoginRegisterText, _resultText;
    [SerializeField] Button _loginRegisterButton;
    LoginRegisterBaseClass _loginRegisterBase = new LoginRegisterBaseClass();

    public void Login()
    {
        _loginRegisterBase.LoginEmail(_emailInput, _passwordInput);
    }
    public void Register()
    {
        _loginRegisterBase.Register(_usernameInput, _emailInput, _passwordInput);
        _resultText.text = _loginRegisterBase._sonuc;
    }
    public void SwitchPanel()
    {
        switch (_usernameInput.gameObject.activeInHierarchy)
        {
            case false:
                // burasý register paneldir
                _usernameInput.gameObject.SetActive(true);
                _titleText.text = "Register";
                _loginRegisterButton.GetComponentInChildren<Text>().text = "Register";
                _orLoginRegisterText.text = "OR Login";
                _loginRegisterButton.onClick.RemoveAllListeners();
                _loginRegisterButton.onClick.AddListener(Register);
                break;
            case true:
                // burasý login paneldir
                _usernameInput.gameObject.SetActive(false);
                _titleText.text = "Login";
                _loginRegisterButton.GetComponentInChildren<Text>().text = "Login";
                _orLoginRegisterText.text = "OR Register";
                _loginRegisterButton.onClick.RemoveAllListeners();
                _loginRegisterButton.onClick.AddListener(Login);
                break;
        }
    }
}
