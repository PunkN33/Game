using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyInventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;  
    public GameObject cellContainer;
    public int ItemSwitch = 0; 

    private void Start()
    {
        item = new List<Item>();

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
            //transform.GetChild(i).gameObject.AddComponent<Item>();            
        }
        SelectItem();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item[i].id == 0)
                        {
                            item[i] = hit.collider.GetComponent<Item>();
                            DisplayItem();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }
        }

        int currentItem = ItemSwitch;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            if (ItemSwitch >= cellContainer.transform.childCount - 1)
            {
                ItemSwitch = 0;
            }
            else
            {
                ItemSwitch++;
            }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            if (ItemSwitch <= 0)
            {
                ItemSwitch = cellContainer.transform.childCount - 1;
            }
            else
            {
                ItemSwitch--;
            }
        if (currentItem != ItemSwitch)
        {
            SelectItem();
        }
    }

    public void DisplayItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                img.enabled = true;
                img.sprite = item[i].icon;
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }

    void SelectItem()
    {
        int j = 0;
        foreach (Transform Cell in transform)
        {
            if (j == ItemSwitch)
            {
                Cell.gameObject.GetComponent<Image>().enabled = true;
                if (item[ItemSwitch].prefab != null)
                {
                    item[ItemSwitch].prefab.SetActive(true);
                }
            }
            else
            {
                Cell.gameObject.GetComponent<Image>().enabled = false;
                if (item[j].prefab != null)
                {
                    item[j].prefab.SetActive(false);
                }
            }
            j++;
        }
    }
}
