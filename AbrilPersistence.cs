using Newtonsoft.Json;

namespace AbrilPersistence {
	public class Repository<T> : List<T> where T : class {
		private string filePath;

		public Repository(string filePath) {
			this.filePath = filePath;

			if (!File.Exists(filePath)) {
				FileStream fs = File.Create(filePath);
				fs.Close();
			}

			Load();
		}

		private void Load() {
			string contents = File.ReadAllText(filePath);
			if (contents == null)
				return;

			T[] values = JsonConvert.DeserializeObject<T[]>(contents);

			if (values != null)
				AddRange(values);
		}

		public void Commit() {
			string serialized = JsonConvert.SerializeObject(ToArray());

			using (StreamWriter sw = new StreamWriter(filePath)) {
				sw.Write(serialized);
			}
		}

		public T[] SelectAll() {
			return ToArray();
		}

		public T[] Where(Func<T, bool> where) {
			return this.Where<T>(where).ToArray();
		}
	}
}
