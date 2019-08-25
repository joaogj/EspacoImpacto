using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{

    public Text shareText;

    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void Share()
    {
        FB.ShareLink(
            contentTitle: "Espaço Impacto",
            contentURL: new System.Uri("https://www.youtube.com/watch?v=plYDSFq42Mo"),
            contentDescription: ("Esta é a minha pontuação: "),
            callback: OnShare
        );
    }

    private void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Sharelink error: " + result.Error);
        }
        else if(!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
            Debug.Log("Share succeed");
    }
}
