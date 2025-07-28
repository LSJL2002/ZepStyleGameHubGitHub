using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CRBaseUI : MonoBehaviour
{
    protected CRUIManager uiManager; 

    public virtual void Init(CRUIManager manager) 
    {
        this.uiManager = manager; 
    }

    protected abstract CRUIState CRGetUIState();

    public void SetActive(CRUIState state)
    {
        gameObject.SetActive(CRGetUIState() == state);
    }
}

