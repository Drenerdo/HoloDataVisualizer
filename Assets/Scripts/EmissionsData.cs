using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class EmissionsData : MonoBehaviour
{

    public TextMeshPro emissionDataLabel;


    void Start()
    {
        StartCoroutine(GetEmissionData());
    }
    

    void Update()
    {

    }

    IEnumerator GetEmissionData()
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

            string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

            emissionDataLabel.text = jsonResult;

            Debug.Log(jsonResult);

            //byte[] results = www.downloadHandler.data;
        }

    }
}
