using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public bool jogo;
    public Button start;
    public Button restart;
    public Controlador respawnColuna;
    public Text text, ponts;

    // Start is called before the first frame update
    void Start()
    {
        jogo = false;
        restart.interactable = false;
        text.text = "";
        ponts.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(start.interactable == false && jogo == false)
        {
            restart.interactable = true;
        }
    }

    public void ButtonClick()
    {
        Vector3 positionRespawn = respawnColuna.respawn.transform.position;
        jogo = true;
        start.interactable = false;
        restart.interactable = false;
        Instantiate(
            respawnColuna.coluna, 
            new Vector3(positionRespawn.x, positionRespawn.y, positionRespawn.z), 
            Quaternion.identity
        );
        respawnColuna.temp = 5.0f;
    }
}
