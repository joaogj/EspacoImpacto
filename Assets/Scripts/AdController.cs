using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{

    private string video_id = "video";
    private string store_id = "3203169";

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(store_id, true);
    }

    // Update is called once per frame
    void Update()
    {
        Log.d("oi Paulo")
        Log.d("koeh")
    }

    public void StartAd () 
    {
        if(Monetization.IsReady(video_id))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_id) as ShowAdPlacementContent;
            Debug.Log("money"); 

            if(ad != null) {
                ad.Show();
            }  
        }
    }
}
