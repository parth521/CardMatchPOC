using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public List<Sprite> cards = new List<Sprite>();

    public List<Sprite> GetSprites(int gridSize)
    {
        List<Sprite> tempSprites = new List<Sprite>();

        HashSet<int> selectedIndices = new HashSet<int>(); // To avoid selecting the same card more than once

        while (tempSprites.Count < gridSize)
        {
            int randomIndex = Random.Range(0, cards.Count);

            // Avoid duplicate random selections by using a HashSet
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
                // Add the card twice (one original and one copy)
                tempSprites.Add(cards[randomIndex]);
                tempSprites.Add(cards[randomIndex]);
            }
        }

        return Shuffle(tempSprites);
    }

    private List<Sprite> Shuffle(List<Sprite> sprites)
    {
        // Fisher-Yates shuffle algorithm for efficient random shuffling
        for (int i = sprites.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Sprite temp = sprites[i];
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
        return sprites;
    }
}
