using ToppatAPI.Map;
using ToppatAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ToppatAPI.MinimapGen
{
    interface Generator
    {
        public void Generate(MapAsset asset);
        public void Finish();
    }
}
