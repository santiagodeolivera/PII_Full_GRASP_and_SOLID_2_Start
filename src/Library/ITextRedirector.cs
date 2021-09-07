using System;
using System.Collections.Generic;
using System.Collections;

namespace Full_GRASP_And_SOLID
{
	/// <summary>
	/// This interface offers a dynamic way to redirect a stream of strings.
	/// </summary>
	public interface ITextRedirector
	{
		/// <summary>
		/// Inserts a string to this redirector.
		/// </summary>
		/// <param name="text">The string to give to this redirector.</param>
		void InsertText(string text);

		/// <summary>
		/// Inserts a string representing the given object to this redirector.
		/// </summary>
		/// <param name="ob">The object whose representative string will be given to the redirector.</param>
		void Insert(object ob)
		{
			this.InsertText(ob.ToString());
		}

		/// <summary>
		/// Inserts a group of strings to this redirector.
		/// </summary>
		/// <param name="strings">The strings to give to this redirector.</param>
		void InsertSeveralStrings(IEnumerable<string> strings)
		{
			foreach (string text in strings)
			{
				this.InsertText(text);
			}
		}

		/// <summary>
		/// Inserts a group of objects to this redirector.
		/// </summary>
		/// <param name="objects">The objects to give to this redirector.</param>
		void InsertSeveral(IEnumerable objects)
		{
			foreach(object ob in objects)
			{
				this.Insert(ob);
			}
		}
	}

	/// <summary>
	/// This interface offers a dynamic way to transform a stream of strings into an object.
	/// </summary>
	/// <typeparam name="T">The type of the object the stream of string will transform into</typeparam>
	public interface ITextRedirector<T> : ITextRedirector
	{
		/// <summary>
		/// Generates the resulting object and returns it.
		/// After calling this function once, don't call it or neither of its `ITextRedirector` functions again.
		/// Doing so might result in an exception or undefined behavior.
		/// </summary>
		/// <returns>The resulting object</returns>
		T end();
	}
}