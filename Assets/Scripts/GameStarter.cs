using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;

public class GameStarter : MonoBehaviour
{
    [SerializeField] ChoosePokemon chooser;
    JsonPokemonLoader loader;

    List<BasePokemon> allPokemon;
    void Awake()
    {
        loader = new JsonPokemonLoader();
        allPokemon = new List<BasePokemon>();
        allPokemon = loader.LoadAllPokemon();
        chooser.GeneratePokemonPanels(allPokemon);
    }   
}
