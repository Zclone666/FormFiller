﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppPir.Models;
using TestAppPir.Models.Shared;

namespace TestAppPir.Consts
{
    public static class MainParams
    {
        public static uint Page = 1;
        public static uint NmbOfSquares = 2;
        public const uint SizeOfSquare = 100;
        public static double AspectRatioHeight = 1;
        public static double AspectRatioWidth = 1;
        public static bool ConnStatus = false;
        public static List<Casuelty> Fudged=new List<Casuelty>();
        public static List<ItemPersonnel> BackendDBIn = new List<ItemPersonnel>();
    }
}
