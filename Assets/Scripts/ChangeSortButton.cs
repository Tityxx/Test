using UnityEngine;

public class ChangeSortButton : MonoBehaviour
{
    public GameObject button;

    public void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        button.SetActive(true);
    }
}
