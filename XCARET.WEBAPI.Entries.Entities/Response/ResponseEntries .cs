using System;
using System.Collections.Generic;
using System.Text;
using XCARET.WEBAPI.Entries.Entities.Entities;

namespace XCARET.WEBAPI.Entries.Entities.Response
{
    public class ResponseEntries
    {
        public int count { get; set; }
        public List<Entities.Entries> entries { get; set; }
    }
}
