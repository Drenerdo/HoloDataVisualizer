using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DataController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CryptoData());
        StartCoroutine(GetEmmisionsData());
    }

    IEnumerator CryptoData()
    {

        UnityWebRequest www = UnityWebRequest.Get("https://api.bloxxwop.com/currencies");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(" Retrived crypto data! ");
            Debug.Log(www.downloadHandler.text);

            byte[] results = www.downloadHandler.data;
        }

    }

    IEnumerator GetEmmisionsData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.v2.emissions-api.org/api/v2/methane/data-range.json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(" Emmissions Data ");
            Debug.Log(www.downloadHandler.text);

            byte[] results = www.downloadHandler.data;

            Debug.Log(www.downloadHandler.text  + "US");
        }
    }
}
