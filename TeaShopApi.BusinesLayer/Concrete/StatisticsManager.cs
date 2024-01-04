using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinesLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;

namespace TeaShopApi.BusinesLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatisticsDal _statisticsDal;

        public StatisticsManager(IStatisticsDal statisticsDal)
        {
            _statisticsDal = statisticsDal;
        }

        public decimal TDrinkAveragePrice()
        {
            return _statisticsDal.DrinkAveragePrice();
        }

        public int TDrinkCount()
        {
            return _statisticsDal.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statisticsDal.LastDrinkName();
        }

        public string TMaxPriceDrink()
        {
            return _statisticsDal.MaxPriceDrink();
        }
    }
}
