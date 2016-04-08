using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCDAL;

namespace SDCBLL
{
    public class MarketMoverServices
    {
        #region--Instance--
        public static MarketMoverServices Instance = new MarketMoverServices();
        #endregion

        #region--Save Market Mover--   
        public int SaveMarketMover(MarketMover mm)
        {
            return MarketMoverProvider.Instance.SaveMarketMover(mm);
        }      
        #endregion

    }
}
