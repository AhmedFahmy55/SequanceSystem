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
        //if no action it soulkdnt do anything by default cus foreach won excute but wahtever :)
        if (actions.Count == 0) yield break;
        
        foreach (var action in actions)
        {
            action.OnComplete += SequanceAction_OnComplete;
            action.Excute();

            while(!souldContinue)
            {
                yield return null;
            }
            souldContinue = false;
            action.OnComplete -= SequanceAction_OnComplete;
        }
    }

    private void SequanceAction_OnComplete()
    {
        souldContinue = true;
    }
}
