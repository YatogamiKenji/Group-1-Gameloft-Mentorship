using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SizeConfig", menuName = "Scriptable Objects/SizeConfig")]
public class SizeConfigSO : ScriptableObject
{
    int maxW = 6;
    int maxH = 6;
    int minW = 2;
    int minH = 2;

    public int crnW = 2;
    public int crnH = 2;
    bool CheckOdd()
    {
        return(crnW %2 !=0 && crnH %2 !=0);
    }

    public void OnPlusH()
    {
        Debug.Log("Plus 1");
        if (crnH < maxH)
            crnH++;
        if (CheckOdd())
        {
            OnPlusH();
        }
    }

    public void OnMinusH()
    {
        if (crnH > minH)
            crnH--;
        if (CheckOdd())
        {
            OnMinusH();
        }
    }
    public void OnPlusW()
    {
        Debug.Log("Plus 1");
        if (crnW < maxW)
            crnW++;
        if (CheckOdd())
        {
            OnPlusW();
        }    
    }

    public void OnMinusW()
    {
        if (crnW > minW)
            crnW--;
        if (CheckOdd())
        {
            OnMinusW();
        }
    }
}
