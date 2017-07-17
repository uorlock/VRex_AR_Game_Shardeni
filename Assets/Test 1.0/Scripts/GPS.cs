using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GPS : MonoBehaviour
{
    public static GPS _instande;   
    public Text GlobalTextSpace;

    public float latitude = 1f;   //grdzedi
    public float longitude = 1f;  //ganedi

    void Start()
    {
        _instande = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    // Update is called once per frame
    void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
    }

    private IEnumerator StartLocationService()   //locaciis gansazgvris funqcia
    {
        if (!Input.location.isEnabledByUser)     //gps chartvis shemowmeba
        {
            SendGlobalMessage("momxmarebels ar chaurtavs GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            SendGlobalMessage("Dro gavida");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)  //adgilmdebareobis gansazgvris shemowmeba
        {
            SendGlobalMessage("Ar moxerxda adgilmdebareobis gansazgvra");
            yield break;

        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        yield break;
    }

    private void SendGlobalMessage(string message)  // global message
    {
        GlobalTextSpace.gameObject.SetActive(true);
        GlobalTextSpace.text = message;
        Invoke("removeGlobalMessage", 3f);
    }

    private void removeGlobalMessage()
    {
        GlobalTextSpace.gameObject.SetActive(false);
    }
}