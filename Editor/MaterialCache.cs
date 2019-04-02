using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Editor
{
    public class MaterialCache
    {
        private string baseTexturePath;
        public string BaseTexturePath
        {
            get { return baseTexturePath; }
            set { baseTexturePath = value; ReloadTextures(); }
        }

        private Dictionary<string, Material> materialMap;

        public IReadOnlyList<string> MaterialFiles
        {
            get
            {
                return materialMap.Keys.ToList();
            }
        }

        public IReadOnlyDictionary<string, Material> Materials
        {
            get
            {
                return materialMap;
            }
        }

        public MaterialCache()
        {
            materialMap = new Dictionary<string, Material>();
        }

        public void ReloadTextures()
        {
            materialMap.Clear();

            string[] files = Directory.GetFiles(baseTexturePath);
            foreach (string file in files)
            {
                if (IsRightExtension(file))
                {
                    Console.WriteLine($"File added: '{file}'");

                    Image newTexture = Image.FromFile(file);
                    materialMap.Add(file, new Material());
                    newTexture.Dispose();
                }
            }
        }

        public void RefreshTextures()
        {
            foreach (var matmap in materialMap.ToList())
            {
                string file = matmap.Key;
                Material texture = matmap.Value;

                if (!File.Exists(file))
                {
                    materialMap.Remove(file);
                }
                else
                {
                    // optimize here to only load the materials which have been changed since last loaded
                    // (check file last modified date and store the date somewhere)
                    materialMap[file] = new Material();
                }
            }
        }

        private bool IsRightExtension(string path)
        {
            return Regex.IsMatch(GetExtension(path), @"\.mat");
        }

        private string GetExtension(string path)
        {
            return (Path.GetExtension(path) ?? "").ToLower();
        }
    }
}
