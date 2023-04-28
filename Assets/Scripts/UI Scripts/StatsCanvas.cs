using UnityEngine;
using TMPro;
using Assets.Scripts;

public class StatsCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpStat;
    [SerializeField] TextMeshProUGUI attackStat;
    [SerializeField] TextMeshProUGUI defenseStat;
    [SerializeField] TextMeshProUGUI specialAttackStat;
    [SerializeField] TextMeshProUGUI specialDefenseStat;
    [SerializeField] TextMeshProUGUI speedStat;
    [SerializeField] PokemonPanel pokemonPanel;

    public delegate void ChangePokemonStat(int increment);
    public ChangePokemonStat onIncrementHp;
    public ChangePokemonStat onIncrementAttack;
    public ChangePokemonStat onIncrementDefense;
    public ChangePokemonStat onIncrementSpecialAttack;
    public ChangePokemonStat onIncrementSpecialDefense;
    public ChangePokemonStat onIncrementSpeed;

    public delegate void SaveRequest();
    public SaveRequest onRequestSave;

    public void SetPokemonStatUI(Pokemon pokemon)
    {
        hpStat.text = pokemon.Health.ToString();
        attackStat.text = pokemon.Attack.ToString();
        defenseStat.text = pokemon.Defense.ToString();
        specialAttackStat.text = pokemon.SpecialAttack.ToString();
        specialDefenseStat.text = pokemon.SpecialDefense.ToString();
        speedStat.text = pokemon.Speed.ToString();
    }

    public void incrementHP()
    {
        onIncrementHp?.Invoke(1);
    }

    public void incrementAttack()
    {
        onIncrementAttack?.Invoke(1);
    }

    public void incrementDefense()
    {
        onIncrementDefense?.Invoke(1);
    }

    public void incrementSpecialAttack()
    {
        onIncrementSpecialAttack?.Invoke(1);
    }

    public void incrementSpecialDefense()
    {
        onIncrementSpecialDefense?.Invoke(1);
    }

    public void incrementSpeed()
    {
        onIncrementSpeed?.Invoke(1);
    }

    public void RequestSave()
    {
        onRequestSave?.Invoke();
    }

    public void SetPanel(BasePokemon pokemon, Sprite sprite)
    {
        pokemonPanel.SetPokemonData(pokemon);
        pokemonPanel.SetImageSprite(sprite);
    }
}
