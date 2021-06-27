using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class OpenAQData
{

    public static OpenAQData instance;

    public Meta meta;
    public ResultsItem result;

    
}



[System.Serializable]
public class Meta
{
    public string name;

    public string license;

    public string website;

    public int page;
    public int limit;

    public int found;
}

[System.Serializable]
public class Date
{
    public string utc;
    public string local;
}

[System.Serializable]
public class Coordinates
{
    public double latitude;
    public double longitude;
}

[Serializable]
public class ResultsItem
{
    public string location;
    public string parameter;
    public int value;
    public List<Date> date;
    public string unit;
    public List<Coordinates> coordinates;
    public string country;
    public string city;

}


