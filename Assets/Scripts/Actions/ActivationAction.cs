using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationAction : SequanceAction
{


    [SerializeField] private GameObject objectToToggleActivationOn;
    [SerializeField] private bool objectActivation;
    [SerializeField] private float activationDelay;


    public override void Excute()
    {
        //skip if there is no object
        if(objectToToggleActivationOn == null)
        {
            OnComplete?.Invoke();
            return;
        }

        StartCoroutine(ToggleObjectActivation());
    }

    private IEnumerator ToggleObjectActivation()
    {
        yield return new WaitForSeconds(activationDelay);
        objectToToggleActivationOn.SetActive(objectActivation);
        OnComplete?.Invoke();
    }
}
