using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class shadowSortingLayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		WithForeachLoop();
	}

	void WithForeachLoop ()
	{
		var treeId = 0;
        foreach ( Transform child in transform)
        {
			var FGSortOrder = (treeId % 2) + 1;
			var treeObj = child.Find("Tree").GetComponent<SpriteRenderer>();
			/*	SerializedObject tagsAndLayersManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
				Debug.Log(tagsAndLayersManager);
				SerializedProperty sortingLayersProp = tagsAndLayersManager.FindProperty("m_SortingLayers");
				Debug.Log(sortingLayersProp.arraySize);
				sortingLayersProp.InsertArrayElementAtIndex(sortingLayersProp.arraySize -1);
				var newlayer = sortingLayersProp.GetArrayElementAtIndex(sortingLayersProp.arraySize-1);
				newlayer.FindPropertyRelative("uniqueID").intValue = treeId;
				newlayer.FindPropertyRelative("name").stringValue = "Tree" + treeId;
				tagsAndLayersManager.ApplyModifiedProperties();
				treeObj.sortingLayerName = "Tree" + treeId;*/

			treeObj.sortingLayerName = "FGAssets0" + FGSortOrder;

			var shadowObj = child.Find("TreeShadow").GetComponent<ShadowCaster2D>();

			var fieldInfo = typeof(ShadowCaster2D).GetField("m_ApplyToSortingLayers", BindingFlags.Instance | BindingFlags.NonPublic);

			fieldInfo.SetValue(shadowObj, new[] { 1, 2, 3 });
			treeId++;
		}
	}
}
