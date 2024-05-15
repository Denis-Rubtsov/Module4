using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISaveLoadEntity<T> : ISaveLoadEntity where T : SaveData
{
    public T Restore();
}

public interface ISaveLoadEntity
{
    public void Save();
}
