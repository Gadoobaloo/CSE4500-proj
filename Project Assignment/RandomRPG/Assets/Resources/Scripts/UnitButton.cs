using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitButton : MonoBehaviour
{
    private Unit unitData;
    public Image childImage;

    // Start is called before the first frame update
    void Start()
    {
        childImage.sprite = unitData.largeSpite;
        Debug.Log(unitData.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetUnitData(Unit tempUnit) 
    {
        unitData = tempUnit;
    }

}
