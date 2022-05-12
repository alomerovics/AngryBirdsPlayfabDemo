using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoginRegisterBaseClass
{
    public string _sonuc;
    public void Register(InputField _username, InputField _email, InputField _password)
    {
        RegisterPlayFabUserRequest _user = new RegisterPlayFabUserRequest() 
        {
            Username=_username.text,
            Email=_email.text,
            Password=_password.text
        };
        PlayFabClientAPI.RegisterPlayFabUser(_user, SuccessResult, ErrorResult);
    }

    public void LoginUsername(InputField _username, InputField _password)
    {
        LoginWithPlayFabRequest _loginUsername = new LoginWithPlayFabRequest()
        {
            Username = _username.text,
            Password = _password.text
        };
        PlayFabClientAPI.LoginWithPlayFab(_loginUsername, SuccessLoginResult, ErrorResult);
    }
    public void LoginEmail(InputField _email, InputField _password)
    {
        LoginWithEmailAddressRequest _loginEmail = new LoginWithEmailAddressRequest() 
        {
            Email=_email.text,
            Password=_password.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(_loginEmail, SuccessLoginResult, ErrorResult);
    }

    private void SuccessLoginResult(LoginResult obj)
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Giris basarili!");
    }

    private void ErrorResult(PlayFabError obj)
    {
        _sonuc = obj.ErrorMessage;
        Debug.Log(_sonuc);

        //Sonuc();
    }

    private void SuccessResult(RegisterPlayFabUserResult obj)
    {
        _sonuc = "Kayit Basarili.";
        Debug.Log(_sonuc);

        //Sonuc();
    }
    public string Sonuc()
    {
        return _sonuc;
    }
}
