using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour
{
    [SerializeField]
    private int m_width = 1920;
    [SerializeField]
    private int m_height = 1080;
    [SerializeField]
    private RawImage m_displayUI = null;

    private WebCamTexture m_webCamTexture = null;


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private IEnumerator Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogFormat("カメラのデバイスが無い様だ。撮影は諦めよう。");
            yield break;
        }

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.LogFormat("カメラを使うことが許可されていないようだ。市役所に届けでてくれ！");
            yield break;
        }

        // とりあえず最初に取得されたデバイスを使ってテクスチャを作りますよ。
        WebCamDevice userCameraDevice = WebCamTexture.devices[0];
        m_webCamTexture = new WebCamTexture(userCameraDevice.name, m_width, m_height);

        m_displayUI.texture = m_webCamTexture;

        // さあ、撮影開始だ！
        m_webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
