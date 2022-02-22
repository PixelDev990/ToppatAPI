using ToppatAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ToppatAPI.DB
{
    abstract class AssetData
    {
        public string Name { get; set; }
        public MapType MapType { get; set; }

        public abstract void ImportMap(GameObject map, ShipStatus shipStatus);
    }
}
