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
        void IncomingCall(object sender,TelephoneNumber number);
        void Connecting();
        void Disconnecting();
        #region events
        event EventHandler <Call> Called;
        //event EventHandler <TelephoneNumber> IncomingCalled;
        event EventHandler Dropped;       
        event EventHandler Answered;        
        event EventHandler Connected;
        event EventHandler Disconnected;        
        #endregion
    }
}
