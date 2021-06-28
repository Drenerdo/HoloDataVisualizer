using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class OpenAQController : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(getAQData());
    }

    IEnumerator getAQData()
    {
        UnityWebRequest www = UnityWebRequest.Get("#");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            byte[] results = www.downloadHandler.data;
            if(www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                Debug.Log(jsonResult);

                //Debug.Log(openAQ.meta);

                

                OpenAQData openAQ = JsonUtility.FromJson<OpenAQData>(jsonResult);

                Debug.Log(openAQ.result.location);

                

                
            }
        }
    }
}
