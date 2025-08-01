using UnityEngine;

public abstract class StackBaseUI : MonoBehaviour
{
    protected StackUIManager uiManager;

    public virtual void Init(StackUIManager uiManager)
    {
        this.uiManager = uiManager;
    }
    
    protected abstract UIState GetUIState(); 
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}