using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NuevoCambiarImagen : MonoBehaviour
{
    // The output of the image
    public Image img;

    // The source image
    public string url = "https://clipground.com/images/monkey-baby-clipart-14.jpg";

    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 1);
    }





}
