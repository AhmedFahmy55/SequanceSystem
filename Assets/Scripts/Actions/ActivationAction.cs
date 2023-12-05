using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationAction : SequanceAction
{


    [SerializeField] private GameObject objectToToggleActivationOn;
    [SerializeField] private bool objectActivation;


    public override void Excute()
    {
        //skip if there is no object
        if(objectToToggleActivationOn == null)
        {
            OnComplete?.Invoke();
            return;
        }

        objectToToggleActivationOn.SetActive(objectActivation);
        OnComplete?.Invoke();
    }
}
