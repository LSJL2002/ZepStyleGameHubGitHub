using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CRUIState
{
    Title,
    Game,
    Score
}
public class CRUIManager : MonoBehaviour
{
    static CRUIManager instance;
    public static CRUIManager Instance
    {
        get
        {
            return instance;
        }
    }

    CRUIState currentState = CRUIState.Title;
    TitleUI titleUI = null;
    CRGameUI CRGameUI = null;
    CRScoreUI CRScoreUI = null;
    CRMovement crMovement = null;

    private void Awake()
    {
        instance = this;
        crMovement = FindObjectOfType<CRMovement>();
        titleUI = GetComponentInChildren<TitleUI>(true);
        titleUI.Init(this);
        CRGameUI = GetComponentInChildren<CRGameUI>(true);
        CRGameUI.Init(this);
        CRScoreUI = GetComponentInChildren<CRScoreUI>(true);
        CRScoreUI.Init(this);

        ChangeState(CRUIState.Title);
    }

    public void ChangeState(CRUIState state)
    {
        currentState = state;
        titleUI?.SetActive(currentState);
        CRGameUI?.SetActive(currentState);
        CRScoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        ChangeState(CRUIState.Game);
    }
    public void OnClickStartButtonNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CrossyRoad");
    }

    public void OnClickExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void SetScoreUI()
    {
        CRScoreUI.SetUI(crMovement.Score, crMovement.HighScore);

        ChangeState(CRUIState.Score);
    }
    public void UpdateScore()
    {
        CRGameUI.SetUI(crMovement.Score, crMovement.HighScore);
    }
}
