using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AIMGUIContainer
{
    struct entry
    {
        public string description;
        public string value;

        public entry(string _description)
        {
            description = _description;
            value = "-";
        }

        public string content { get { return description + ": " + value; } }
    }

    public int width = 250;
    public int height = 30;
    private string name;

    private Dictionary<int, entry> data = new Dictionary<int, entry>();

    public AIMGUIContainer(string _name)
    {
        name = _name;
    }

    public void Add(int _id, string _description)
    {
        data.Add(_id, new entry(_description));
        height += 20;
    }

    public void UpdateVal(int _id, string _val)
    {
        UpdateData(_id, _val);
    }

    public void UpdateVal(int _id, int _val)
    {
        string formattedVal = _val.ToString();
        UpdateData(_id, formattedVal);
    }

    public void UpdateVal(int _id, float _val)
    {
        string formattedVal = System.Math.Round( _val, 3).ToString() + "f";
        UpdateData(_id, formattedVal);
    }

    public void UpdateVal(int _id, bool _val)
    {
        string formattedVal = _val.ToString();
        UpdateData(_id, formattedVal);
    }


    public void UpdateVal(int _id, Vector3 _val)
    {
        string formattedVal = _val.ToString();
        UpdateData(_id, formattedVal);
    }

    public void UpdateVal(int _id, Vector2 _val)
    {
        string formattedVal = _val.ToString();
        UpdateData(_id, formattedVal);
    }


    public void UpdateVal(int _id, Vector4 _val)
    {
        string formattedVal = _val.ToString();
        UpdateData(_id, formattedVal);
    }

    public void UpdateVal(int _id, Transform _val)
    {
        string formattedVal = _val.name;
        UpdateData(_id, formattedVal);
    }


    private void UpdateData(int _id, string _formattedVal)
    {
        entry newEntry = data[_id];
        newEntry.value = _formattedVal;
        data[_id] = newEntry;
    }


    public void Draw(int x, int y)
    {
        GUI.Box(new Rect(x,y, width, height), name);

        int i = 1;
        foreach (KeyValuePair<int, entry> item in data)
        {
            GUI.Label(new Rect(x+5, y + (20 * i), width - 5, 20), item.Value.content);
            i++;
        }
    }
}
