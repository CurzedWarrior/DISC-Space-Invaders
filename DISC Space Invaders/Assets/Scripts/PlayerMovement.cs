using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public bullet LaserPrefab;

    void Update()
    {
        //Taking player inputs to move and shoot
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //Shoot from the current location of player
        Instantiate(this.LaserPrefab, this.transform.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D other)         //When a box collider 2D triggers an other object
    {
        if (other.gameObject.name == "RightBoundary")       //If the object's name is = to "RightBoundary"
        {
            transform.Translate(2 * -speed * Time.deltaTime, 0, 0);     //Translate to the left by double that of movement speed
        }
        if (other.gameObject.name == "Left Boundary")
        {
            transform.Translate(2 * speed *Time.deltaTime,0 , 0);       //Translate to the right by double that of movement speed
        }

        //If aliens collide with player, delete the player and move to defeat scene
        if (other.gameObject.layer == LayerMask.NameToLayer("Alien"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }

}
