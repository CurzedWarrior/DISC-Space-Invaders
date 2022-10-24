using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{

    public Invader[] prefabs;       //Array of prefabs called invaders
    public int rows = 5;
    public int columns = 11;
    public float speed = 5;
    public Vector3 direction {get; private set; } = Vector3.right;
    public Vector3 initialPosition { get; private set; }
    public System.Action<Invader> killed;

    public int AmountKilled {get; private set;}
    public int AmountAlive => this.TotalAmount - this.AmountKilled;
    public int TotalAmount => this.rows * this.columns;
    


    private void Awake()
    {
        initialPosition = transform.position;
        for (int row = 0; row < this.rows; row++)                                                    //Spacing between invaders vertically
        {
            float width  = 2.0f * (this.columns -1);                                                 //This give me the total width and height of the columns and rows based on the
            float height = 2.0f * (this.rows - 1);                                                   //spacing that is set multiplied by the row or column take away 1

            Vector3 centering = new Vector2(-width / 2, -height / 2);                                //Finding the centre of the grid pattern
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);        //setting the row position using the centered x and y values

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);                    //spawning the Invaders from the prefabs within the row. It also stores the result of this to invader
                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                
                position.x += col * 2.0f;                                                            //Spacing between the invaders horizontally
                invader.transform.localPosition = position;
            }
        }
        
    }
    private void Update()
    {  
        
        transform.position += direction * speed * Time.deltaTime;

        //Taking the coordinates of the viewport of the world so I can 
        //check when the invaders reach the edge of the screen
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            //Checking all the invaders for being disabled
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            
            //If the aliens reach the edge of the screen call Snaking()
            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                Snaking();
                break;
            }
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                Snaking();
                break;
            }

        }
        

    }
    private void Snaking()
    {
        direction = new Vector3(-direction.x, 0f, 0f);

        //Moving down a row
        Vector3 position = this.transform.position;
        position.y -= 1f;
        this.transform.position = position;
    }
    

    private void InvaderKilled()
    {
        this.AmountKilled++;

        if (this.AmountKilled >= this.TotalAmount)
        {
            SceneManager.LoadScene(3);
        }
    }

}
