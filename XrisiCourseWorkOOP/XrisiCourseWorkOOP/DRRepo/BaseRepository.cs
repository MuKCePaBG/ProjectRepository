using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XrisiCourseWorkOOP.DRRepo
{
    public class BaseRepository<T> where T : Entity.BaseEntity, new()
    {
        protected readonly string filePath;

        public BaseRepository(string filePath)
        {
            this.filePath = filePath;
        }
        protected virtual void PopulateEntity(StreamReader sr, T item)
        { }

        protected virtual void WriteEntity(StreamWriter sw, T item)
        { }
        private void Insert(T item)
        {
            item.ID = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                WriteEntity(sw, item);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        private int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    T item = new T();

                    PopulateEntity(sr, item);

                    if (id <= item.ID)
                    {
                        id = item.ID + 1;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }
        public T GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    T item = new T();
                    PopulateEntity(sr, item);

                    if (item.ID == id)
                    {
                        return item;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }
        public void Save(T item)
        {
            if (item.ID > 0)
            {
                Insert(item);
            }
        }
        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    T item = new T();
                    PopulateEntity(sr, item);
                    result.Add(item);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }
    }
}
