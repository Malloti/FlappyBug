using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controlador : MonoBehaviour
{
    public float vel = 3f;
    public GameObject coluna;
    public GameObject respawn;
    public float temp = 5.0f;
    public GameLogic controle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controle.jogo == true)
        {
            Temporizador();
            
            //Movimento do respawn da coluna
            transform.Translate(new Vector3(0, vel * Time.deltaTime, 0));
            if (respawn.transform.position.y >= -3.0)
            {
                vel = -3f;
            }
            else if (respawn.transform.position.y <= -5.3)
            {
                vel = 3f;
            }
        }
    }
    //Cria colunas ao atigir 0
    void Temporizador()
    {
        Vector3 positionRespawn = respawn.transform.position;
        temp -= Time.deltaTime;
        if(temp <= 0)
        {
            Instantiate(
                coluna, 
                new Vector3(positionRespawn.x, positionRespawn.y, positionRespawn.z), 
                Quaternion.identity
            );
            temp = 5.0f;
        }
    }
}
