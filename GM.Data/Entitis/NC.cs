using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Entitis;

public class NC : Entity
{
    public int Id { get; set; }
    /// <summary>
    /// Tên của NC
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Chú thích
    /// </summary>
    public string Note { get; set; }
    /// <summary>
    /// nco
    /// </summary>
    public int ManagerId { get; set; }

    public User User { get; set; }
    public IEnumerable<NCC> Nccs { get; set; }
}
