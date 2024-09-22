using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public List<Sprite> cards = new List<Sprite>();

    public List<SpriteData> GetSprites(int gridSize)
    {
        List<SpriteData> tempSprites = new List<SpriteData>();

        HashSet<int> selectedIndices = new HashSet<int>(); // To avoid selecting the same card more than once

        while (tempSprites.Count < gridSize)
        {
            int randomIndex = Random.Range(0, cards.Count);

            // Avoid duplicate random selections by using a HashSet
            if (!selectedIndices.Contains(randomIndex))
            {
                SpriteData spriteData = new SpriteData();
                spriteData.sprite = cards[randomIndex];
                spriteData.pairId = randomIndex;

                selectedIndices.Add(randomIndex);
                // Add the card twice (one original and one copy)
                tempSprites.Add(spriteData);
                tempSprites.Add(spriteData);
            }
        }

        return Shuffle(tempSprites);
    }

    private List<SpriteData> Shuffle(List<SpriteData> sprites)
    {
        // Fisher-Yates shuffle algorithm for efficient random shuffling
        for (int spriteIndex = sprites.Count - 1; spriteIndex > 0; spriteIndex--)
        {
            int randomIndex = Random.Range(0, spriteIndex + 1);
            SpriteData temp = sprites[spriteIndex];
            sprites[spriteIndex] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
        return sprites;
    }
}
[System.Serializable]
public class SpriteData
{
    public Sprite sprite;
    public int pairId;
}