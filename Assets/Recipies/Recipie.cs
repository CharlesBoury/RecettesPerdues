using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bonus{
  aucun, touille, mijotefort, mijotefaible
};

[System.Serializable]
public class IngredientState
{
    public string ingredient;
    public Bonus bonus;
}

[System.Serializable]
public class Condiments
{
  [Range(0.0f, 1.0f)]
  public float sel;
  [Range(0.0f, 1.0f)]
  public float poivre;
  [Range(0.0f, 1.0f)]
  public float miel;
  [Range(0.0f, 1.0f)]
  public float soja;
  [Range(0.0f, 1.0f)]
  public float huile;
  [Range(0.0f, 1.0f)]
  public float coco;

  public void Init() {
    sel = 0.0f;
    poivre = 0.0f;
    miel = 0.0f;
    soja = 0.0f;
    huile = 0.0f;
    coco = 0.0f;
  }
}

public class Recipie : MonoBehaviour
{
  [Header("Description")]
  public string Title;
  public string Description;

  [Header("Ingredients")]
  public List<IngredientState> lstIngredients = new List<IngredientState> ();
  public Condiments condiments;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
