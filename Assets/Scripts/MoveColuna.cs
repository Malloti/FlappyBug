using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MoveColuna : MonoBehaviour
{
    public float vel = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        vel = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }

    //Destroi a coluna caso o pássaro não esteja dentro do trigger
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
