using System;
using System.Collections.Generic;
using Project_X_2._0.Models;
using System.Linq;

namespace Project_X_2._0.Tests.Features
{
    internal class TripsListManager
    {
        private List<Trip> data;

        public TripsListManager(List<Trip> data)
        {
            this.data = data;
        }

        internal Trip getLatest()
        {
            return data.LastOrDefault();
        }
    }
}