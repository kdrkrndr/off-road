using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class ReklamRewardedVideo : MonoBehaviour
{
    private RewardBasedVideoAd reklamObjesi;

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });
        reklamObjesi = RewardBasedVideoAd.Instance;
    }

    // Ekranda test amaçlı "Reklamı Göster" butonu göstermeye yarar, bu fonksiyonu silerseniz buton yok olur
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height - 300, 300, 300), "Reklamı Göster"))
        {
            AdRequest reklamIstegi = new AdRequest.Builder().Build();
            reklamObjesi.LoadAd(reklamIstegi, "ca-app-pub-3940256099942544/5224354917");

            StartCoroutine(ReklamiGoster());
        }
    }

    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;

        reklamObjesi.Show();
    }
}
