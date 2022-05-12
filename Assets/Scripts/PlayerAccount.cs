using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab; //get için
using PlayFab.ClientModels; //set icin
using System;
using UnityEngine.SceneManagement;

public class PlayerAccount //suan veri tabanini yaziyoruz.
{
    string _loginusername, _password;
    public string PlayerID { get; set; }
    public string DisplayName { get; set; }
    public string LoginUserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; } ///bu veritabanını gönderemicez kapsülleme vs gerek yok sadece pas bununla kontro edeceğiz

    public void Register() //registerda tek request ile giris yapilir. email username ayrimi yok 
    {
        RegisterPlayFabUserRequest _registerRequest = new RegisterPlayFabUserRequest() { Username = LoginUserName, Email = Email, Password = Password, DisplayName = DisplayName }; //diger taraftan bilgiyi burdaki proplara alıp burdaki proplari çek aşağıda client apı üzerinden aşağıdaki (kalıp) üzerinden servera yolla. 

        PlayFabClientAPI.RegisterPlayFabUser(_registerRequest, RegisterSuccess, RegisterError);
    }
    private void RegisterError(PlayFabError obj)
    {
        Debug.LogError("Kayıt Başarısız");
    }
    private void RegisterSuccess(RegisterPlayFabUserResult obj)
    {
        Debug.Log("Kayıt Başarılı");
    }
    public void Login()
    {
        LoginWithPlayFabRequest _loginrequest = new LoginWithPlayFabRequest() { Username = LoginUserName, Password = Password };
        PlayFabClientAPI.LoginWithPlayFab(_loginrequest, LoginSuccess, LoginError);
    }
    private void LoginSuccess(LoginResult obj)
    {
        //banlı oyuncu buton itiraz talebi göndersin
        //
        Debug.Log("Giriş Başarılı");
        SceneManager.LoadScene("SampleScene");
    }
    private void LoginError(PlayFabError obj)
    {
        Debug.Log("Giriş Başarısız");
    }



}