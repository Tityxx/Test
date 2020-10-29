using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public GameObject sight;
    public string countryName;
    public int[] countryInfo;
    public Text[] infoPanel;
    public Country country = new Country();
    public GameObject clearList;
    public Text chooseN;
    public GameObject fullInfoPanel;

    private float time;

    void Start()
    {
        country.Name = countryName;
        country.Square = countryInfo[0];    //км^2
        country.VVP = countryInfo[1];   //млрд. долл.
        country.Population = countryInfo[2];    //чел.
    }

    private void OnMouseUpAsButton()
    {
        GameObject[] sights = GameObject.FindGameObjectsWithTag("Sight");
        foreach (GameObject s in sights)
        {
            s.GetComponent<Sight>().label.SetActive(true);
            s.SetActive(false);
        }
        sight.SetActive(true);
        this.gameObject.SetActive(false);
        chooseN.text = "";
        if ((Time.time - time) > 1.0)
        {
            Sight s = sight.GetComponent<Sight>();
            if (!s.selected)
            {
                s.selected = true;
                s.selectedGO.SetActive(true);
                infoPanel[0].text = "Площадь " + country.Square + " км^2";
                infoPanel[1].text = "ВВП " + country.VVP + " млрд. долл.";
                infoPanel[2].text = "Нас. " + country.Population + " чел.";
                clearList.SetActive(true);
                int sizeList = 1;
                GameObject[] labels = GameObject.FindGameObjectsWithTag("Label");
                foreach (GameObject l in labels)
                {
                    if (l.GetComponent<Label>().sight.GetComponent<Sight>().selected) sizeList++;
                }
                chooseN.text = "Выбрано стран - " + sizeList + ".";
                fullInfoPanel.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        time = Time.time;
    }
}

public class Country
{
    public string Name;
    public int Square;
    public int VVP;
    public int Population;
}
