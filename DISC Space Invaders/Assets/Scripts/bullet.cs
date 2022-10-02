using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed = 5f;

    public System.Action destroyed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.up * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
