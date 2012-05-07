using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;

namespace DotNetNuke.Social.Controllers
{
    public class StorageController<T>
    {
        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        public void Save(T ItemToSave, string Name)
        {

            if (ItemToSave != null)
            {
                string folder = ItemToSave.GetType().Name;
                string fileName = string.Format("{0}\\{1}", folder, Name);

                string[] dirs = isoStore.GetDirectoryNames(folder);
                if (dirs == null || dirs.Length <= 0)
                {
                    isoStore.CreateDirectory(folder);
                }

                string[] files = isoStore.GetFileNames(fileName);
                if (files != null && files.Length > 0)
                {
                    isoStore.DeleteFile(fileName);
                }

                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.CreateNew, isoStore)))
                {

                    writer.Write(Serialize.SerializeXMLAsString(ItemToSave));

                }
            }
            
        }

        public T Load(string Name)
        {

            if (!string.IsNullOrEmpty(Name))
            {
                string folder = typeof(T).Name;
                string fileName = string.Format("{0}\\{1}", folder, Name);
                string[] dirs = isoStore.GetDirectoryNames(folder);
                if (dirs == null || dirs.Length <= 0)
                {
                    return default(T);
                }

                string[] files = isoStore.GetFileNames(fileName);
                if (files != null && files.Length > 0)
                {
                    string env = null;
                    using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, isoStore)))
                    {
                        env = reader.ReadToEnd();

                    }
                    if (string.IsNullOrEmpty(env)) return default(T);
                    try
                    {
                        return Serialize.DeSerializeXML<T>(env);
                    }
                    catch (Exception)
                    {
                        isoStore.DeleteFile(fileName);
                    }
                    
                }

            }
            return default(T);
        }

    }
}
