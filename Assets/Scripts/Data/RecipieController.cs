using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipieController : MonoBehaviour
{

    private static RecipieController _instance;
    public static RecipieController Instance => _instance;

    [Header("Data Assets")]

    [SerializeField]
    private List<RecipieItem> _recipieItems = new List<RecipieItem>();
    public List<RecipieItem> RecipieItems => _recipieItems;


    [Header("Game Iteration Data")]

    [SerializeField]
    private RecipieItem _selectedRecipieItem;
    public RecipieItem SelectedRecipieItem => _selectedRecipieItem;
    [SerializeField]
    private GameObject _selectedRecipieItemGO;
    public GameObject SelectedRecipieItemGO => _selectedRecipieItemGO;


    [SerializeField]
    private SpawnPoint _spawnPoint;
    public SpawnPoint SpawnPoint => _spawnPoint;



    private void Awake()
    {
        _instance = this;
        GetData();
    }

    private void Start()
    {
        _spawnPoint = GetSpawnPoint();
        if(!LevelRecipieMenu.Instance) return;


    }

    public void GetData()
    {
        _recipieItems = GetAssets<RecipieItem>("Items");
    }

    private List<T> GetAssets<T>(string folder){

        var assets = Resources.LoadAll(folder, typeof(T)).Cast<T>().ToArray();
        var newList = new List<T>();
        foreach(var asset in assets)
        {
            newList.Add(asset);
        }

        return newList;

    }



    private SpawnPoint GetSpawnPoint() =>  FindObjectOfType<SpawnPoint>();

    public void SpawnItem()
    {
        var randomItemIndex = Random.Range(0,_recipieItems.Count-1);
        var item = _recipieItems[randomItemIndex];
        if(_selectedRecipieItem &&_selectedRecipieItemGO)
        {
            _recipieItems.Add(_selectedRecipieItem);
            Destroy(_selectedRecipieItemGO);
        }
        var model = Instantiate(item.Model, _spawnPoint.SpawnPosition.position, Quaternion.identity,_spawnPoint.transform);
        _spawnPoint.SetUI(item.Image, item.Name);
        _recipieItems.Remove(item);
        _selectedRecipieItem = item;
        _selectedRecipieItemGO = model;
    }


}
