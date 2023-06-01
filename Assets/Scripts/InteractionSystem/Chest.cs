using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour/*, IInteractable*/
{
    #region Expose
    [SerializeField] private GameObject openChestButton;
    [SerializeField] private Item item;
    [SerializeField] private float spawnerRadius;
    [SerializeField] private Color color;
    [SerializeField] private bool drawGizmo;
    //[SerializeField] private string _prompt;
    //[SerializeField] private GameObject _lootWindow;

    //public void Interact()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void StopInteract()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public string InteractionPrompt => _prompt;
    //public bool Interact(Interactor interactor)
    //{
    //    Debug.Log("Openig chest");
    //    _lootWindow.SetActive(true);
    //    Cursor.lockState = CursorLockMode.None;
    //    return true;
    //}
    #endregion

    #region Unity Life Cycle
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            openChestButton.gameObject.SetActive(true);
            ItemDrop(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openChestButton.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmo) 
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, spawnerRadius);
        }
    }
    #endregion

    #region methods
    private void ItemDrop(Item item)
    {
        Debug.Log("Item a récupérer");
        Vector3 position = Random.insideUnitCircle * spawnerRadius + (Vector2)transform.position;
        Item newItem = Instantiate(item, position, Quaternion.identity);
    }
    #endregion

    #region Private & Protected

    #endregion
}
