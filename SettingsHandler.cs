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
		public string FilePath => _filePath;
		T _data;

		public JsonSettings(string filePath)
		{
			_filePath = filePath;
			Load();
		}

		public T Data => _data;

		public void Save()
		{
			try
			{
				var json = JsonConvert.SerializeObject(_data, Formatting.Indented);
				Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
				File.WriteAllText(_filePath, json);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error during settings saving! Exception:\n" + e.Message, "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		public void Load()
		{
			try
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
			catch (Exception e)
			{
				MessageBox.Show("Error during settings loading! Exception:\n" + e.Message, "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		public void Reload() => Load();
	}
}
