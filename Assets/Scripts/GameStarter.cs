using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;
using System.Linq;

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

        if (File.Exists(Application.persistentDataPath + "/gamestate.dat"))
        {
            print("File Exists");
            chooser.gameObject.SetActive(false);

            FileStream fileStream = File.Open(Application.persistentDataPath + "/gamestate.dat", FileMode.Open);
            BinaryReader reader = new BinaryReader(fileStream);

            string id = reader.ReadString();
            string name = reader.ReadString();
            float health = reader.ReadSingle();
            float attack = reader.ReadSingle();
            float defense = reader.ReadSingle();
            float specialAttack = reader.ReadSingle();
            float specialDefense = reader.ReadSingle();
            float speed = reader.ReadSingle();

            BasePokemon baseStats = allPokemon.Where(baseStat => baseStat.Id.Equals(id)).FirstOrDefault();

            Pokemon pokemon = new Pokemon(baseStats);
            print("Loaded Pokemon Base Stats: " + pokemon.ToString());

            pokemon.Health = health;
            pokemon.Attack = attack;
            pokemon.Defense = defense;
            pokemon.SpecialAttack = specialAttack;
            pokemon.SpecialDefense = specialDefense;
            pokemon.Speed = speed;

            print("Loaded Pokemon saved Stats: " + pokemon.ToString());

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

    private void LoadGame(Pokemon pokemon)
    {
        statsCanvas.gameObject.SetActive(true);

        Game game = new Game();
        game.SetPlayerPokemon(pokemon);
        SetupStatsCanvas(pokemon, game);
    }

    private void NewGame(BasePokemon baseStarter)
    {
        chooser.onPokemonChosen -= NewGame;

        statsCanvas.gameObject.SetActive(true);

        Pokemon starter = new Pokemon(baseStarter);
        Game game = new Game(starter);
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
