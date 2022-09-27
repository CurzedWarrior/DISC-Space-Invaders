
using UnityEngine;

public class ClearBackground : MonoBehaviour
{
    public System.Action destroyed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.destroyed.Invoke();
            Destroy(this.gameObject);
        }
    }
}
