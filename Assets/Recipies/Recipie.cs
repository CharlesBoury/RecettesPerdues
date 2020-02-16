using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bonus{
  aucun, touille, sel, poivre, mijote
};

[System.Serializable]
public class IngredientState
{
    public string ingredient;
    public Bonus bonus;
}

public class Recipie : MonoBehaviour
{
  [Header("Description")]
  public string Title;
  public string Description;

  [Header("Ingredients")]
  public List<IngredientState> lstIngredients = new List<IngredientState> ();

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
