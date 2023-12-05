using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialAction : SequanceAction
{
    [SerializeField] private Material newMaterial;



    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void Excute()
    {
        //skip if no mat
        if(newMaterial == null)
        {
            OnComplete?.Invoke();
            return;
        }

        meshRenderer.materials[0] = newMaterial;
        OnComplete?.Invoke();

    }
}
