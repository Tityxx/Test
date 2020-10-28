using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject label;

    void Start()
    {

    }

    private void OnMouseDown()
    {
        label.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
