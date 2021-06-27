using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CryptoController
{
    public string name;
    public string fullname;
    public string code;
    public string icon;
    public string type;
    public bool active;
    public string chainType;
    public int chainTypeValue;
    public int basePrecision;
    public int transferPrecision;
    public int externalPrecision;
    public string fee;
    //public Limits limits;

    public List<Limits> limits;

    //public List<Withdraw> withdraws;
}

[Serializable]
public class Deposit
{
    public string min;
    public string max;
}

[System.Serializable]
public class Withdraw
{
    public string min;
    public string max;
}

[System.Serializable]
public class Limits
{
    public List<Deposit> deposit;
    public List<Withdraw> withdraw;
}
