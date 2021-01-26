using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public bool Moving = false;
    public bool Paused = true;

    public GameObject Prefab_Player;
    public GameObject Prefab_Bg0;
    public GameObject Prefab_Bg1;
    private float bgsize = 110;
    private Vector3 bgpos = new Vector3(0, 0, 50);
    private Vector3 bgendpos = new Vector3(-111, 0, 50);
    private Vector3 bgnextpos = new Vector3(110, 0, 50);
    private Vector3 spawnpos = new Vector3(-5.75f, 14.5f, 0);
    public float speedBKP;
    public float speed = 3f;
    public float speedAux = 0f;
    public float speedDash = 15f;
    public float jumpForce = 6f;
    public GameObject bgobj1;
    public GameObject bgobj2;
    public GameObject player;
    public Transform scene;

    void Start() {
        bgobj1 = Instantiate(Prefab_Bg0);
        bgobj1.transform.position = bgpos;

        bgobj2 = Instantiate(Prefab_Bg1);
        bgobj2.transform.position = bgnextpos;
        player = Instantiate(Prefab_Player);
        if (player != null) {
            player.transform.position = spawnpos;
        }
    }

    void Update() {
        if (!Paused) {
            if (Moving) {
                speedBKP = speed + speedAux;


                if (bgobj1.transform.position.x < bgendpos.x) {
                    bgobj1.transform.position = bgnextpos;
                }
                if (bgobj2.transform.position.x < bgendpos.x) {
                    bgobj2.transform.position = bgnextpos;
                }
                bgobj1.transform.position -= Vector3.right * speedBKP * Time.deltaTime;
                bgobj2.transform.position -= Vector3.right * speedBKP * Time.deltaTime;

                scene.position -= Vector3.right * speedBKP * Time.deltaTime;

                //player.transform.position += Vector3.right * speed * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space)) {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector3.down * jumpForce * 2, ForceMode2D.Impulse);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    speedAux += speedDash;
                }

                if (speedAux > 0) {
                    speedAux -= Time.deltaTime * 20;
                    if (speedAux < 0) {
                        speedAux = 0;
                    }
                }
            }
        }
    }
}
