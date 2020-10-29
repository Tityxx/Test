using UnityEngine;
using UnityEngine.UI;

public class ClearListButton : MonoBehaviour
{
    public Text chooseN;
    public Camera mainCamera;
    public Camera uiCamera;
    public Text[] countryText1;
    public Text[] countryText2;
    public Text[] countryText3;
    public Text[] countryText4;

    private Text[][] texts = new Text[4][];
    private Country[] countries = new Country[4];

    public void Start()
    {
        texts[0] = countryText1;
        texts[1] = countryText2;
        texts[2] = countryText3;
        texts[3] = countryText4;
    }

    public void Click()
    {
        chooseN.text = "";
        GameObject[] labels = GameObject.FindGameObjectsWithTag("Label");
        GameObject[] sights = GameObject.FindGameObjectsWithTag("Sight");
        foreach (GameObject l in labels)
        {
            Sight ss = l.GetComponent<Label>().sight.GetComponent<Sight>();
            ss.selected = false;
            ss.selectedGO.SetActive(false);
        }
        foreach (GameObject s in sights)
        {
            Sight ss = s.GetComponent<Sight>();
            ss.selected = false;
            ss.selectedGO.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }

    public void SwitchToMainCamera()
    {
        uiCamera.depth = 0;
        for (int i = 0; i < texts.Length; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                texts[i][j].text = " ";
            }
        }
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i] = null;
        }
    }

    public void SwitchToUICamera()
    {
        uiCamera.depth = 2;
        int sizeList = 0;
        GameObject[] labels = GameObject.FindGameObjectsWithTag("Label");
        GameObject[] sights = GameObject.FindGameObjectsWithTag("Sight");
        foreach (GameObject s in sights)
        {
            Sight ss = s.GetComponent<Sight>();
            if(ss.selected)
            {
                countries[sizeList++] = ss.label.GetComponent<Label>().country;
            }
        }
        foreach (GameObject l in labels)
        {
            Sight ss = l.GetComponent<Label>().sight.GetComponent<Sight>();
            if (ss.selected)
            {
                countries[sizeList++] = l.GetComponent<Label>().country;
            }
        }
    }

    public void DoList()
    {
        for (int i = 0; i < countries.Length; i++)
        {
            if(countries[i] != null)
            {
                texts[i][0].text = countries[i].Name;
                texts[i][1].text = countries[i].Square.ToString();
                texts[i][2].text = countries[i].Population.ToString();
                texts[i][3].text = countries[i].VVP.ToString();
            }
        }
    }

    public void sortSquare(bool f)
    {
        for(int i = countries.Length - 1; i > 0; i--)
        {
            for(int j = 0; j < i; j++)
            {
                if (countries[i] != null && countries[j] != null)
                {
                    if (f)  //по возрастанию
                    {
                        if (countries[j].Square > countries[j+1].Square)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                    else    //по убыванию
                    {
                        if (countries[j].Square < countries[j + 1].Square)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                }
            }
        }
    }

    public void sortPopulation(bool f)
    {
        for (int i = countries.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (countries[i] != null && countries[j] != null)
                {
                    if (f)  //по возрастанию
                    {
                        if (countries[j].Population > countries[j + 1].Population)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                    else    //по убыванию
                    {
                        if (countries[j].Population < countries[j + 1].Population)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                }
            }
        }
    }

    public void sortVVP(bool f)
    {
        for (int i = countries.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (countries[i] != null && countries[j] != null)
                {
                    if (f)  //по возрастанию
                    {
                        if (countries[j].VVP > countries[j + 1].VVP)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                    else    //по убыванию
                    {
                        if (countries[j].VVP < countries[j + 1].VVP)
                        {
                            Country country = countries[j];
                            countries[j] = countries[j + 1];
                            countries[j + 1] = country;
                        }
                    }
                }
            }
        }
    }
}
