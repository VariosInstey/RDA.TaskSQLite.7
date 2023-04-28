using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA.TaskSQLite._7.Model;
public class Tour
{
    public int TourID { get; set; }
    public string? TourName { get; set; }
    public string? TourDescription { get; set; } 
    public double TourPrice { get; set; }
    public int TourCount { get; set; }
}
