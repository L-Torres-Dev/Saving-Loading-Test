using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ChoosePokemon : MonoBehaviour
{
    [SerializeField] GameObject pokemonPanelPrefab;
    [SerializeField] TextMeshProUGUI descriptionText;

    public void GeneratePokemonPanels(List<BasePokemon> allPokemon)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        for(int i = 0; i < allPokemon.Count; i++)
        {
            BasePokemon pokemon = allPokemon[i];
            float xPos = (rectTransform.rect.width / 10) + (200 * i);

            Vector2 panelPosition = new Vector2(xPos, transform.position.y + 100);

            GameObject panel = Instantiate(pokemonPanelPrefab, transform);
            panel.transform.position = panelPosition;

            PokemonPanel pokemonPanel = panel.GetComponent<PokemonPanel>();
            Sprite sprite = getPokemonSprite(pokemon.Id);

            pokemonPanel.SetCanvas(this);
            pokemonPanel.SetPokemonData(pokemon);
            pokemonPanel.SetNameText(pokemon.Name);
            pokemonPanel.SetImageSprite(sprite);
        }
    }

    public void SetDescription(string text)
    {
        descriptionText.text = text;
    }

    private Sprite getPokemonSprite(string id)
    {
        string appPath = Application.dataPath;
        string spriteFilePath = appPath + "/Resources/Images/" + id + ".png";

        byte[] fileData = File.ReadAllBytes(spriteFilePath);

        Texture2D pokemonTexture = new Texture2D(2, 2);
        pokemonTexture.LoadImage(fileData);
        
        if (pokemonTexture == null)
        {
            Debug.LogError("Could not load sprite texture at path: " + spriteFilePath);
            return null;
        }
        
        Sprite sprite = Sprite.Create(pokemonTexture, new Rect(0, 0, pokemonTexture.width, pokemonTexture.height), Vector2.zero);

        return sprite;
    }
}
