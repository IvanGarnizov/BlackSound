namespace BlackSound.Data.Repositories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Models;

    using Newtonsoft.Json;

    public abstract class BaseRepository<T>
        where T : BaseModel, new()
    {
        protected readonly string filePath;

        public BaseRepository(string filePath)
        {
            this.filePath = filePath;
        }

        protected abstract void UpdateModel(T modelToUpdate, T model);

        public List<T> GetAll()
        {
            if (File.Exists(filePath))
            {
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
            }

            return new List<T>();
        }

        public int GetId()
        {
            return GetAll().Count + 1;
        }

        public void Insert(T model)
        {
            var models = GetAll();

            models.Add(model);
            SaveChanges(models);
        }

        public void Update(T model)
        {
            var models = GetAll();
            var modelToUpdate = models
                .FirstOrDefault(m => m.Id == model.Id);

            UpdateModel(modelToUpdate, model);
            SaveChanges(models);
        }

        public void Delete(T model)
        {
            var models = GetAll();
            
            models.Remove(model);
            SaveChanges(models);
        }

        public T GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(m => m.Id == id);
        }

        private void SaveChanges(List<T> models)
        {
            string json = JsonConvert.SerializeObject(models, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}
