using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WeatherDataController : MonoBehaviour
{

    public GameObject[] weatherIcon;

    public TextMeshPro locationName;
    public TextMeshPro tempValue;

    // Start is called before the first frame update
    void Start()
    {
        weatherIcon[0].SetActive(false);
        weatherIcon[1].SetActive(false);
        weatherIcon[2].SetActive(false);
        weatherIcon[3].SetActive(false);
        weatherIcon[4].SetActive(false);
        weatherIcon[5].SetActive(false);
        weatherIcon[6].SetActive(false);
        weatherIcon[7].SetActive(false);
        weatherIcon[8].SetActive(false);
        weatherIcon[9].SetActive(false);
        StartCoroutine(getWeatherData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator getWeatherData()
    {
        UnityWebRequest www = UnityWebRequest.Get("api.openweathermap.org/data/2.5/weather?q=Las Vegas,NV,US&units=imperial&appid=d22f6ff0c5eef3a0847afa4d193ed206");
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
                WeatherData weatherdata = JsonUtility.FromJson<WeatherData>(jsonResult);

                //Debug.Log(weather.coord.lat);

                //weatherIcon[0].SetActive(true);

                //weatherdata.name = locationName.text;


                locationName.text = weatherdata.name;

                tempValue.text = weatherdata.main.temp.ToString();
                

                Debug.Log(weatherdata.name);



                foreach(WeatherItem w in weatherdata.weather)
                {
                    Debug.Log(w.description);
                    
                    if(w.description == "clear sky")
                    {
                        weatherIcon[0].SetActive(true);
                    }
                }
            }
        }
    }
}
