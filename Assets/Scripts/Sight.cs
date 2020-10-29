using UnityEngine;
using UnityEngine.UI;

public class Sight : MonoBehaviour
{
    public GameObject label;
    public GameObject selectedGO;
    public GameObject clearList;
    public bool selected = false;
    public GameObject fullInfoPanel;

    void Start()
    {

    }

    private void OnMouseUpAsButton()
    {
        if(!selected)
        {
            selected = true;
            selectedGO.SetActive(true);
            Label l = label.GetComponent<Label>();
            l.infoPanel[0].text = "Площадь " + l.country.Square + " км^2";
            l.infoPanel[1].text = "ВВП " + l.country.VVP + " млрд. долл.";
            l.infoPanel[2].text = "Нас. " + l.country.Population + " чел.";
            clearList.SetActive(true);
            fullInfoPanel.SetActive(true);
        }
        else
        {
            selected = false;
            selectedGO.SetActive(false);
            int sizeList = 0;
            GameObject[] labels = GameObject.FindGameObjectsWithTag("Label");
            foreach (GameObject l in labels)
            {
                if (l.GetComponent<Label>().sight.GetComponent<Sight>().selected) sizeList++;
            }
            if (sizeList == 0) clearList.SetActive(false);
        }
    }
}
