using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;       //Array of prefabs called invaders
    public int rows = 5;
    public int columns = 11;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)                                                    //Spacing between invaders vertically
        {
            float width  = 2.0f * (this.columns -1);                                                 //This give me the total width and height of the columns and rows based on the
            float height = 2.0f * (this.rows - 1);                                                   //spacing that is set multiplied by the row or column take away 1
            Vector3 centering = new Vector2(-width / 2, -height / 2);                                //Finding the centre of the grid pattern
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);        //setting the row position using the centered x and y values

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);                    //spawning the Invaders from the prefabs within the row. It also stores the result of this to invader
                Vector3 position = rowPosition;
                position.x += col * 2.0f;                                                            //Spacing between the invaders horizontally
                invader.transform.localPosition = position;
            }
        }
    }

}
