using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private Player player;

    [Header("Minigame UI")]
    public GameObject MiniGamePanel;
    public TMPro.TMP_Text titleText;
    public TMPro.TMP_Text descriptionText;
    private MiniGameData currentData;
    [Header("SidebarUI")]
    public GameObject GameStats;
    [Header("AllGameScoreUI")]
    public TMPro.TMP_Text stackscore;
    public TMPro.TMP_Text crossyRoadScore;
    [Header("Sidebar UI")]
    public GameObject Sidebar;
    public GameObject openSidebar;
    [Header("Character Custom")]
    public GameObject CharacterCustomUI;
    void Awake()
    {
        Instance = this;

        int stackBestScore = PlayerPrefs.GetInt("StackBestScore", 0);
        stackscore.text = stackBestScore.ToString();

        int crBestScore = PlayerPrefs.GetInt("CRBestScore", 0);
        crossyRoadScore.text = crBestScore.ToString();

        player = FindObjectOfType<Player>();
    }
    public void ShowMiniGameUI(MiniGameData data)
    {
        currentData = data;
        titleText.text = data.minigameName;
        descriptionText.text = data.description;
        MiniGamePanel.SetActive(true);
        player.SetCantMove(true);
    }

    public void OnClickPlayMiniGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentData.sceneToLoad);
    }
    public void OnClickCharacterCustomize()
    {
        CharacterCustomUI.SetActive(true);
        player.SetCantMove(true);
    }

    public void ClosePanel(GameObject go)
    {
        if (go == Sidebar)
        {
            go.SetActive(false);
            openSidebar.SetActive(true);
        }
        go.SetActive(false);
        player.SetCantMove(false);
    }
    public void OnClickGameStats()
    {
        GameStats.SetActive(true);
        player.SetCantMove(true);
    }
    public void OnClickSideBar()
    {
        Sidebar.SetActive(true);
        openSidebar.SetActive(false);
    }
}
