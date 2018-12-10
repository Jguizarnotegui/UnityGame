using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int health;
    public int ammo;
    //public int killCount;
    public float[] position;

    public PlayerData (PlayerCharacter player)
    {
        health = player._health;
        ammo = player._ammo;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
