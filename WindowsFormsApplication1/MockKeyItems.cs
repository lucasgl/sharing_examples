using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class MockKeyItems : KeyValuePairList
    {
        public MockKeyItems()
        {
            KeyValuePair kvp = new KeyValuePair();
            kvp.Name = "abv";
            kvp.Class = "124";
            kvp.Length = "4";
            kvp.DataTypeString = "int8";

            this.Items.Add(kvp);

            kvp = new KeyValuePair();
            kvp.Name = "def";
            kvp.Class = "345";
            kvp.Length = "2";
            kvp.DataTypeString = "int32";

            this.Items.Add(kvp);

        }
    }
}
