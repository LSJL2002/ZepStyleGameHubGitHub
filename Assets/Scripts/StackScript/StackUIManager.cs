using UnityEngine;

public enum UIState
{
    Home,
    Game,
    Score,
}

public class StackUIManager : MonoBehaviour
{
    static StackUIManager instance;
    public static StackUIManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    UIState currentState = UIState.Home;
    
    HomeUI homeUI = null;

    GameUI gameUI = null;

    ScoreUI scoreUI = null;

    TheStack theStack = null;
    private void Awake()
    {
        instance = this;
        theStack = FindObjectOfType<TheStack>();
        
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);
        
        ChangeState(UIState.Home);
    }


    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }
    
    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    
    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }
    
    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
    
        ChangeState(UIState.Score);
    }
}