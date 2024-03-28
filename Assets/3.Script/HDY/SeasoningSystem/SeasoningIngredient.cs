using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasoningIngredient : MonoBehaviour
{
    public enum Pepper_S
    {
        None = 0,
        Peppered,
   }
    public enum Salt_S
    {
        None = 0,
        Salted
    }

    public Pepper_S pepper_s = Pepper_S.None;
    public Salt_S salt_s = Salt_S.None;



    public void AddSeasoning(SeasonType season)
    {
        switch (season)
        {
            case SeasonType.salt:
                salt_s = Salt_S.Salted;
                break;
            case SeasonType.pepper:
                pepper_s = Pepper_S.Peppered;
                break;
            default:
                break;
        }

    }
}
