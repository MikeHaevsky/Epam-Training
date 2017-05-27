using ATXEmulation.ATX.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    public interface ITerminal
    {
        void BeginCall(TelephoneNumber number);
        void EndingCall();
        void AnsweringCall();
        void IncomingCall();
        void Connecting();
        void Disconnecting();
        #region events
        event EventHandler <Call> Called;  
        event EventHandler Dropped;       
        event EventHandler Answered;        
        event EventHandler Connected;
        event EventHandler Disconnected;        
        #endregion
    }
}
