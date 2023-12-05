using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SequanceAction : MonoBehaviour 
{

    public Action OnComplete;
    public abstract void Excute();
    
}
