using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        switch (tag)
        {
            case "Dead":
                Gamemanager.instance.GameEnd();
                break;

            case "Point":
                Gamemanager.instance.UpdateScore(20,1);
                break;
            
            case "Side":
                Gamemanager.instance.UpdateScore(10,0);
                break;

            case "Flipper":
                Gamemanager.instance.multiplier = 1;
                break;

            default:
                break;

        }
    }
}
