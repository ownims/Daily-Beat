using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            GameController gc = FindObjectOfType<GameController>();
            if (gc.speed > 0) {
                gc.speed -= 0.086f;
                if (gc.speed < 0) {
                    gc.speed = 0;
                    gc.Moving = false;
                }
            }
        }
    }

}
