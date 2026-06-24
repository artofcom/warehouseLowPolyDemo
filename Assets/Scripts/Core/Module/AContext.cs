using System.Collections.Generic;
using UnityEngine;

public abstract class AContext 
{
    Dictionary<string, object> dictData = new Dictionary<string, object>();

    public void UpdateData(string key, object value)
    {
        dictData[key] = value;
    }

    public object GetData(string key) 
    {
        if(dictData.ContainsKey(key))
            return dictData[key];

        return null;
    }
}
