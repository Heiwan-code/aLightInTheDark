using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSortingLayerOrder : MonoBehaviour
{
    public bool moving;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
		renderer = GetComponent<SpriteRenderer>();
        updateLayer();
		if ( moving )
        {
			InvokeRepeating("updateLayer", 0, 0.05F);
		}
	}

    private void updateLayer ()
    {
        renderer.sortingOrder = ( int ) ( renderer.transform.position.y * -100 );
    }
}
