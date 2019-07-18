using UnityEngine.EventSystems;
using UnityEngine;

// This script allows you to drag this GameObject using any finger, as long it has a collider
public class SimpleDrag2 : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, 
                         IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;



    //Se ejecuta repetidamente mientras se est� arrastrando
    public void OnDrag(PointerEventData eventData)
{
        this.transform.position = eventData.position;
        Debug.Log(eventData.pointerDrag.name + "Est� siendo arrastrado");

}

//Se ejecuta cuando ha empezado a arrastrarse, antes del OnDrag
public void OnBeginDrag(PointerEventData eventData)
{
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //startParent = transform.parent;
        //Debug.Log("Va a ser arrastrado");
    }

//Se ejecuta cuando se ha soltado, antes del OnDrop
public void OnEndDrag(PointerEventData eventData)
{
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
        //Debug.Log("Va a ser soltado");
}


//Se ejecuta al finalizar la pulsaci�n completa (levantar el dedo o rat�n)
public void OnPointerClick(PointerEventData eventData)
{
    //Debug.Log("Ha sido pulsado");
}

//Se ejecuta cuando el punto del rat�n pasa por encima
public void OnPointerEnter(PointerEventData eventData)
{
    Debug.Log("El rat�n est� encima");
}

//Se ejecuta cuando el puntero, despu�s de haber pasado por encima, sale de su collider
public void OnPointerExit(PointerEventData eventData)
{
    Debug.Log("El rat�n ya NO est� encima");
}

}