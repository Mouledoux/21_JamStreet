using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMedieator : MonoBehaviour
{
    public enum MsType
    {
        INT,
        FLOAT,
        BOOL
    }

    public MsType dataType = MsType.INT;
    public string message;

    public void QuickBroadcast(float v)
    {
        switch(dataType)
        {
            case MsType.BOOL:
                Mouledoux.Mediation.Catalogue<bool>.NotifySubscribers(message, v > 0f);
                break;
            case MsType.INT:
                Mouledoux.Mediation.Catalogue<int>.NotifySubscribers(message, (int)v);
                break;
            case MsType.FLOAT:
                Mouledoux.Mediation.Catalogue<float>.NotifySubscribers(message, v);
                break;
        }

    }

}
