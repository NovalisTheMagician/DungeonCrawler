using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Editor
{
    public class TagManager
    {
        private const int MAX_TAGS = 64;

        private string projectPath;
        public string ProjectPath
        {
            set
            {
                if(projectPath != value || value != string.Empty)
                {
                    SaveTags();
                    projectPath = value;
                    tagsFile = projectPath + "tags.txt";
                    LoadTags();
                }
            }
        }

        private string tagsFile;

        private Tag[] tags;
        public Tag[] Tags
        {
            get
            {
                return tags;
            }
        }

        private bool tagsChanged;

        public TagManager()
        {
            tags = new Tag[MAX_TAGS];
            for (int i = 0; i < MAX_TAGS; ++i)
            {
                tags[i] = new Tag() { Name = "NoTag", BitVal = (ulong)Math.Pow(2, i) };
            }
            tagsChanged = false;
        }

        public void SetTag(string name, int position)
        {
            if (position == 0)
                return;

            tagsChanged = true;

            Tag tag = tags[position];
            tag.Name = name;
            tags[position] = tag;
        }

        public Tag GetTag(string name)
        {
            foreach(Tag tag in tags)
            {
                if(tag.Name == name)
                {
                    return tag;
                }
            }
            return tags[0];
        }

        private void LoadTags()
        {
            if (!File.Exists(tagsFile))
                return;

            string[] tagLines = File.ReadAllLines(tagsFile);
            foreach(string line in tagLines)
            {
                string cleanLine = line.Trim().Replace(" ", "");
                int idx = cleanLine.IndexOf('=');
                string tagName = cleanLine.Substring(0, idx);
                int tagPosition = int.Parse(cleanLine.Substring(idx + 1, cleanLine.Length));

                Tag tag = tags[tagPosition];
                tag.Name = tagName;
                tags[tagPosition] = tag;
            }

            tagsChanged = false;
        }

        public void SaveTags()
        {
            if(tagsChanged)
            {
                using (FileStream fileStream = new FileStream(tagsFile, FileMode.Create))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        for(int i = 1; i < tags.Length; ++i)
                        {
                            Tag tag = tags[i];
                            streamWriter.WriteLine($"{tag.Name}={i}");
                        }
                    }
                }
            }
        }
    }

    public struct Tag
    {
        public string Name { get; set; }
        public ulong BitVal { get; set; }

        public bool IsValid()
        {
            return Name != "NoTag";
        }
    }

    public class Tags
    {
        public ulong Bitfield { get; private set; }

        public Tags()
        {
            Bitfield = 0;
        }

        public Tags(ulong bitfield)
        {
            Bitfield = bitfield;
        }

        public void AddTag(Tag tag)
        {
            Bitfield |= tag.BitVal;
        }

        public void RemoveTag(Tag tag)
        {
            Bitfield &= ~tag.BitVal;
        }

        public bool HasTag(Tag tag)
        {
            return (tag.BitVal & Bitfield) > 0;
        }
    }
}
