using TMPro;
using UnityEngine;

public class GameUI : StackBaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI maxComboText;
    
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);
        
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
        maxComboText = transform.Find("MaxComboText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score, int combo, int maxCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        maxComboText.text = maxCombo.ToString();
    }
}