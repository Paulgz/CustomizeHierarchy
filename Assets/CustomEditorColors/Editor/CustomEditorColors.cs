using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CustomEditorColors : MonoBehaviour
{
    public static ColorPrefs prefs;

    static CustomEditorColors()
    {
        EditorApplication.hierarchyWindowItemOnGUI += onItem;
        string[] guids = AssetDatabase.FindAssets("t:"+ typeof(ColorPrefs).Name);
        if(guids.Length == 0) {
            return;
        }
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        prefs = AssetDatabase.LoadAssetAtPath<ColorPrefs>(path);
    }
    public  static  void    onItem(int  instanceId,Rect area)
    {
        //---check everything cool--------------------------------------
        if(prefs == null) {
            return;
        }
        Object obj=EditorUtility.InstanceIDToObject(instanceId);
        if(obj == null) {
            return;
        }
        GameObject  go=(obj as  GameObject);
        if(go == null) {
            return;
        }
        //---get entry info---------------------------------------------
        var prefabType=PrefabUtility.GetPrefabAssetType(obj);
        bool    isPrefab=(prefabType != PrefabAssetType.NotAPrefab);
        bool    on=go.activeInHierarchy;
        bool    selected=Selection.instanceIDs.Contains(instanceId);

        //---draw entry---------------------------------------------
        Color   frontColor = on ? prefs.on : prefs.off;
        Color   backColor = on ? prefs.backOn : prefs.backOff;
        EditorGUI.DrawRect(area, backColor);
        var style=new   GUIStyle(){
            normal=new  GUIStyleState(){textColor=frontColor },
            fontStyle=on?FontStyle.Bold:FontStyle.Italic
        };
        EditorGUI.LabelField(   area, 
                                (isPrefab?"[X]":"")+obj.name, 
                                style);
    }
}
