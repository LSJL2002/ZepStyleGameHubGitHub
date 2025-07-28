using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CRGameUI : CRBaseUI
{
    TextMeshProUGUI ScoreText;
    TextMeshProUGUI HighScoreText;
    protected override CRUIState CRGetUIState()
    {
        return CRUIState.Game;
    }

    public override void Init(CRUIManager uiManager)
    {
        base.Init(uiManager);

        ScoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        HighScoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        Debug.Log($"[CRGameUI] ScoreText found: {ScoreText != null}");
        Debug.Log($"[CRGameUI] HighScoreText found: {HighScoreText != null}");
    }

    public void SetUI(int score, int highscore)
    {
        ScoreText.text = score.ToString();
        HighScoreText.text = highscore.ToString();
    }
}
