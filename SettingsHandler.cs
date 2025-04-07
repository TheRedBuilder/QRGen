using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGen
{
	/// <summary>
	/// Custom settings handler, mimicking Microsoft's Settings.Default but saving using Json.
	/// </summary>
	/// <typeparam name="T">Settings class type</typeparam>
	public class JsonSettings<T> where T : new()
	{
		readonly string _filePath;
		T _data;

		public JsonSettings(string filePath)
		{
			_filePath = filePath;
			Load();
		}

		public T Data => _data;

		public void Save()
		{
			var json = JsonConvert.SerializeObject(_data, Formatting.Indented);
			Directory.CreateDirectory(_filePath);
			File.WriteAllText(_filePath, json);
		}

		public void Load()
		{
			if (File.Exists(_filePath))
			{
				var json = File.ReadAllText(_filePath);
				_data = JsonConvert.DeserializeObject<T>(json) ?? new T();
			}
			else
			{
				_data = new T();
			}
		}

		public void Reload() => Load();
	}
}
