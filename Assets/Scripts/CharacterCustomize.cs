using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class CharacterCustomize : MonoBehaviour
{
    [Header("Renderes")]
    public Image clothesRender;
    [Header("Sprite Options")]
    public Sprite[] clothesOptions;
    [Header("CC UIs")]
    public GameObject buttonPrefab;
    public Transform optionsPanel;

    public int currentClothesIndex { get; private set; } = 0;

    void Start()
    {
        clothesRender.gameObject.SetActive(false);
        PopulateClothesOptions();
    }


    void PopulateClothesOptions()
    {
        foreach (Transform child in optionsPanel)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < clothesOptions.Length; i++)
        {
            int index = i;
            Sprite localImage = clothesOptions[i];
            int localIndex = i;

            GameObject newButton = Instantiate(buttonPrefab, optionsPanel);
            Image iconImage = newButton.transform.Find("Icon").GetComponent<Image>();
            iconImage.sprite = localImage;

            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                clothesRender.gameObject.SetActive(true);
                clothesRender.sprite = localImage;
                currentClothesIndex = localIndex;
                Debug.Log($"{index}");
            });
        }
    }
}
