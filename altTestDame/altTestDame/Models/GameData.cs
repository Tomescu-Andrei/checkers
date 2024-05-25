using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace altTestDame.Models
{
    internal class GameData
    {
        public ObservableCollection<ObservableCollection<Piece>> Board { get; set; }
        public string ExtraData { get; set; }
        public string TurnData { get; set; }

    }
}
