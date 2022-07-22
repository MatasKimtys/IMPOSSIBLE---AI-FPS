using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public int rangeOfMotion;
    public float movementSpeed;
    float time;
    int index;
    Vector3 originalPosition, newPositionOffset;
    public TargetBehaviour behaviour;
    public bool dead;
    public int mutations;
    public GameObject gameManager;
    GameManager manager;
    public GameObject deathEffect;
    public TargetMover(TargetBehaviour behav, GameManager man, int mut)
    {
        dead = false;
        behaviour = behav;
        noObjectSetup();
        manager = man;
        mutations = mut;
    }
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        behaviour = this.gameObject.GetComponent<TargetBehaviour>();
        setup();
        manager = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {

        if (time == 0)
        {
            newPositionOffset = behaviour.positions[index] * rangeOfMotion;
        }

        Vector3 checkPos = gameObject.transform.position + newPositionOffset * movementSpeed * Time.deltaTime;

        if (checkPos.x > 200f - 0.5 || checkPos.x < -200f + 0.5)
        {
            newPositionOffset.x = -newPositionOffset.x;

        }
        if (checkPos.z > 200f - 0.5 || checkPos.z < -200f + 0.5)
        {
            newPositionOffset.z = -newPositionOffset.z;
        }
        if (checkPos.y > 20 - 0.5 || checkPos.y < 0 + 0.5)
        {
            newPositionOffset.y = -newPositionOffset.y;
        }

        gameObject.transform.position += newPositionOffset * movementSpeed * Time.deltaTime;

        time += movementSpeed * Time.deltaTime;

        if (time >= behaviour.times[index])
        {
            index++;
            time = 0;
            if (index >= behaviour.times.Length)
            {
                index = 0;
                time = 0;
            }
        }
        if (mutations < 1)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);
        }
        else if (mutations <= 2)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f);
        }
        else if (mutations <= 3)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f);
        }
    }

    private void OnMouseDown()
    {
        manager.addScore();
        dead = true;
        StartCoroutine(Death());
    }

    void setup()
    {
        originalPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(3.5f, 10f), Random.Range(-50f, 50f));
        gameObject.transform.position = originalPosition;
        time = 0;
        index = 0;
    }

    void noObjectSetup()
    {
        originalPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(3.5f, 10f), Random.Range(-50f, 50f));
        time = 0;
        index = 0;
    }

    public void setNewBehaviour(TargetBehaviour newBehaviour)
    {
        behaviour = newBehaviour;
    }

    IEnumerator Death() {
        deathEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
