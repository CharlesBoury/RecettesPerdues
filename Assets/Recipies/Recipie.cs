using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{
  normal, brule, touille
};

[System.Serializable]
public class IngredientState
{
    public string ingredient;
    public State state;
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
