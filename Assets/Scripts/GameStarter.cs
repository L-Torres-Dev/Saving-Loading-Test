using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System.Linq;
using Assets.Scripts.SerializationScripts;

public class GameStarter : MonoBehaviour
{
    [SerializeField] ChoosePokemon chooser;
    [SerializeField] StatsCanvas statsCanvas;
    [SerializeField] MainMenu mainMenu;
    JsonPokemonLoader dbLoader;
    List<BasePokemon> allPokemon;

    private IDeSerializer deserializer;
    void Awake()
    {
        dbLoader = new JsonPokemonLoader();
        allPokemon = new List<BasePokemon>();
        allPokemon = dbLoader.LoadAllPokemon();

        deserializer = new SimpleDeserializer();

        if (!deserializer.FileExists())
        {
            mainMenu.DeactivateContinue();
        }
    }

    private void Start()
    {
        mainMenu.onContinue += LoadGame;
        mainMenu.onNewGame += NewGame;
        chooser.onPokemonChosen += BeginNewGame;
    }

    private Pokemon InitObjectsFromData(DeserializedData data)
    {
        BasePokemon baseStats = allPokemon.Where(baseStat => baseStat.Id.Equals(data.Id)).FirstOrDefault();

        Pokemon pokemon = new Pokemon(baseStats);

        pokemon.Health = data.Health;
        pokemon.Attack = data.Attack;
        pokemon.Defense = data.Defense;
        pokemon.SpecialAttack = data.SpecialAttack;
        pokemon.SpecialDefense = data.SpecialDefense;
        pokemon.Speed = data.Speed;

        return pokemon;
    }

    private void LoadGame()
    {
        DeserializedData data = deserializer.Load();
        Pokemon pokemon = InitObjectsFromData(data);
        statsCanvas.gameObject.SetActive(true);

        Game game = new Game(new SimpleSerializer(pokemon));
        game.SetPlayerPokemon(pokemon);
        SetupStatsCanvas(pokemon, game);
    }

    

    private void BeginNewGame(BasePokemon baseStarter)
    {
        chooser.onPokemonChosen -= BeginNewGame;

        statsCanvas.gameObject.SetActive(true);

        Pokemon starter = new Pokemon(baseStarter);
        Game game = new Game(starter, new SimpleSerializer(starter));
        SetupStatsCanvas(starter, game);

    }

    private void NewGame()
    {
        chooser.gameObject.SetActive(true);
        chooser.GeneratePokemonPanels(allPokemon, dbLoader);
    }

    private void SetupStatsCanvas(Pokemon starter, Game game)
    {
        BasePokemon baseStarter = starter.BaseStats;

        Sprite starterSprite = dbLoader.GetPokemonSprite(baseStarter.Id);
        statsCanvas.SetPanel(baseStarter, starterSprite);

        game.onStatChange += statsCanvas.SetPokemonStatUI;

        statsCanvas.onIncrementHp += game.incrementHP;
        statsCanvas.onIncrementAttack += game.incrementAttack;
        statsCanvas.onIncrementDefense += game.incrementDefense;
        statsCanvas.onIncrementSpecialAttack += game.incrementSpecialAttack;
        statsCanvas.onIncrementSpecialDefense += game.incrementSpecialDefense;
        statsCanvas.onIncrementSpeed += game.incrementSpeed;
        statsCanvas.onRequestSave += game.Save;
        game.NotifyOfStatChange();
    }
}
