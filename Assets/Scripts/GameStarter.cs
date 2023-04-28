using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;
using System;

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
        chooser.GeneratePokemonPanels(allPokemon, loader);
    }

    private void Start()
    {
        chooser.onPokemonChosen += NewGame;
    }

    private void NewGame(BasePokemon baseStarter)
    {
        chooser.onPokemonChosen -= NewGame;

        statsCanvas.gameObject.SetActive(true);

        Pokemon starter = new Pokemon(baseStarter);

        Game game = new Game(starter);

        Sprite starterSprite = loader.GetPokemonSprite(baseStarter.Id);
        statsCanvas.SetPanel(baseStarter, starterSprite);

        game.onStatChange += statsCanvas.SetPokemonStatUI;

        statsCanvas.onIncrementHp += game.incrementHP;
        statsCanvas.onIncrementAttack += game.incrementAttack;
        statsCanvas.onIncrementDefense += game.incrementDefense;
        statsCanvas.onIncrementSpecialAttack += game.incrementSpecialAttack;
        statsCanvas.onIncrementSpecialDefense += game.incrementSpecialDefense;
        statsCanvas.onIncrementSpeed+= game.incrementSpeed;
        game.NotifyOfStatChange();
    }
}
