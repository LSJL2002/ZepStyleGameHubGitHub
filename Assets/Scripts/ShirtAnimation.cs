using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShirtAnimation : MonoBehaviour
{
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer shirtRenderer;
    public Sprite[] bodySprites;

    public Sprite[] shirtSprites1;
    public Sprite[] shirtSprites2;
    public CharacterCustomize characterCustomize;
    void Update()
    {
        Sprite currentBody = bodyRenderer.sprite;
        for (int i = 0; i < bodySprites.Length; i++)
        {
            if (bodySprites[i] == currentBody)
            {
                int clothesIndex = characterCustomize.currentClothesIndex;

                switch (clothesIndex)
                {
                    case 1:
                        {
                            if (i < shirtSprites1.Length)
                            {
                                shirtRenderer.sprite = shirtSprites1[i];
                            }
                            else
                            {
                                shirtRenderer.sprite = null;
                                Debug.Log("Error Occured");
                            }
                            break;
                        }
                    case 2:
                        {
                            if (i < shirtSprites2.Length)
                            {
                                shirtRenderer.sprite = shirtSprites2[i];
                            }
                            else
                            {
                                shirtRenderer.sprite = null;
                                Debug.Log("Error Occured");
                            }
                            break;
                        }
                    default:
                        shirtRenderer.sprite = null;
                        break;
                }
            }
        }
    }
}
