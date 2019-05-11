using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private GridLayoutGroup gridLayout;
    [HideInInspector]
    public Vector2 slotArtworkSize;

    public static CharacterSelection instance;
    [Header("Characters List")]
    public List<Character> characters = new List<Character>();
    [Space]
    [Header("Public References")]
    public GameObject charCellPrefab;
    public GameObject gridBgPrefab;
    public Transform playerSlotsContainer;
    [Space]
    [Header("Current Confirmed Character")]
    public Character confirmedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Character character in characters)
        {
            SpawnCharacterCell(character);
        }
    }

    private void SpawnCharacterCell(Character character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        Image artwork = charCell.transform.Find("artwork").GetComponent<Image>();
        TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.characterSprite;
        name.text = character.characterName;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        artwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
    }

        public void ConfirmCharacter(int player, Character character)
    {
        if (confirmedCharacter == null)
        {
            confirmedCharacter = character;
        }
    }

    public Vector2 uiPivot(Sprite sprite)
    {
        Vector2 pixelSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 pixelPivot = sprite.pivot;
        return new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);
    }

}
