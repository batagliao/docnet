﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docnet.Models
{
    public abstract class MetadataBase
    {
        public string Summary { get; set; }
        public string Remarks { get; set; }

        /// <summary>
        /// Identifier for hyperlinks
        /// </summary>
        public Guid HashId { get; } = Guid.NewGuid();

        public string LinkUrl
        {
            get { return HashId.ToString(); }
        }
    }
}
