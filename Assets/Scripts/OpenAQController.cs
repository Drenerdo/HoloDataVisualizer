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
        UnityWebRequest www = UnityWebRequest.Get("https://docs.openaq.org/v1/measurements?date_from=2000-01-01T00%3A00%3A00%2B00%3A00&date_to=2021-06-27T00%3A47%3A00%2B00%3A00&limit=100&page=1&offset=0&sort=desc&radius=1000&country_id=US&order_by=datetime");
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
