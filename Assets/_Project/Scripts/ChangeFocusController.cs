using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeFocusController : MonoBehaviour
{
    public GameObject subMenu;
    public Button thisObject;
    public Button cancelButton;

    private bool inSubMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        //target = this.gameObject.GetComponent<Button>();
    }

    public void ChangeFocusToTarget()
    {
        Selectable newSelectable = thisObject;
        newSelectable.Select();
    }

    public void ChangeFocusToTheRight()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = thisObject.FindSelectableOnRight();
        newSelectable.Select();
    }

    public void ChangeFocusToTheLeftToMain()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = thisObject.FindSelectableOnLeft();
        newSelectable.Select();


    }

    public void ChangeFocusToTheLeft()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = thisObject.FindSelectableOnLeft();
        newSelectable.Select();

        
    }

    public void ShowSubMenu()
    {
        subMenu.SetActive(true);
        ChangeFocusToTheRight();
        inSubMenu = true;
    }

    public void CloseSubMenu()
    {
        subMenu.SetActive(false);
        inSubMenu = false;
    }
}
