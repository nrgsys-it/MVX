using System;
using System.Collections.Generic;
using MVX.Samples.ToDoList.Models;

namespace MVX.Samples.ToDoList.Data
{
  /// <summary>
  /// A very simple thread-safe list of ToDoItem
  /// </summary>
  internal class ToDoItemsBag
  {
    private readonly List<ToDoItem> _list;
    private readonly object _sync;

    public ToDoItemsBag()
    {
      _sync = new object();
      _list = new List<ToDoItem>();
    }

    public void Add(ToDoItem item)
    {
      lock (_sync)
      {
        _list.Add(item);
      }
    }

    public void Remove(ToDoItem item)
    {
      lock (_sync)
      {
        var itemIndex = _list.FindIndex(listItem => listItem.Text == item.Text);
        if (itemIndex > 0)
          throw new KeyNotFoundException();
        _list.RemoveAt(itemIndex);
      }
    }

    public List<ToDoItem> GetAll()
    {
      lock (_sync)
      {
        return _list.Copy();
      }
    }
  }
}