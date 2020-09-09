using MahorobaWare.Core.Plugin.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Plugin
{
	public class VisualPlugins : IVisualPlugins
	{
		private IVisualPlugin[] array = Array.Empty<IVisualPlugin>();
		public IVisualPlugin this[int index]
		{
			get
			{
				if (array == null)
				{
					throw new InvalidOperationException(nameof(array) + " == null");
				}
				if (index < 0 || array.Length <= index)
				{
					throw new ArgumentException(nameof(index) + " < 0 || " + nameof(array) + ".Length <= " + nameof(index));
				}
				return array[index];
			}
			set
			{
				if (array == null)
				{
					throw new InvalidOperationException(nameof(array) + " == null");
				}
				if (index < 0 || array.Length <= index)
				{
					throw new ArgumentNullException(nameof(index) + " < 0 || " + nameof(array) + ".Length <= " + nameof(index));
				}
				array[index] = value;
			}
		}

		public int Count => array == null ? throw new InvalidOperationException(nameof(array) + " == null") : array.Length;

		public bool IsReadOnly => false;

		public void Add(IVisualPlugin item)
		{
			if (array == null)
			{
				throw new InvalidOperationException(nameof(array) + " == null");
			}
			var temporary = new IVisualPlugin[array.Length + 1];
			array.CopyTo(temporary, 0);
			temporary[^1] = item;
			array = temporary;
		}
		public void Clear() => array = Array.Empty<IVisualPlugin>();
		public bool Contains(IVisualPlugin item)
		{
			if (array == null)
			{
				throw new InvalidOperationException(nameof(array) + " == null");
			}
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item) + " == null");
			}
			return Array.IndexOf(array, item) != -1;
		}
		public void CopyTo(IVisualPlugin[] array, int arrayIndex)
		{
			if (this.array == null)
			{
				throw new InvalidOperationException("this." + nameof(array) + " == null");
			}
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array) + " == null");
			}
			if (arrayIndex < 0 || array.Length <= arrayIndex)
			{
				throw new ArgumentException(nameof(arrayIndex) + " < 0 || " + nameof(array) + ".Length <= " + nameof(arrayIndex));
			}
			this.array.CopyTo(array, arrayIndex);
		}
		public IEnumerator<IVisualPlugin> GetEnumerator()
		{
			foreach (var item in array)
			{
				yield return item;
			}
		}
		public int IndexOf(IVisualPlugin item) => array == null ? throw new ArgumentNullException(nameof(array) + " == null") : Array.IndexOf(array, item);
		public void Insert(int index, IVisualPlugin item)
		{
			if (array == null)
			{
				throw new InvalidOperationException(nameof(array) + " == null");
			}
			if (index < 0 || array.Length <= index)
			{
				throw new ArgumentException(nameof(index) + " < 0 || " + nameof(array) + ".Length <= " + nameof(index));
			}
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item) + " == null");
			}
			var temporary = new IVisualPlugin[array.Length + 1];
			Array.Copy(array, 0, temporary, 0, index);
			Array.Copy(array, index, temporary, index + 1, array.Length - index);
			temporary[index] = item;
			array = temporary;
		}
		public bool Remove(IVisualPlugin item)
		{
			if (array == null)
			{
				throw new InvalidOperationException(nameof(array) + " == null");
			}
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item) + " == null");
			}
			if (array.Length == 0)
			{
				throw new ArgumentNullException(nameof(array) + ".Length == 0");
			}
			int index = Array.BinarySearch(array, item);
			if (index < 0)
			{
				return false;
			}

			RemoveAt(index);

			return true;
		}
		public void RemoveAt(int index)
		{
			if (array == null)
			{
				throw new InvalidOperationException(nameof(array) + " == null");
			}
			if (index < 0 || array.Length <= index)
			{
				throw new ArgumentException(nameof(index) + " < 0 || " + nameof(array) + ".Length <= " + nameof(index));
			}
			var temporary = new IVisualPlugin[array.Length - 1];
			Array.Copy(array, 0, temporary, 0, index);
			Array.Copy(array, index + 1, temporary, index, array.Length - index - 1);
			array = temporary;
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
