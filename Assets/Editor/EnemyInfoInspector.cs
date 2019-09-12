using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
[CustomEditor(typeof(EnemyInfo))]//可以编辑ScriptableObject的属性面板
public class EnemyInfoInspector : Editor
{
    private ReorderableList actionTypeList, propertyList;//属性面板的链表类
    bool openList0, openList1;//控制链表的收缩展开
    EnemyInfo enemyInfo;//编辑对象

    private void OnEnable()
    {
        enemyInfo = ((EnemyInfo)target);
        actionTypeList = new ReorderableList(serializedObject, serializedObject.FindProperty("actionTypeList"), true, true, true, true);
        actionTypeList.drawElementCallback = drawElementCallback0;
        actionTypeList.drawHeaderCallback = HeaderCallbackDelegate0;

        propertyList = new ReorderableList(serializedObject, serializedObject.FindProperty("propertyList"), true, true, true, true);//【注意：属性如果是自定义类必须要标注为可序列化！！！】
        propertyList.drawElementCallback = drawElementCallback1;
        propertyList.drawHeaderCallback = HeaderCallbackDelegate1;

    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUI.BeginChangeCheck();

        enemyInfo.lifeState = (LifeState)EditorGUILayout.EnumFlagsField("LifeState", enemyInfo.lifeState);

        #region 链表-ActionTypeList
        EditorGUI.indentLevel++;//缩进
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);//白色方框，一般框住help文本内容
        {//只是方便观看，没有实际作用
            openList0 = EditorGUILayout.Foldout(openList0, "ActionTypeList (" + actionTypeList.count + ")");//收缩扩展框：有个小三角，朝右是收缩，朝下是展开

            if (openList0)
            {
                actionTypeList.DoLayoutList();//展开时显示列表
            }
        }
        EditorGUILayout.EndVertical();
        EditorGUI.indentLevel--;
        #endregion

        #region 链表-PropertyList
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);//白色方框，一般框住help文本内容
        EditorGUI.indentLevel++;//缩进
        {//只是方便观看，没有实际作用
             openList1 = EditorGUILayout.Foldout(openList1, "PropertyList (" + propertyList.count + ")");//收缩扩展框：有个小三角，朝右是收缩，朝下是展开

            if (openList1)
            {
                propertyList.DoLayoutList();//展开时显示列表
            }
        }
        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
        #endregion

        if (EditorGUI.EndChangeCheck())//与EditorGUI.BeginChangeCheck();对应
        {
            EditorUtility.SetDirty(target);//生成配置表
        }

        serializedObject.ApplyModifiedProperties();//同意配置


    }
    /// <summary>
    /// 链表标签行
    /// </summary>
    /// <param name="rect"></param>
    void HeaderCallbackDelegate0(Rect rect)
    {
        Rect R_0 = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);//EditorGUIUtility.singleLineHeight是固定行高
        EditorGUI.LabelField(R_0, "ActionType");
    }
    void HeaderCallbackDelegate1(Rect rect)
    {
        Rect R_0 = new Rect(rect.x, rect.y, rect.width*0.3f, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(R_0, "PropertyType");
        Rect R_1 = new Rect(rect.x+ rect.width * 0.3f, rect.y, rect.width*0.7f, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(R_1, "Weight");
    }
    /// <summary>
    /// 元素属性
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="index"></param>
    /// <param name="isActive"></param>
    /// <param name="isFocused"></param>
    void drawElementCallback0(Rect rect, int index, bool isActive, bool isFocused)
    {
        Rect R_1 = new Rect(rect.x, rect.y + 2, rect.width, EditorGUIUtility.singleLineHeight);//+2是为了居中
        enemyInfo.actionTypeList[index] = (ActionType)EditorGUI.EnumPopup(R_1, enemyInfo.actionTypeList[index]);

    }
    void drawElementCallback1(Rect rect, int index, bool isActive, bool isFocused)
    {
        Rect R_0 = new Rect(rect.x, rect.y+2, rect.width*0.3f, EditorGUIUtility.singleLineHeight);
        enemyInfo.propertyList[index].propertyType = (PropertyType)EditorGUI.EnumPopup(R_0, enemyInfo.propertyList[index].propertyType);

        Rect R_1 = new Rect(rect.x+ rect.width * 0.3f, rect.y + 2, rect.width*0.7f, EditorGUIUtility.singleLineHeight);
        enemyInfo.propertyList[index].weight = EditorGUI.Slider(R_1, enemyInfo.propertyList[index].weight,0,100);
    }
}