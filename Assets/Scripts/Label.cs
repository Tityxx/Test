using UnityEngine;

public class Label : MonoBehaviour
{
    public GameObject sight;

    public string country;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        print(country);
        sight.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
