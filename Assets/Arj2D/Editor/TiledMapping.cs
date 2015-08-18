using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public class TiledMapping : EditorWindow
{
    //vars
    private GameObject Father;
    private int Columns = 10;
    private int Rows = 10;
    private float TileWidth = 1f;
    private float TileHeight = 1f;
    private float Depth = 0.0f;

    //vars dont impotant
    private Rect Rect_guiDraw;
    private Rect Rect_guiErase;
    private string NameFather = "TiledMap";
    private string PrefabFolder;
    //prefabs
    private GUIContent[] PrefabPreview;
    private List<GameObject> Prefabs = new List<GameObject>();
    private Vector2 ScrollPosition = Vector2.zero;
    private int indexPrefab = -1; // -1= any prefab loaded

    [MenuItem("Arj2D/TiledEditor")]
    public static void Init()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(TiledMapping), false, "Tiled Map");
        window.minSize = new Vector2(250f, 190f);
        window.Show();
    }

    //Start
    void OnEnable()
    {
        SceneView.onSceneGUIDelegate += this.SceneGUI;
        Tools.current = Tool.View;
        Tools.viewTool = ViewTool.None; //FPS

        //precalcule
        Rect_guiDraw = new Rect(10, Screen.height - 150, 180, 100);
        Rect_guiErase = new Rect(10, Screen.height - 135, 180, 100);
    }

    //Interface
    void OnGUI()
    {
        //father gui
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Father name:", GUILayout.MaxWidth(80f));
        NameFather = EditorGUILayout.TextField(NameFather, GUILayout.MaxWidth(100f));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create or Find", GUILayout.MaxWidth(100f), GUILayout.MinWidth(100f)))
        {
            Father = GameObject.Find(NameFather);
            if (Father == null)
            {
                Father = new GameObject(NameFather);
                Father.transform.position = new Vector3(0.0f, 0.0f, this.Depth);
            }
        }
        GUILayout.Label("Depth:", GUILayout.MaxWidth(43f));
        this.Depth = EditorGUILayout.FloatField(this.Depth, GUILayout.MaxWidth(80f), GUILayout.MinWidth(80f));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(5.0f);

        //warning if it not exist father yet
        if (Father == null)
        {
            EditorGUILayout.HelpBox("Create or Find Father first", MessageType.Error);
            return;
        }

        //data gui
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Rows(X):", GUILayout.MaxWidth(80f));
        this.Rows = EditorGUILayout.IntField(this.Rows, GUILayout.MaxWidth(100f));
        if (this.Rows < 1)
            this.Rows = 1;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Columns(Y):", GUILayout.MaxWidth(80f));
        this.Columns = EditorGUILayout.IntField(this.Columns, GUILayout.MaxWidth(100f));
        if (this.Columns < 1)
            this.Columns = 1;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Tile Width:", GUILayout.MaxWidth(80f));
        this.TileWidth = EditorGUILayout.FloatField(this.TileWidth, GUILayout.MaxWidth(100f));
        if (this.TileWidth < 0.1f)
            this.TileWidth = 0.1f;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Tile Height:", GUILayout.MaxWidth(80f));
        this.TileHeight = EditorGUILayout.FloatField(this.TileHeight, GUILayout.MaxWidth(100f));
        if (this.TileHeight < 0.1f)
            this.TileHeight = 0.1f;
        EditorGUILayout.EndHorizontal();

        //prefab gui
        GUILayout.Space(15.0f);
        if (GUILayout.Button("Change Prefab folder"))
        {
            PrefabFolder = EditorUtility.OpenFolderPanel("Folder", Application.dataPath, "Prefabs");
            if (!String.IsNullOrEmpty(PrefabFolder))
            {
                UpdatePreviewPrefabs();
            }
        }
        if (indexPrefab != -1)
        {
            if (GUILayout.Button("Calculate Width and Height of Prefab"))
            {
                CalculateHeightAndWidth();
            }
            GUILayout.Space(5.0f);
            if (PrefabPreview.Length > 0)
            {
                EditorGUIUtility.SetIconSize(new Vector2(50.0f, 50.0f));
                ScrollPosition = GUILayout.BeginScrollView(ScrollPosition, GUILayout.Width(position.width));
                GUILayout.Label("Prefabs: ", EditorStyles.boldLabel);
                indexPrefab = GUILayout.SelectionGrid(indexPrefab, PrefabPreview, 5);
                GUILayout.EndScrollView();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Select a folder to load", MessageType.Error);
        }
    }

    //at close the windows
    void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= this.SceneGUI;
    }

    //extras funcitions---------------------------
    void SceneGUI(SceneView sceneView) //events in editor
    {
        //There not exist Father
        if (Father == null)
        {
            return;
        }

        //calculate mouse
        Update_MouseInTiled();

        Event current = Event.current;

        //its mouse in tiledmap?
        if (IsMouseOnTiled())
        {
            SceneView.RepaintAll();//update views

            // if mouse down or mouse drag
            if (current.type == EventType.MouseDown || current.type == EventType.MouseDrag)
            {
                if (indexPrefab == -1)
                {
                    Debug.LogWarning("Select Prefab to use first");
                    return;
                }

                //click right
                if (current.button == 1)
                {
                    EraseInWorld();
                    current.Use();
                }
                //click left
                else if (current.button == 0)
                {
                    AddToWorld();
                    current.Use();
                }
            }
        }
        DrawGUI();
        DrawLines();
    }

    void DrawGUI()
    {
        Handles.BeginGUI();
        GUI.Label(Rect_guiDraw, "Left Mouse Button: Draw");
        GUI.Label(Rect_guiErase, "Right Mouse Button: Erase");
        Handles.EndGUI();
    }

    void DrawLines()
    {
        // store map width, height and position
        float mapWidth = this.Columns * this.TileWidth;
        float mapHeight = this.Rows * this.TileHeight;
        Vector3 position = Vector3.zero;

        // draw layer border
        Handles.color = Color.white;
        Handles.DrawLine(position, position + new Vector3(mapWidth, 0, 0));
        Handles.DrawLine(position, position + new Vector3(0, mapHeight, 0));
        Handles.DrawLine(position + new Vector3(mapWidth, 0, 0), position + new Vector3(mapWidth, mapHeight, 0));
        Handles.DrawLine(position + new Vector3(0, mapHeight, 0), position + new Vector3(mapWidth, mapHeight, 0));

        // draw tile cells
        Handles.color = Color.grey;
        for (float i = 1; i < this.Columns; i++)
        {
            Handles.DrawLine(position + new Vector3(i * this.TileWidth, 0, 0), position + new Vector3(i * this.TileWidth, mapHeight, 0));
        }

        for (float i = 1; i < this.Rows; i++)
        {
            Handles.DrawLine(position + new Vector3(0, i * this.TileHeight, 0), position + new Vector3(mapWidth, i * this.TileHeight, 0));
        }

        // Draw marker position
        Handles.color = Color.red;
        Handles.RectangleCap(0, MouseInTiled, Quaternion.identity, 0.5f);
    }



    //local functions ----------------------------------------------------------------------
    private Vector3 MouseInTiled;

    private void CalculateHeightAndWidth()
    {
        if (indexPrefab != -1)
        {
            this.TileWidth = Prefabs[indexPrefab].GetComponent<Renderer>().bounds.size.x;
            this.TileHeight = Prefabs[indexPrefab].GetComponent<Renderer>().bounds.size.y;
        }
        else
        {
            Debug.LogWarning("Select a prefab first");
        }
    }

    private Vector2 GetTilePositionFromMouseLocation()
    {
        // calculate column and row
        Vector3 pos = new Vector3(MouseInTiled.x / this.TileWidth, MouseInTiled.y / this.TileHeight, 0.0f);
        // round the numbers
        pos = new Vector3((int)Math.Round(pos.x, 5, MidpointRounding.ToEven), (int)Math.Round(pos.y, 5, MidpointRounding.ToEven), 0);

        int col = (int)pos.x;
        int row = (int)pos.y;

        //limits
        if (row < 0)
            row = 0;
        if (row > this.Rows - 1)
            row = this.Rows - 1;
        if (col < 0)
            col = 0;
        if (col > this.Columns - 1)
            col = this.Columns - 1;

        return new Vector2(col, row);
    }

    //get Mouse Position
    private void Update_MouseInTiled()
    {
        // build a plane
        Plane p = new Plane(-Vector3.forward, Vector3.zero);

        //Ray
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        float dist;

        // cast a ray and check if hit
        if (p.Raycast(ray, out dist))
        {
            MouseInTiled = ray.origin + (ray.direction.normalized * dist);
            // store the tile location (Column/Row) based on the current location of the mouse pointer
            Vector2 tilepos = this.GetTilePositionFromMouseLocation();
            // store the tile position in world space
            Vector3 pos = new Vector3(tilepos.x * this.TileWidth, tilepos.y * this.TileHeight, 0);
            // set to grid
            MouseInTiled = new Vector3(pos.x + (this.TileWidth / 2), pos.y + (this.TileHeight / 2), 0);
        }
    }

    private bool IsMouseOnTiled()
    {
        Vector2 TiledPos = GetTilePositionFromMouseLocation();
        Vector3 pos = new Vector3(TiledPos.x * this.TileWidth, TiledPos.y * this.TileHeight, 0);
        //Debug.Log(TiledPos + " - " + pos);
        return (pos.x >= 0) &&
            (pos.x < (this.Columns * this.TileWidth)) &&
            (pos.y >= 0) &&
            (pos.y < (this.Rows * this.TileHeight));
    }

    private void AddToWorld()
    {
        //check if exist one there and is son of the father (lol)
        GameObject obj = HandleUtility.PickGameObject(Event.current.mousePosition, false);
        //Transform obj = Father.transform.Find(string.Format("Tile_{0}_{1}", TiledPos.x, TiledPos.y));
        if (obj != null)
        {
            if (obj.transform.root == Father.transform)
            {
                //We destroy object in that position
                Undo.DestroyObjectImmediate(obj);
            }
            else //its not of the tiled map
            {
                return;
            }
        }
        //create one
        GameObject go = Instantiate(Prefabs[indexPrefab], new Vector3(MouseInTiled.x, MouseInTiled.y, this.Depth), Prefabs[indexPrefab].transform.rotation) as GameObject;

        //set
        go.transform.parent = Father.transform;
        Vector2 TiledPos = GetTilePositionFromMouseLocation();
        go.name = string.Format(Prefabs[indexPrefab].name + "_{0}_{1}", TiledPos.x, TiledPos.y);
        Undo.RegisterCreatedObjectUndo(go, "Object Create");
    }

    private void EraseInWorld()
    {
        //check if exist one there
        GameObject obj = HandleUtility.PickGameObject(Event.current.mousePosition, false);
        if (obj != null && obj.transform.root == Father.transform)
        {
            Undo.DestroyObjectImmediate(obj);
        }
    }

    //Read and create preview of prefabs
    void UpdatePreviewPrefabs()
    {
        string[] assetsPaths = AssetDatabase.GetAllAssetPaths();
        string foldertoCheck = PrefabFolder.Remove(0, PrefabFolder.IndexOf("Asset"));
        List<GUIContent> guicontent = new List<GUIContent>();
        Texture2D previewTmp;

        //tmp
        UnityEngine.Object obj;

        //see directory,, and get all prefabs
        for (int i = 0; i < assetsPaths.Length; i++)
        {
            if (assetsPaths[i].StartsWith(foldertoCheck))
                if (assetsPaths[i] != foldertoCheck)
                {
#if UNITY_5_0
                    obj = AssetDatabase.LoadAssetAtPath((string)assetsPaths[i], typeof(GameObject));
#else
                    obj = AssetDatabase.LoadAssetAtPath((string)assetsPaths[i], typeof(GameObject));
#endif
                    
                    
                    if (obj != null) //check if is a prefab
                    {
                        //PrefabPreview_holder.Add(AssetPreview.GetAssetPreview(obj));
                        previewTmp = AssetPreview.GetAssetPreview(obj);
                        //guicontent.Add(new GUIContent(PrefabPreview_holder[PrefabPreview_holder.Count - 1], obj.name));
                        guicontent.Add(new GUIContent(previewTmp, obj.name));
                        Prefabs.Add((GameObject)obj);
                    }
                }
        }

        //add to preview in gui
        PrefabPreview = guicontent.ToArray();
        indexPrefab = 0;
    }
}