using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Engine
{
    public class FakeEngine
    {
        private static FakeEngine _engine { get; set; }

        private FakeEngine()
        {

        }

        public static FakeEngine Instance
        {
            get
            {
                if (_engine == null)
                {
                    _engine = new FakeEngine();
                }
                return _engine;
            }
        }
    }
}
