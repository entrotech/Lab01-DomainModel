﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Domain
{
    /// <summary>
    /// MPAA Rating, as defined by the MPAA at http://www.mpaa.org/film-ratings/
    /// </summary>
    public class MpaaRating : LookupBase
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
