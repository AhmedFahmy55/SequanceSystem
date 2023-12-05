using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementAction :  SequanceAction
{
    [SerializeField] private Transform transformToMove;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float duration;

    bool _souldStart = false;
    private float _passedTime;


    private void Update()
    {
        //skip if no point to reach
        if (pointA == null || pointB == null)
        {
            OnComplete?.Invoke();
            return;
        }

        if (!_souldStart) return;

        if(_passedTime >= duration)
        {
            OnComplete?.Invoke();
            _souldStart = false;
            return;
        }

        transformToMove.position = Vector3.Lerp(pointA.position, pointB.position, _passedTime/duration);
        transformToMove.rotation = Quaternion.Lerp(pointA.rotation,pointB.rotation, _passedTime/duration);

        _passedTime += Time.deltaTime;

    }

    public override void Excute()
    {
        _souldStart = true;
    }
}
