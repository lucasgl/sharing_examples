using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class SimpleStateMachine
    {
        enum KVPReceivingStates
        {
            WAITING_KVP,
            CONTINUE_KVP,
            ERROR
        }

        KVPReceivingStates kvpState = KVPReceivingStates.WAITING_KVP;
        List<byte> kvpBuffer = new List<byte>();

        public void ReceivingKVP(byte [] data)
        {
            try
            {
                switch (kvpState)
                {
                    case KVPReceivingStates.WAITING_KVP:
                        if ((data[0] & 0x80) > 0)    //last packet
                        {
                            //Clear the buffer as this is first and last you don't need it
                            kvpBuffer.Clear();
                            //TODO: Create the new key value pairs,                        
                        }
                        else
                        {
                            //Buffer the data into a buffer thing to continue later on next state
                            kvpBuffer.AddRange(data.Skip(3).ToArray()); //getting the kvp part of the data ----MAKE SURE THIS LOOKS RIGHT
                            kvpState = KVPReceivingStates.CONTINUE_KVP;
                        }
                        break;
                    case KVPReceivingStates.CONTINUE_KVP:
                        if ((data[0] & 0x80) > 0)    //last packet
                        {
                            //TODO: Create the new key value pairs from the buffer                        

                            //After you use it Clear the buffer as this is first and last you don't need it
                            kvpBuffer.Clear();
                            kvpState = KVPReceivingStates.WAITING_KVP;
                        }
                        else
                        {
                            //Buffer the data into a buffer thing to continue later on next state
                            kvpBuffer.AddRange(data.Skip(1).ToArray()); //getting the kvp part of the data ----MAKE SURE THIS LOOKS RIGHT
                            kvpState = KVPReceivingStates.CONTINUE_KVP;

                        }
                        break;
                    default:
                    case KVPReceivingStates.ERROR:
                        //something bad happend, restart the machine
                        kvpBuffer.Clear();
                        kvpState = KVPReceivingStates.WAITING_KVP;
                        break;
                }
            }
            catch
            {
                //something bad happend, restart the machine
                kvpBuffer.Clear();
                kvpState = KVPReceivingStates.WAITING_KVP;
            }
        }
    }
}
