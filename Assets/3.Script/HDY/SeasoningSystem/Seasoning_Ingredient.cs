using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning_Ingredient : MonoBehaviour
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

    public Pepper_S pepper_s;
    public Salt_S salt_s;

    private void Start()
    {
        pepper_s = Pepper_S.None;
        salt_s = Salt_S.None;
    }

    public void AddSeasoning(Season_Type season)
    {
        switch (season)
        {
            case Season_Type.salt:
                salt_s = Salt_S.Salted;
                break;
            case Season_Type.pepper:
                pepper_s = Pepper_S.Peppered;
                break;
            default:
                break;
        }

    }
}
