using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class WeatherData
{
    public Coord coord;
    public List<WeatherItem> weather;
    public Main main;
    public int visibility;
    public Wind wind;
    public Clouds clouds;
    public int dt;
    public Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

[Serializable]
public class Coord
{
    public double lon;
    public double lat;
}

[System.Serializable]
public class WeatherItem
{
    public static WeatherItem instance;

    public int id;
    public string main;
    public string description;
    public string icon;
}

[Serializable]
public class Main
{
    public double temp;
    public double feels_like;
    public double temp_min;
    public double temp_max;
    public int pressure;
    public int humidity;
}

[Serializable]
public class Wind
{
    public double speed;
    public int deg;
    public double gust;
}

[Serializable]
public class Clouds
{
    public int all;
}

[Serializable]
public class Sys
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}
