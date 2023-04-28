using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PokemonPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image image;
    private ChoosePokemon choosePokemonCanvas;

    private BasePokemon pokemonData;

    public void SetCanvas(ChoosePokemon canvas)
    {
        choosePokemonCanvas = canvas;
    }
    public void SetPokemonData(BasePokemon pokemon)
    {
        pokemonData = pokemon;
    }
    public void SetNameText(string text)
    {
        nameText.text = text;
    }

    public void SetImageSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void OnClick()
    {
        choosePokemonCanvas.SetCurrentPokemon(pokemonData);
    }
}
