using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShirtAnimation : MonoBehaviour
{
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer shirtRenderer;
    public Sprite[] bodySprites; //Base character sprites. 

    public Sprite[] shirtSprites1; //First shirt option
    public Sprite[] shirtSprites2; //Second shirt option
    public CharacterCustomize characterCustomize;
    void Update()
    {
        Sprite currentBody = bodyRenderer.sprite; //Getting the sprite of the current spirte of the player. We go through all the sprites in the sprites file until we find the same one. If the same one is found,  we find the same index shirt.
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
                    default: //If the option selected is not 1 or 2 it will just render nothing, thus the base character model. 
                        shirtRenderer.sprite = null;
                        break;
                }
            }
        }
    }
}
