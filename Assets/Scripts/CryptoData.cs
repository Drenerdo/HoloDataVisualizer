using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine.Networking;
using TMPro;

public class CryptoData : MonoBehaviour
{
    public TextMeshPro name_text;
    public TextMeshPro chainType;
    public TextMeshPro fee;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetCryptoData());

        StartCoroutine(getData());
    }



    IEnumerator getImage()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("#"))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);

                Debug.Log(texture);
            }
        }
    }

    IEnumerator getData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.bloxxwop.com/currencies");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {


            byte[] results = www.downloadHandler.data;

            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                
                Debug.Log(jsonResult);

                Debug.Log(jsonResult == "BTC");

                //CryptoController cryptoController = JsonUtility.FromJson<CryptoController>(jsonResult.ToString());

                //TotalData totalData = JsonUtility.FromJson<TotalData>(jsonResult);


                //CryptoController cryptoController = JsonUtility.FromJson<CryptoController>(jsonResult);

                //Debug.Log(" Here are the confirmed cases " + totalData.confirmed);
                //Debug.Log(" Here are the recovered cases " + totalData.recovered);
                //Debug.Log(" Here are the casualities " + totalData.deaths);

                //infectedText.text = totalData.confirmed.ToString();
                //recoveredText.text = totalData.recovered.ToString();
                //casualtyText.text = totalData.deaths.ToString();



                //DataTypeVisualizer dataType = JsonUtility.FromJson<DataTypeVisualizer>(jsonResult);
            }
        }
    }
}
