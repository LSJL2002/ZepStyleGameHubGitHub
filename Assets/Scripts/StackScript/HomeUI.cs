using UnityEngine;
using UnityEngine.UI;

public class HomeUI : StackBaseUI
{
    Button startButton;
    Button exitButton;
    
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
    
    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);
        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }


}