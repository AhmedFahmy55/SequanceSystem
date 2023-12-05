using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequanceController : MonoBehaviour
{
    [SerializeField] List<SequanceAction> actions;



    bool souldContinue;
    private void Start()
    {
        StartCoroutine(ExcuteSequance());
    }

    private IEnumerator ExcuteSequance()
    {
        foreach (var action in actions)
        {
            action.OnComplete += SequanceAction_OnComplete;
            action.Excute();

            while(!souldContinue)
            {
                yield return null;
            }
            souldContinue = false;
        }
    }

    private void SequanceAction_OnComplete()
    {
        souldContinue = true;
    }
}
