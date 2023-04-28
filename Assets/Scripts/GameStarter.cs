using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;
using System.Linq;
using Assets.Scripts.SerializationScripts;

public class GameStarter : MonoBehaviour
{
    [SerializeField] ChoosePokemon chooser;
    [SerializeField] StatsCanvas statsCanvas;
    JsonPokemonLoader loader;
    List<BasePokemon> allPokemon;

    
    void Awake()
    {
        loader = new JsonPokemonLoader();
        allPokemon = new List<BasePokemon>();
        allPokemon = loader.LoadAllPokemon();

        string multiDirectoryPath = Application.persistentDataPath + "/saveFiles";

        IDeSerializer deserializer = new SimpleDeserializer();

        if (!Directory.Exists(multiDirectoryPath))
        {
            Directory.CreateDirectory(multiDirectoryPath);
        }


        if (deserializer.FileExists())
        {
            chooser.gameObject.SetActive(false);
            DeserializedData data = deserializer.Load();
            Pokemon pokemon = InitObjectsFromData(data);

            LoadGame(pokemon);
        }

        else
        {
            chooser.GeneratePokemonPanels(allPokemon, loader);
        }
    }

    private void Start()
    {
        chooser.onPokemonChosen += NewGame;
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

    private void LoadGame(Pokemon pokemon)
    {
        statsCanvas.gameObject.SetActive(true);

        Game game = new Game(new SimpleSerializer(pokemon));
        game.SetPlayerPokemon(pokemon);
        SetupStatsCanvas(pokemon, game);
    }

    private void NewGame(BasePokemon baseStarter)
    {
        chooser.onPokemonChosen -= NewGame;

        statsCanvas.gameObject.SetActive(true);

        Pokemon starter = new Pokemon(baseStarter);
        Game game = new Game(starter, new SimpleSerializer(starter));
        SetupStatsCanvas(starter, game);

    }

    private void SetupStatsCanvas(Pokemon starter, Game game)
    {
        BasePokemon baseStarter = starter.BaseStats;

        Sprite starterSprite = loader.GetPokemonSprite(baseStarter.Id);
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
