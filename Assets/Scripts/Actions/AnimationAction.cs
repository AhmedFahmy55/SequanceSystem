using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAction : SequanceAction
{

    [SerializeField] private string clipName;
    [SerializeField] private bool souldW8ToFinish;

    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void  Excute()
    {
        //skip event if there is no animator
        if(_animator == null)
        {
            OnComplete?.Invoke();
            return;
        }

        _animator.CrossFadeInFixedTime(clipName, .2f);

        if(souldW8ToFinish)
        {
            StartCoroutine(WaitAnimation());
        }
        else
        {
            OnComplete?.Invoke();
        }
    }

    private IEnumerator WaitAnimation()
    {
        //yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        while(GetNormalizedTime() < 1)
        {
            yield return null;
        }

        OnComplete?.Invoke();
    }

    private float GetNormalizedTime()
    {
        AnimatorStateInfo currentInfo = _animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = _animator.GetNextAnimatorStateInfo(0);

        if (_animator.IsInTransition(0) && nextInfo.IsTag("Anim"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!_animator.IsInTransition(0) && currentInfo.IsTag("Anim"))
        {

            return currentInfo.normalizedTime;
        }
        else return 0f;

    }
}
