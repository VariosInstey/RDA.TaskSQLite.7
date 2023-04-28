using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA.TaskSQLite._7.Model;
public class TourDbContext : DbContext
 {
    #region Конструктор
    public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    #endregion

    #region Public свойства
    public DbSet<Tour> Tours { get; set; }

    #endregion

    #region MyRegion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>().HasData(GetTours());
        base.OnModelCreating(modelBuilder);
    }

    private Tour[] GetTours() => new Tour[]
    {
        new Tour()
        {
            TourID = 1,
            TourName = "Playa Paraiso ( Ex. Pestana Cayo Coco Hotel)",
            TourDescription = "Отель расположен на одном из лучших пляжей Кубы. Современный дизайн дополнен колоритом традиционно кубинского стиля и панорамным видом Карибского моря. Идеальное место для любителей дайвинга.",
            TourCount = 15,
            TourPrice = 164429.15
        },

        new Tour()
        {
            TourID = 2,
            TourName = "Paradisus Varadero Resort & Spa",
            TourDescription = "Отель высокого уровня с качественным сервисом, можно рекомендовать для VIP-клиентов. Один из лучших отелей Варадеро, работающий по системе «все включено».",
            TourCount = 7,
            TourPrice = 217374.00
        },
        new Tour()
        {
            TourID = 3,
            TourName = "Hotel Brisas Santa Lucia",
            TourDescription = "Небольшой комплекс, который подходит для отдыха индивидуальных туристов, для пар и для семейного отдыха.",
            TourCount = 35,
            TourPrice = 143000.00
        }

    };
    #endregion
}
