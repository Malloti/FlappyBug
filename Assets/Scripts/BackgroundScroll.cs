using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundScroll : MonoBehaviour
{
    public float xInicio;
    public float valorY, valorZ;
    public float xFinal;
    public float posEmenda;
    public float vel = 1.5f;
    public GameObject Background;
    public GameLogic controle;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(xInicio, valorY, valorZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (controle.jogo == true)
        {

            if (Background.transform.position.x <= xInicio)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }
            if (Background.transform.position.x <= xFinal)
            {
                transform.SetPositionAndRotation(new Vector3(posEmenda, valorY, valorZ), Quaternion.identity);
            }
        }
    }
}
