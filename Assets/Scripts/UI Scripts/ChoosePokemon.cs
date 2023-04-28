using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ChoosePokemon : MonoBehaviour
{
    [SerializeField] GameObject pokemonPanelPrefab;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI nameText;

    private BasePokemon currentPokemon;

    public delegate void PokemonChosen(BasePokemon pokemon);
    public PokemonChosen onPokemonChosen;

    public void GeneratePokemonPanels(List<BasePokemon> allPokemon, JsonPokemonLoader loader)
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
            Sprite sprite = loader.GetPokemonSprite(pokemon.Id);

            pokemonPanel.SetCanvas(this);
            pokemonPanel.SetPokemonData(pokemon);
            pokemonPanel.SetNameText(pokemon.Name);
            pokemonPanel.SetImageSprite(sprite);
        }
    }

    public void SelectPokemon()
    {
        if (currentPokemon != null)
        {
            onPokemonChosen?.Invoke(currentPokemon);

            gameObject.SetActive(false);
        }
    }

    public void SetCurrentPokemon(BasePokemon pokemon)
    {
        currentPokemon = pokemon;
        SetDescription(currentPokemon.Description);
        SetName(currentPokemon.Name);
    }

    private void SetDescription(string text)
    {
        descriptionText.text = text;
    }

    private void SetName(string text)
    {
        nameText.text = text;
    }
}
