﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IActivityService
    {
        Activity GetActivityById(int id);
        bool AddActivity(Activity activity);
        bool EditActivity(Activity activity);
        IQueryable<Activity> GetAllActivity();
    }
}
