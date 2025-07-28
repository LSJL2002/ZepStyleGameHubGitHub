using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CRScoreUI : CRBaseUI
{
    TextMeshProUGUI scoreNumber;
    TextMeshProUGUI highScoreNumber;
    Button startButton;
    Button exitButton;

    public override void Init(CRUIManager uiManager)
    {
        base.Init(uiManager);

        scoreNumber = transform.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        highScoreNumber = transform.Find("HighScoreNumber").GetComponent<TextMeshProUGUI>();
        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnClickStartButtonNewGame);
        exitButton.onClick.AddListener(OnClickExitButton);

    }
    protected override CRUIState CRGetUIState()
    {
        return CRUIState.Score;
    }
    public void SetUI(int score, int highScore)
    {
        scoreNumber.text = score.ToString();
        highScoreNumber.text = highScore.ToString();
    }

    void OnClickStartButtonNewGame()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }

}