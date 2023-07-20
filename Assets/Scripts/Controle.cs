using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Controle : MonoBehaviour
{
    public Rigidbody2D bird;
    public int pontos = 0;
    private int pontosH = 0;
    private float aux;
    public float vel = 1.0f;
    public float forca = 50f;
    private float temp = 1.0f;
    public bool fim = false;
    private bool controlaAnim = false;
    public GameObject localBird;
    public GameObject respawn;
    public Animator anim;
    public Text ponts;
    public GameLogic controle;
    public AudioSource pulo;
    

    // Start is called before the first frame update
    void Start()
    {
        aux = bird.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (controle.jogo == true)
        {
            controle.text.text = "";
            controle.ponts.text = "";
            ponts.text = pontos.ToString();
            if (pontos > pontosH)
            {
                pontosH = pontos;
            }
            Pulo();
            
            //Ajusta a posição do Pássaro ao iniciar o jogo
            if (fim == true)
            {
                Vector3 positionRespawn = respawn.transform.position;
                transform.SetPositionAndRotation(
                    new Vector3(positionRespawn.x, positionRespawn.y, positionRespawn.z), 
                    Quaternion.identity
                );
                fim = false;
            }

            //Ajusta a rotação do passáro caso ele estiver subindo e caso estiver descendo
            if (bird.transform.position.y > aux)
            {
                bird.SetRotation(30);
                aux = bird.transform.position.y;
            }
            if (bird.transform.position.y < aux)
            {
                bird.SetRotation(-30);
                aux = bird.transform.position.y;
            }
            
            //Controle da animação do pássaro usando o tempo
            if (controlaAnim == true)
            {
                temp -= Time.deltaTime;
                if (temp <= 0)
                {
                    anim.SetBool("Voa", false);
                    temp = 1.0f;
                }
            }
        }
        else
        {
            controle.text.text = "High Score";
            controle.ponts.text = pontosH.ToString();
        }
    }

    void Pulo()
    {
        if (fim == false && Input.GetKeyDown(KeyCode.Space))
        {
            bird.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
            bird.SetRotation(-30);
            pulo.Play();
            anim.SetBool("Voa", true);
            controlaAnim = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 spritePosition = localBird.transform.position;
        if (collision.gameObject.CompareTag("Finish"))
        {
            fim = true;
            pontos = 0;
            transform.SetPositionAndRotation(
                new Vector3(spritePosition.x, spritePosition.y, spritePosition.z), 
                Quaternion.identity
            );
            if (controle.jogo == true)
            {
                controle.jogo = false;
                controle.restart.interactable = true;
            }
        }
        if (collision.gameObject.CompareTag("Limitador"))
        {
            transform.SetPositionAndRotation(
                new Vector3(spritePosition.x, spritePosition.y, spritePosition.z), 
                Quaternion.identity
            );
        }
    }

    //Verifica se o Pássaro passou pela coluna
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pontuador"))
        {
            pontos++;
        }
    }

    //Verifica se o Pássaro bateu na coluna
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 spritePosition = localBird.transform.position;
        if (collision.gameObject.CompareTag("Coluna"))
        {
            transform.SetPositionAndRotation(
                new Vector3(spritePosition.x, spritePosition.y, spritePosition.z), 
                Quaternion.identity
            );
        }
    }
}

