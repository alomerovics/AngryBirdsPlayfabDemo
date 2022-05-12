using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class GetUserAccount : MonoBehaviour
{
    [SerializeField] Text _username;
    private bool isBanned;
    void Awake()
    {
        GetMasterPlayerCall();
    }

    void Update()
    {

    }

    void GetMasterPlayerCall()
    {
        GetAccountInfoRequest _request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(_request, SuccessRequest, ErrorRequest);

    }
    void ChangeUsername()
    {
        
        
    }
    private void ErrorRequest(PlayFabError obj)
    {
    }

    private void SuccessRequest(GetAccountInfoResult obj)
    {
        _username.text = obj.AccountInfo.Username;
    }

    public void CheckBan()
    {
        GetAccountInfoRequest _request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(_request, BanSuccess, BanError);
    }

    private void BanError(PlayFabError obj)
    {
        throw new NotImplementedException();
    }
    //isbanned global değişkeni üzerinden kontrol sağla eğer banlı değilse success çalışsın, eğer banlıysa ban sebebini yazdır.
    private void BanSuccess(GetAccountInfoResult obj)
    {
        if (obj.AccountInfo.TitleInfo.isBanned==false)
        {
            Debug.Log("Banlı değil");
            

        }
        else
        {
            Debug.Log("Banlı");

        }

    }
}
