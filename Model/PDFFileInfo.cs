﻿/*
 *    Copyright 2009, 2010 Francesco Tonucci
 * 
 * This file is part of PDFRider.
 * 
 * PDFRider is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * PDFRider is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with PDFRider; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 * 
 * 
 * Project page: http://pdfrider.codeplex.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFRider
{
    /// <summary>
    /// Stores basic informations about a file (path, number of pages, ...)
    /// </summary>
    public class PDFFileInfo
    {
        public PDFFileInfo()
        {
            this.PageRanges = new List<string>();
        }

        public string FullName { get; set; }
        public short NumberOfPages { get; set; }
        public short PageLabelStart { get; set; }
        public List<string> PageRanges { get; private set; }
    }
}