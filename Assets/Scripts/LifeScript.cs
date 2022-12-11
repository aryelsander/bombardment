using UnityEngine;

public class LifeScript : MonoBehaviour {

    public int maxHealth;
    public int health;

    void Start() {
        health = maxHealth;
    }

}
